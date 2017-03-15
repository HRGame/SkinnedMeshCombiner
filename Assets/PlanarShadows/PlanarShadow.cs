using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlanarShadow : MonoBehaviour
{
	const float SHADOW_ATTITUDE_OFFSET = 0.01f;

	static Material _shadowMaterialPrototype;

	Material _shadowMaterial;

	void OnEnable()
	{
		if( _shadowMaterialPrototype == null )
		{
			_shadowMaterialPrototype = new Material( Shader.Find( "PlanarShadow" ) );
		}

		if( _shadowMaterial == null )
		{
			_shadowMaterial = new Material( _shadowMaterialPrototype );
		}

		Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
		foreach( Renderer renderer in renderers )
		{
			Material[] originalMaterials = renderer.sharedMaterials;
			Material[] newMaterials = new Material[originalMaterials.Length + 1];
			for( int i = 0; i < originalMaterials.Length; ++i )
			{
				newMaterials[i] = originalMaterials[i];
			}
			newMaterials[originalMaterials.Length] = _shadowMaterial;

			renderer.materials = newMaterials;
		}
	}

	void LateUpdate()
	{
		if( _shadowMaterial != null )
		{
			_shadowMaterial.SetFloat( "_ShadowAttitude", gameObject.transform.position.y + SHADOW_ATTITUDE_OFFSET );
		}
	}

	void OnDisable()
	{
		Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
		foreach( Renderer renderer in renderers )
		{
			Material[] originalMaterials = renderer.sharedMaterials;
			List<Material> newMaterials = new List<Material>();
			for( int i = 0; i < originalMaterials.Length; ++i )
			{
				if( originalMaterials[i] != _shadowMaterial )
				{
					newMaterials.Add( originalMaterials[i] );
				}
			}

			renderer.sharedMaterials = newMaterials.ToArray();
		}
	}
}
