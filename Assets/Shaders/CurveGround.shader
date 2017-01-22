Shader "Custom/CurveGround" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Mask("Mask (RBG)", 2D) = "white" {}
		_Curv("Curv", Float) = 0.001
		_Grid("Grid", Float) = 1.0
		_Square1("Square 1", Float) = 1.0
		_Square2("Square 2", Float) = 1.0
		_Blend("Outside control", Float) = 0.0
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Lambert vertex:vert addshadow

		uniform sampler2D _MainTex;
		uniform sampler2D _Mask;
		uniform float _Grid;
		uniform float _Square1;
		uniform float _Square2;
		uniform float _Curv;
		uniform float _Blend;


	struct Input {
		float2 uv_MainTex;
	};

	void vert(inout appdata_full v)
	{

		float4 vv = mul(unity_ObjectToWorld, v.vertex);
		vv.xyz -= _WorldSpaceCameraPos.xyz;

		// one axis
	 	vv = float4(0.0f, (vv.z * vv.z) * _Curv * 0, 0.0f, 0.0f);
		// two
		//vv = float4(0.0f, ((vv.z * vv.z) + (vv.x * vv.x)) * -_Curv, 0.0f, 0.0f);

		v.vertex += mul(unity_WorldToObject, vv);
	}

	void surf(Input IN, inout SurfaceOutput o) {

		float time = _Time.g;
		half4 c = tex2D(_MainTex, IN.uv_MainTex);
		half4 m = tex2D(_Mask, IN.uv_MainTex);


		float mCross = m.g;
		float m1 = m.b;
		float m2 = 1-m1;

		float speed = 2;
		float minFade = 0.25;
		float minFadeGrid = 0.75;

		float phase1 = max(abs(sin(time*speed)),minFade);
		float phase2 = max(abs(cos(time*speed)),minFade);
		float phase3 = max(abs(sin(time*speed*0.33))*2,minFadeGrid);

		phase1 = lerp(phase1,_Square1,_Blend);
		phase2 = lerp(phase2,_Square2,_Blend);
		phase3 = lerp(phase3,_Grid,_Blend);

		half4 clr1 = c * m1 * phase1;
		half4 clr2 = c * m2 * phase2;
		half4 clr3 = c * mCross * phase3;
		half4 clr = (clr1+clr2)*(1-mCross)+clr3*mCross;

		o.Albedo = clr.rgb;
		o.Alpha = c.a;
	}
	ENDCG
	}

}
