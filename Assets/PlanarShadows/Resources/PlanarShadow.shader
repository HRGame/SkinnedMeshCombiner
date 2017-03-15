// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "PlanarShadow"
{
	SubShader
	{
		Tags
		{ 
			"Queue" = "Transparent"
			"RenderType" = "Transparent" 
		}
		LOD 100

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask RGB
			Stencil
			{
				Ref 64
				Comp NotEqual
				Pass Replace
			}
			ZTest On
			ZWrite Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			uniform float4 _ShadowingLightDir;

			float _ShadowAttitude;
			fixed4 _ShadowColor;

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			
			v2f vert(appdata v)
			{	
				float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
				float4 planePos = float4(_ShadowingLightDir.x, 0, _ShadowingLightDir.z, 0) * (_ShadowAttitude - worldPos.y) / _ShadowingLightDir.y;
				planePos = planePos + float4(worldPos.x, _ShadowAttitude, worldPos.z, 1.0);

				v2f o;
				o.vertex = mul(UNITY_MATRIX_VP, planePos);
				o.uv = float2(_ShadowAttitude, worldPos.y);

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				
				return fixed4(_ShadowColor.rgb, _ShadowColor.a * step(i.uv.x, i.uv.y));
			}
			ENDCG
		}
	}
}
