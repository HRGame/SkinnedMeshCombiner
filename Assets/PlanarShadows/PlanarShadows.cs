using System;
using System.Collections.Generic;
using UnityEngine;

public class PlanarShadows : MonoBehaviour
{
	public static Vector3 ShadowingLightDirection;
	public static Color ShadowColor;

	public static void EnableShadowOnGameObject( GameObject go, bool enabled )
	{
		if( enabled )
		{
			PlanarShadow planarShadow = go.GetComponent<PlanarShadow>();
			if( planarShadow == null )
			{
				planarShadow = go.AddComponent<PlanarShadow>();
			}

			planarShadow.enabled = true;
		}
		else
		{
			PlanarShadow planarShadow = go.GetComponent<PlanarShadow>();
			if( planarShadow != null )
			{
				planarShadow.enabled = false;
			}
		}
	}

	void LateUpdate()
	{
		Shader.SetGlobalVector( "_ShadowingLightDir", ShadowingLightDirection );
		Shader.SetGlobalVector( "_ShadowColor", ShadowColor );
	}
}
