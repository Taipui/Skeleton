// URP Dissolve 2020 | VFX Shaders | Unity Asset Store
// https://assetstore.unity.com/packages/vfx/shaders/urp-dissolve-2020-191256
Shader "Unlit/Dissolve_Unlit"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _BaseColor ("BaseColor", Color) = (1, 1, 1, 1)
        _Dissolve ("Dissolve", Range(0.0, 1.0)) = 0.5
        _NoiseScale ("NoiseScale", Float) = 50
        _NoiseUVSpeed ("NoiseUVSpeed", Vector) = (0, 0, 0, 0)
        _EdgeWidth ("EdgeWidth", Range(0.0, 1.0)) = 0.05
        [HDR] _EdgeColor ("EdgeColor", Color) = (0, 3.890196, 4, 0)
        _EdgeColorIntensity ("EdgeColorIntensity", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque"}
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
			#include "Dissolve.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            half4 _BaseColor;
            float _Dissolve;
            float _NoiseScale;
            float2 _NoiseUVSpeed;
            float _EdgeWidth;
            half4 _EdgeColor;
            float _EdgeColorIntensity;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float dissolveMask = SimpleNoise(UVSpeed(i.uv, _NoiseUVSpeed), _NoiseScale);

				// EdgeAndAlphaMask.
                float alpha = step(lerp(0 - _EdgeWidth, 1, _Dissolve), dissolveMask);
                float edgeMask = alpha - step(lerp(0, 1 + _EdgeWidth, _Dissolve), dissolveMask);

                // Dissolve.
                float alphaClip = (1 - alpha) + 0.0001;
                fixed4 edgeColor = (edgeMask * _EdgeColor) * _EdgeColorIntensity;
                edgeColor = edgeMask * _EdgeColor;

                fixed4 col = (_BaseColor * tex2D(_MainTex, TilingAndOffset(i.uv, _MainTex_ST.xy, _MainTex_ST.zw))) + edgeColor;
                clip(alpha - alphaClip);

                return col;
            }
            ENDCG
        }
    }
}
