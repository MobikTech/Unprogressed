Shader "Unlit/NewUnlitShader 1"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "gray" {}
    }
    SubShader
    {
        Pass
        {
            HLSLPROGRAM
            #pragma vertex Vertex
            #pragma fragment Fragment
            
            #include "UnityCG.cginc"
            
            float4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;


            struct VertexInput
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct FragmentInput
            {
                float4 pixelPosition : SV_POSITION;
                // float3 localPosition: TEXCOORD0;
                float2 uv : TEXCOORD0;
            };
            
            
            FragmentInput Vertex(VertexInput vi)
            {
                FragmentInput fi;
                fi.pixelPosition = mul(UNITY_MATRIX_MVP, vi.position);
                // fi.localPosition = vi.position.xyz;
                // fi.uv = vi.uv * _MainTex_ST.xy + _MainTex_ST.zw;           
                fi.uv =  TRANSFORM_TEX(vi.uv, _MainTex);
                return fi;
            }
            
            float4 Fragment(FragmentInput fi) : SV_TARGET
            {
                // return float4(fi.localPosition + 0.5, 1) * _Color;
                // return float4(fi.uv, 1, 1);
                return tex2D(_MainTex, fi.uv) * _Color;
            }
                        
            
            ENDHLSL
        }
    }
}
