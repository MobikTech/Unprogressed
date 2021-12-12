Shader "Custom/TextureSplattingShader"
{
    Properties
    {
        _MainTex ("Splat Map", 2D) = "white" {}
        [NoScaleOffset] _Texture1 ("Texture 1", 2D) = "white" {}
		[NoScaleOffset] _Texture2 ("Texture 2", 2D) = "white" {}
		[NoScaleOffset] _Texture3 ("Texture 3", 2D) = "white" {}
		[NoScaleOffset] _Texture4 ("Texture 4", 2D) = "white" {}
    }
    SubShader
    {
        Pass
        {
            HLSLPROGRAM
            #pragma vertex Vertex
            #pragma fragment Fragment
            
            #include "UnityCG.cginc"
            
            sampler2D _MainTex, _Texture1, _Texture2, _Texture3, _Texture4;
            float4 _MainTex_ST;


            struct VertexInput
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct FragmentInput
            {
                float4 pixelPosition : SV_POSITION;
                float2 uv : TEXCOORD0;
                float2 uvSplat : TEXCOORD1;
            };
            
            
            FragmentInput Vertex(VertexInput vi)
            {
                FragmentInput fi;
                fi.pixelPosition = mul(UNITY_MATRIX_MVP, vi.position);
                fi.uv = vi.uv * _MainTex_ST.xy + _MainTex_ST.zw;
                fi.uvSplat = vi.uv;
                return fi;
            }
            
            float4 Fragment(FragmentInput fi) : SV_TARGET
            {
                // float4 color = tex2D(_MainTex, fi.uv);
                float4 splat = tex2D(_MainTex, fi.uvSplat);
                return
                    tex2D(_Texture1, fi.uv) * splat.r + 
                    tex2D(_Texture2, fi.uv) * splat.g +
                    tex2D(_Texture3, fi.uv) * splat.b +
                    tex2D(_Texture4, fi.uv) * (1 - splat.r - splat.g - splat.b);
            }
            
            ENDHLSL    
        }
    }
}
