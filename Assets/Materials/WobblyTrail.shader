Shader "Custom/WobblyTrail" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_AlphaClipValue ("Alpha Clip Value", Range(0,1)) = .2
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent" }
		LOD 200
		BindChannels {
    	    Bind "vertex", vertex
    	    Bind "color", color 
    	}
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float4 vertColor : COLOR;
		};

		half _AlphaClipValue;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed texAlpha = tex2D(_MainTex, IN.uv_MainTex).a;
			clip(texAlpha - _AlphaClipValue);
			fixed4 c = IN.vertColor;
			o.Albedo = c.rgb;
			o.Emission = IN.vertColor * (IN.vertColor.b + .2);
			// Metallic and smoothness come from slider variables
			o.Alpha = texAlpha * IN.vertColor.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
