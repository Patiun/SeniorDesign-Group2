﻿Shader "Custom/Gem" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Emission ("Emission", Color) = (0,0,0,0)
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent" }

		GrabPass {
			"_BackGroundTexture"
		}

		Cull Front
			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows
			
			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0
						
			sampler2D _MainTex;
			sampler2D _BackGroundTexture;
			
			struct Input {
				float2 uv_MainTex;
				float3 worldNormal;
			};
			
			half _Glossiness;
			half _Metallic;
			fixed4 _Color;
			float4 _Emission;
			
			// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
			// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
			// #pragma instancing_options assumeuniformscaling
			UNITY_INSTANCING_BUFFER_START(Props)
				// put more per-instance properties here
			UNITY_INSTANCING_BUFFER_END(Props)
			
			void surf (Input IN, inout SurfaceOutputStandard o) {
				float4 bgcolor = tex2D(_BackGroundTexture, float2(IN.worldNormal.z, IN.worldNormal.y));
				o.Albedo = bgcolor.rgb;
//				o.Metallic = _Metallic;
//				o.Smoothness = _Glossiness;
//				o.Alpha = _Color.a;
				o.Emission = _Emission * _Emission.a;
			}
			ENDCG

		Cull Back
			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows alpha:fade
		
			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0
		
			sampler2D _MainTex;
		
			struct Input {
				float2 uv_MainTex;
				float3 worldNormal;
			};
		
			half _Glossiness;
			half _Metallic;
			fixed4 _Color;
			float4 _Emission;
		
			// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
			// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
			// #pragma instancing_options assumeuniformscaling
			UNITY_INSTANCING_BUFFER_START(Props)
				// put more per-instance properties here
			UNITY_INSTANCING_BUFFER_END(Props)
		
			void surf (Input IN, inout SurfaceOutputStandard o) {
				// Albedo comes from a texture tinted by color
				o.Albedo = _Color.rgb;
				// Metallic and smoothness come from slider variables
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = _Color.a;
				float4 objNormal = mul(unity_WorldToObject, float4(IN.worldNormal, 1));
				float4 tex = tex2D (_MainTex, float2(objNormal.z, objNormal.y));
//				o.Emission = _Emission.a * _Emission;
			}
			ENDCG
	}
	FallBack "Diffuse"
}