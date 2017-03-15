using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkinnedMeshCombiner
{
	public static GameObject Combine( List<SkinnedMeshRenderer> skinnedMeshRenderers, Bounds localBounds )
	{
		GameObject combinedSkinnedMeshGO = new GameObject( "CombinedSkinnedMesh" );

		if( skinnedMeshRenderers.Count == 0 )
			return combinedSkinnedMeshGO;

		List<BoneWeight> boneWeights = new List<BoneWeight>();
		List<Transform> bones = new List<Transform>();
		List<CombineInstance> combineInstances = new List<CombineInstance>();
		Material sharedMaterial = skinnedMeshRenderers[0].sharedMaterial;

		int num = 0;
		for( int i = 0; i < skinnedMeshRenderers.Count; ++i )
		{
			SkinnedMeshRenderer skinnedMeshRenderer = skinnedMeshRenderers[i];
			BoneWeight[] bws = skinnedMeshRenderer.sharedMesh.boneWeights;
			Transform[] bs = skinnedMeshRenderer.bones;

			for( int bwIndex = 0; bwIndex < bws.Length; ++bwIndex )
			{
				BoneWeight boneWeight = bws[bwIndex];
				boneWeight.boneIndex0 += num;
				boneWeight.boneIndex1 += num;
				boneWeight.boneIndex2 += num;
				boneWeight.boneIndex3 += num;

				boneWeights.Add( boneWeight );
			}
			num += bs.Length;

			for( int boneIndex = 0; boneIndex < bs.Length; ++boneIndex )
			{
				bones.Add( bs[boneIndex] );
			}

			CombineInstance combineInstance = new CombineInstance()
			{
				mesh = skinnedMeshRenderer.sharedMesh,
				transform = skinnedMeshRenderer.transform.localToWorldMatrix
			};
			combineInstances.Add( combineInstance );

			skinnedMeshRenderer.enabled = false;
		}

		List<Matrix4x4> bindposes = new List<Matrix4x4>();
		for( int i = 0; i < bones.Count; ++i )
		{
			Transform bone = bones[i];
			bindposes.Add( bone.worldToLocalMatrix * combinedSkinnedMeshGO.transform.worldToLocalMatrix );
		}

		SkinnedMeshRenderer combinedSkinnedMeshRenderer = combinedSkinnedMeshGO.AddComponent<SkinnedMeshRenderer>();
		combinedSkinnedMeshRenderer.updateWhenOffscreen = false;
		combinedSkinnedMeshRenderer.localBounds = localBounds;
		combinedSkinnedMeshRenderer.sharedMesh = new Mesh();
		combinedSkinnedMeshRenderer.sharedMesh.CombineMeshes( combineInstances.ToArray(), true, true );
		combinedSkinnedMeshRenderer.sharedMaterial = sharedMaterial;
		combinedSkinnedMeshRenderer.bones = bones.ToArray();
		combinedSkinnedMeshRenderer.sharedMesh.boneWeights = boneWeights.ToArray();
		combinedSkinnedMeshRenderer.sharedMesh.bindposes = bindposes.ToArray();
		combinedSkinnedMeshRenderer.sharedMesh.RecalculateBounds();

		return combinedSkinnedMeshGO;
	}
}
