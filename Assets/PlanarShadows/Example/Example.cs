using System.Collections;
using UnityEngine;

public class Example : MonoBehaviour
{
	public Light ShadowingLight;
	public Color ShadowColor;
	public GameObject ShadowingObjectsRootGO;

	void OnEnable()
	{
		_EnablePlanarShadow( true );
	}

	void OnDisable()
	{
		_EnablePlanarShadow( false );
	}

	void _EnablePlanarShadow( bool enabled )
	{
		for( int i = 0; i < ShadowingObjectsRootGO.transform.childCount; ++i )
		{
			GameObject shadowingObjectGO = ShadowingObjectsRootGO.transform.GetChild( i ).gameObject;
			PlanarShadows.ShadowingLightDirection = ShadowingLight.transform.forward;
			PlanarShadows.ShadowColor = ShadowColor;
			PlanarShadows.EnableShadowOnGameObject( shadowingObjectGO, enabled );
		}
	}
}
