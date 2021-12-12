Shader "Custom/MyNewShader"
{
    Properties
    {
        _Color ("Main Color", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        HLSLINCLUDE
        
        ENDHLSL
        
        Tags
        {
            "RenderPipeline" = "UniversalRenderPipeline"       
            "Queue" = "Background"
            "RenderType" = "Transparent"
            "ForceNoShadowCasting" = "False"
            "DisableBatching" = "False"
            "PreviewType" = "Sphere"
            
        }
        LOD 100
        
        Pass
        {
            Name "FirstPass"
            Tags { "LightMode" = "UniversalForward" }
            
            HLSLPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
//             #pragma hull some1
//             #pragma domain some2

            void vert()
            {
            
            }
            
            void frag()
            {
            
            }
            
            ENDHLSL
        }
    
    }
    SubShader
    {
        Tags
        {
            "RenderPipeline" = "UniversalRenderPipeline"       
            "Queue" = "Background"
     
        }
        Pass
        {
        
        }
    
    }
}
