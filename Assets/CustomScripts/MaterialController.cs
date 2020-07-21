using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public Color altColor;
    public Renderer rend;
    private bool isTransparent;
 

    void Start()
    {
      rend = GetComponent<Renderer>();
      isTransparent = false;
      altColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown (KeyCode.E)){

            if(isTransparent)
            {
                   
              rend.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
              rend.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
              rend.material.SetInt("_ZWrite", 1);
              rend.material.DisableKeyword("_ALPHATEST_ON");
              rend.material.DisableKeyword("_ALPHABLEND_ON");
              rend.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
              rend.material.renderQueue = -1;
              isTransparent = false;

              altColor.a -= 1.0f;
              rend.material.color = altColor;
            }
            else
            {
              rend.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
              rend.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
              rend.material.SetInt("_ZWrite", 0);
              rend.material.DisableKeyword("_ALPHATEST_ON");
              rend.material.DisableKeyword("_ALPHABLEND_ON");
              rend.material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
              rend.material.renderQueue = 3000;
              isTransparent = true;

              altColor.a += 1.0f;
              rend.material.color = altColor;

            }

         }
    }
}
