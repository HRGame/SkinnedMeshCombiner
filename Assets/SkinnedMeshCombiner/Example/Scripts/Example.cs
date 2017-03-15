using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
	public Light ShadowingLight;
	public Color ShadowColor;

	string[] _animationNames =
	{
		"idle",
		"attack",
		"battle_wait",
		"hit",
		"run",
	};

	List<GameObject[]> _allSoldierGOs = new List<GameObject[]>();

	int _updateCount = 0;

	void Awake()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		//_CreateQiangBingTeam( -40f, 0f );
		//_CreateQiangBingTeam( 0f, 0f );
		//_CreateQiangBingTeam( 40f, 0f );

		//_CreateQiangBingTeam( -40f, -20f );
		//_CreateQiangBingTeam( 0f, -20f );
		//_CreateQiangBingTeam( 40f, -20f );

		//_CreateQiangBingTeam( -40f, -40f );
		//_CreateQiangBingTeam( 0f, -40f );
		//_CreateQiangBingTeam( 40f, -40f );

		////----------------------------------

		//_CreateQiangBingTeam( -20f, 100f, 180f );
		//_CreateQiangBingTeam( 20f, 100f, 180f );
		//_CreateQiangBingTeam( 60f, 100f, 180f );

		//_CreateQiangBingTeam( -20f, 120f, 180f );
		//_CreateQiangBingTeam( 20f, 120f, 180f );
		//_CreateQiangBingTeam( 60f, 120f, 180f );

		//_CreateQiangBingTeam( -20f, 140f, 180f );
		//_CreateQiangBingTeam( 20f, 140f, 180f );
		//_CreateQiangBingTeam( 60f, 140f, 180f );

		_CreateQiangBingTeam( -40f, 0f );
		_CreateQiBingTeam( 0f, 0f );
		_CreateQiangBingTeam( 40f, 0f );

		_CreateQiBingTeam( -40f, -20f );
		_CreateQiangBingTeam( 0f, -20f );
		_CreateQiBingTeam( 40f, -20f );

		_CreateGongBingTeam( -40f, -40f );
		_CreateGongBingTeam( 0f, -40f );
		_CreateGongBingTeam( 40f, -40f );

		//----------------------------------

		_CreateQiangBingTeam( -20f, 100f, 180f );
		_CreateQiBingTeam( 20f, 100f, 180f );
		_CreateQiangBingTeam( 60f, 100f, 180f );

		_CreateQiBingTeam( -20f, 120f, 180f );
		_CreateQiangBingTeam( 20f, 120f, 180f );
		_CreateQiBingTeam( 60f, 120f, 180f );

		_CreateGongBingTeam( -20f, 140f, 180f );
		_CreateGongBingTeam( 20f, 140f, 180f );
		_CreateGongBingTeam( 60f, 140f, 180f );
	}

	void _CreateQiangBingTeam( float posX, float posZ, float rotY = 0f )
	{
		const int X_COUNT = 8;
		const int Z_COUNT = 3;
		const int COUNT = X_COUNT * Z_COUNT;

		GameObject soldierPrototypeGO = Resources.Load<GameObject>( "qiangbing" );
		GameObject teamGO = new GameObject( "TeamQiang" );
		GameObject[] soldierGOs = new GameObject[COUNT];
		for( int i = 0; i < COUNT; ++i )
		{
			soldierGOs[i] = GameObject.Instantiate( soldierPrototypeGO, teamGO.transform );
		}
		for( int z = 0; z < Z_COUNT; ++z )
		{
			for( int x = 0; x < X_COUNT; ++x )
			{
				int i = z * X_COUNT + x;

				soldierGOs[i].transform.position = new Vector3( x * 4.5f + Random.Range( -1f, 1f ), 0f, z * 5f + Random.Range( -1f, 1f ) );
			}
		}

		teamGO.transform.position = new Vector3( posX, 0f, posZ );
		teamGO.transform.Rotate( Vector3.up, rotY );

		_allSoldierGOs.Add( soldierGOs );
	}

	void _CreateGongBingTeam( float posX, float posZ, float rotY = 0f )
	{
		const int X_COUNT = 7;
		const int Z_COUNT = 3;
		const int COUNT = X_COUNT * Z_COUNT;

		GameObject soldierPrototypeGO = Resources.Load<GameObject>( "gongbing" );
		GameObject teamGO = new GameObject( "TeamGong" );
		GameObject[] soldierGOs = new GameObject[COUNT];
		for( int i = 0; i < COUNT; ++i )
		{
			soldierGOs[i] = GameObject.Instantiate( soldierPrototypeGO, teamGO.transform );
		}
		for( int z = 0; z < Z_COUNT; ++z )
		{
			for( int x = 0; x < X_COUNT; ++x )
			{
				int i = z * X_COUNT + x;

				soldierGOs[i].transform.position = new Vector3( x * 5f + Random.Range( -1f, 1f ), 0f, z * 5f + Random.Range( -1f, 1f ) );
			}
		}

		teamGO.transform.position = new Vector3( posX, 0f, posZ );
		teamGO.transform.Rotate( Vector3.up, rotY );

		_allSoldierGOs.Add( soldierGOs );
	}

	void _CreateQiBingTeam( float posX, float posZ, float rotY = 0f )
	{
		const int X_COUNT = 6;
		const int Z_COUNT = 2;
		const int COUNT = X_COUNT * Z_COUNT;

		GameObject soldierPrototypeGO = Resources.Load<GameObject>( "qibing" );
		GameObject teamGO = new GameObject( "TeamQi" );
		GameObject[] soldierGOs = new GameObject[COUNT];
		for( int i = 0; i < COUNT; ++i )
		{
			soldierGOs[i] = GameObject.Instantiate( soldierPrototypeGO, teamGO.transform );
		}
		for( int z = 0; z < Z_COUNT; ++z )
		{
			for( int x = 0; x < X_COUNT; ++x )
			{
				int i = z * X_COUNT + x;

				soldierGOs[i].transform.position = new Vector3( x * 6f + Random.Range( -1f, 1f ), 0f, z * 8f + Random.Range( -1f, 1f ) );
			}
		}

		teamGO.transform.position = new Vector3( posX, 0f, posZ );
		teamGO.transform.Rotate( Vector3.up, rotY );

		_allSoldierGOs.Add( soldierGOs );
	}

	void Start()
	{
		PlanarShadows.ShadowingLightDirection = ShadowingLight.transform.forward;
		PlanarShadows.ShadowColor = ShadowColor;

		foreach( GameObject[] soldierGOs in _allSoldierGOs )
		{
			List<SkinnedMeshRenderer> teamSkinnedMeshRenderers = new List<SkinnedMeshRenderer>();
			Bounds localBounds = new Bounds( new Vector3( 0.0f, 1f, 0.0f ), new Vector3( 10, 5f, 8f ) );

			foreach( GameObject soldierGO in soldierGOs )
			{
				SkinnedMeshRenderer[] soldierSkinnedMeshRenderers = soldierGO.GetComponentsInChildren<SkinnedMeshRenderer>();
				for( int i = 0; i < soldierSkinnedMeshRenderers.Length; ++i )
				{
					teamSkinnedMeshRenderers.Add( soldierSkinnedMeshRenderers[i] );
				}

				Animation anim = soldierGO.GetComponent<Animation>();
				//AnimationState animState = anim["run"];
				//animState.time = Random.Range( 0f, animState.length - 0.1f );
				anim.CrossFade( _animationNames[Random.Range( 0, _animationNames.Length - 1 )] );
				//anim.Play( "run" );
			}

			GameObject teamGO = SkinnedMeshCombiner.Combine( teamSkinnedMeshRenderers, localBounds );
			PlanarShadows.EnableShadowOnGameObject( teamGO, true );
		}
	}

	void Update()
	{
		if( _updateCount % 10 == 0 )
		{
			GameObject[] soldierGOs = _allSoldierGOs[Random.Range( 0, _allSoldierGOs.Count - 1 )];
			GameObject soldierGO = soldierGOs[Random.Range( 0, soldierGOs.Length - 1 )];
			Animation anim = soldierGO.GetComponent<Animation>();
			anim.CrossFade( _animationNames[Random.Range( 0, _animationNames.Length - 1 )] );
		}
	}
}
