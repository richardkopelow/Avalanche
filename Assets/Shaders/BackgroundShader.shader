Shader "Unlit/BackgroundShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
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
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 worldPos : TEXCOORD0;
			};

			float4 _Color;

			uniform float _HalfWidth;
			uniform float _YOffset;
			uniform float _Slope;

			float distanceFromCurve(float3 pos)
			{
				float dist = 10000;
				for (float f = -_HalfWidth; f < _HalfWidth; f += 0.01f)
				{
					float diff = distance(pos.xy, float2(f, _Slope*f*f + _YOffset));
					if (diff < dist)
					{
						dist = diff;
					}
				}
				return dist;
			}

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = (0,0,0,0);
				float dist = distanceFromCurve(i.worldPos);
				if (dist<0.2)
				{
					col = _Color;
				}
				return col;
			}
			
			ENDCG
		}
	}
}
