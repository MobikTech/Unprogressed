Shader "Unlit/NewUnlitShader 1"
{
    Properties
    {
        _Color ("Main Color", Color) = (1, 1, 1, 1)
        _MainTex ("Albedo", 2D) = "gray" {}
    }
    SubShader
    {
        Pass
        {
            Tags
            {
                "LightMode" = "UniversalForward"
            }
            
            HLSLPROGRAM
            #pragma vertex Vertex
            #pragma fragment Fragment
            
            #include "UnityCG.cginc"
            #include "UnityStandardBRDF.cginc"
            
            float4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;


            struct VertexInput
            {
                float4 position : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };
            
            struct FragmentInput
            {
                float4 pixelPosition : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
            };
            
            
            FragmentInput Vertex(VertexInput vi)
            {
                FragmentInput fi;
                fi.pixelPosition = mul(UNITY_MATRIX_MVP, vi.position);
                fi.worldPos = mul(unity_ObjectToWorld, vi.position);
                fi.uv =  TRANSFORM_TEX(vi.uv, _MainTex);
                // fi.normal = mul((float3x3)unity_ObjectToWorld, vi.normal);
                fi.normal = UnityObjectToWorldNormal(vi.normal);
                // fi.normal = mul(transpose(unity_ObjectToWorld), float4(vi.normal, 0));
                // fi.normal = normalize(fi.normal);
                return fi;
            }
            
            float4 Fragment(FragmentInput fi) : SV_TARGET
            {
                fi.normal = normalize(fi.normal);
                // return float4(fi.normal * 0.5 + 0.5, 1);
                // return saturate(dot(fi.normal, float3(0, 1, 0)));
                float3 lightDirection = _WorldSpaceLightPos0.xyz;
                float3 toCameraDirection = normalize(_WorldSpaceCameraPos - fi.worldPos);
                float3 lightColor = _LightColor0.rgb;
                float3 albedo = tex2D(_MainTex, fi.uv).rgb * _Color.rgb;
                float3 diffuse =
                    albedo * lightColor * DotClamped(fi.normal, lightDirection);
                return float4(diffuse, 1);
            }
                        
            
            ENDHLSL
        }
    }
}
