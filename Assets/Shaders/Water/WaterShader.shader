// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/WaterShader"
{
    Properties
    {
        _Color("Color", Color) = (1,1,0,1)
        _MainTex("Texture", 2D) = "gray" {}
    }
    SubShader
    {
        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            // #include "UnityShaderVariables.cginc"

            float4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            struct VertexInput
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct VertexOut
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            VertexOut vert(VertexInput input)
            {
                VertexOut o;
                // макрос - #define TRANSFORM_TEX(tex,name) (tex.xy * name##_ST.xy + name##_ST.zw)
                o.uv = TRANSFORM_TEX(input.uv, _MainTex);
                o.position = UnityObjectToClipPos(input.position);
                return o;
            }

            float4 frag(VertexOut i) : SV_TARGET0
            {
                // return float4(i.uv, 0, 1);
                return tex2D(_MainTex, i.uv);
                // return i.uv;
            }
            
            ENDHLSL
        }   
    }

    FallBack "Diffuse"











    //Properties
    //{
    //    _Color ("Color", Color) = (1,1,1,1)
    //    _MainTex ("Albedo (RGB)", 2D) = "white" {}
    //    _Glossiness ("Smoothness", Range(0,1)) = 0.5
    //    _Metallic ("Metallic", Range(0,1)) = 0.0
    //}
    //SubShader
    //{
    //    Tags { "RenderType"="Opaque" }
    //    LOD 200

    //    CGPROGRAM
    //    // Physically based Standard lighting model, and enable shadows on all light types
    //    #pragma surface surf Standard fullforwardshadows

    //    // Use shader model 3.0 target, to get nicer looking lighting
    //    #pragma target 3.0

    //    sampler2D _MainTex;

    //    struct Input
    //    {
    //        float2 uv_MainTex;
    //    };

    //    half _Glossiness;
    //    half _Metallic;
    //    fixed4 _Color;

    //    // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
    //    // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
    //    // #pragma instancing_options assumeuniformscaling
    //    UNITY_INSTANCING_BUFFER_START(Props)
    //        // put more per-instance properties here
    //    UNITY_INSTANCING_BUFFER_END(Props)

    //    void surf (Input IN, inout SurfaceOutputStandard o)
    //    {
    //        // Albedo comes from a texture tinted by color
    //        fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
    //        o.Albedo = c.rgb;
    //        // Metallic and smoothness come from slider variables
    //        o.Metallic = _Metallic;
    //        o.Smoothness = _Glossiness;
    //        o.Alpha = c.a;
    //    }
    //    ENDCG
    //}
    //FallBack "Diffuse"
}
