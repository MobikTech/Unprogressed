Shader "Custom/TexturedWithDetails"
{
    Properties
    {
        _Color ("MainColor", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
        _DetailTexture ("Detail Texture", 2D) = "gray" {}
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
            sampler2D _MainTex, _DetailTexture;
            float4 _MainTex_ST, _DetailTexture_ST;


            struct VertexInput
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct FragmentInput
            {
                float4 pixelPosition : SV_POSITION;
                float2 uv : TEXCOORD0;
                float2 uvDetail: TEXCOORD1;
            };
            
            
            FragmentInput Vertex(VertexInput vi)
            {
                FragmentInput fi;
                fi.pixelPosition = mul(UNITY_MATRIX_MVP, vi.position);
                fi.uv = vi.uv * _MainTex_ST.xy + _MainTex_ST.zw;
                fi.uvDetail = vi.uv * _DetailTexture_ST.xy + _DetailTexture_ST.zw;
                return fi;
            }
            
            float4 Fragment(FragmentInput fi) : SV_TARGET
            {
                float4 color = tex2D(_MainTex, fi.uv) * _Color;
                color *= tex2D(_DetailTexture, fi.uvDetail) * unity_ColorSpaceDouble;
                // return float4(fi.uv.xy, 1, 1);
                return color;
            }
                        
            
            ENDHLSL    
        }
            
    }
    FallBack "Diffuse"
}
