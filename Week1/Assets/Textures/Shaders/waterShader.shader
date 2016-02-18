Shader "Custom/waterShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_WaveHeight ("Wave Height", Range (0,5)) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
			
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows vertex:vert addshadow 
		#pragma target 3.0
		#define PI 3.14159265358979323846		
	
		uniform fixed4 _Color;
		uniform sampler2D _MainTex;
		uniform float _WaveHeight;
			
		struct Input {
			float2 uv_MainTex : TEXCOORD0;
			float2 uv;
		};
		void vert (inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT (Input,o);
			fixed4 newVerts = mul(UNITY_MATRIX_MV, v.vertex);	
			
			v.vertex += float4(0, sin(_Time.y - v.vertex.x + v.vertex.z) * _WaveHeight, 0, 0);			
			o.uv = TRANSFORM_UV(0);
		}
		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed2 st = IN.uv_MainTex;
			o.Albedo = tex2D(_MainTex, st);
			o.Metallic = 0;
			o.Smoothness = 0;
			o.Alpha = 1;
		}
		ENDCG
	}

	FallBack "Diffuse"
}
