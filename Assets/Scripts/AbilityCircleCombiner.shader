Shader "Unlit/AbilityCircleCombiner"
{
	Properties
	{
		_MainTex ("Background Texture", 2D) = "white" {}
		_OverlayTex("Icon Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _OverlayTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 t1 = tex2D(_MainTex, i.uv);
				fixed4 t2 = tex2D(_OverlayTex, i.uv);
				fixed4 col = lerp(t1,t2,t2.a*1);
				return col;
			}
			ENDCG
		}
	}
}
