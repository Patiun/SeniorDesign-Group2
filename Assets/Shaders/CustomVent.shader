Shader "Custom/CustomCradientWorldVerticalBased" {
	Properties {
		[Toggle(FLIPCOLORS)] 
		_flipColors ("Flip Colors", float) = 0
		_Color1 ("White Color", Color) = (1,1,1,1)
		_Color2 ("Black Color", Color) = (0,0,0,1)
		_GradientGrayscale ("Gradient Grayscale", 2D) = "white" {}
		_WorldStartCoordinateY ("WorldStartCoordinateY", float) = 0
		_EffectHeightY ("_EffectHeightY", float) = 1
		_MainTex ("MainTex", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		Cull Off

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows
		#pragma shader_feature FLIPCOLORS

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _GradientGrayscale;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		fixed4 _Color1;
		fixed4 _Color2;
		float _flipColors;

		float _WorldStartCoordinateY;
		float _EffectHeightY;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);

			float yRelative = saturate((IN.worldPos.y - _WorldStartCoordinateY) / _EffectHeightY);
			float gradientValue = tex2D (_GradientGrayscale, float2(IN.worldPos.x/10, yRelative)).r; // on a greyscale r is the same g,b, and a
			#ifdef FLIPCOLORS
       			c *= lerp(_Color1, _Color2, (1 - gradientValue.r));
       		#else
       			c *= lerp(_Color1, _Color2, gradientValue.r);
       		#endif
       		o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
