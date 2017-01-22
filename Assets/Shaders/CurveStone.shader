Shader "Custom/CurvedStone" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_EffectTex("Effect (RGB)", 2D) = "white" {}
		_Curv("Curvature", Float) = 0.001
		_Effect("Effect", Float) = 1.0
		_Blend("Outside control", Float) = 0.0

	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Lambert vertex:vert addshadow

		uniform sampler2D _MainTex;
		uniform sampler2D _EffectTex;
		uniform float _Curv;
		uniform float _Effect;
		uniform float _Blend;

	struct Input {
		float2 uv_MainTex;
	};

	void vert(inout appdata_full v)
	{

		float4 vv = mul(unity_ObjectToWorld, v.vertex);
		vv.xyz -= _WorldSpaceCameraPos.xyz;

		// one axis
		vv = float4(0.0f, (vv.z * vv.z) * -_Curv, 0.0f, 0.0f);
		// two
		//vv = float4(0.0f, ((vv.z * vv.z) + (vv.x * vv.x)) * -_Curv, 0.0f, 0.0f);

		v.vertex += mul(unity_WorldToObject, vv);
	}

	void surf(Input IN, inout SurfaceOutput o) {
		float time = _Time.g;
		float2 uv = IN.uv_MainTex;
		half4 c = tex2D(_MainTex, uv);
		half4 effect = tex2D(_EffectTex, uv);
		float fade = abs(sin(time*2));
		fade = lerp(fade,_Effect,_Blend);
		c = c+c*fade*0.25f +fade*0.25f + effect * (fade*5) * uv.y*fade;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}
	ENDCG
	}

}
