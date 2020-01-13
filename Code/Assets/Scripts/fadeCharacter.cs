using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeCharacter : MonoBehaviour
{


    public string[] MaterialCache;
    public int[] RenderCache;

    public float opacity;
    public float waitTimeGhostFadeIn;
    public float waitTimeGhostFadeOut;
    GameObject characterGameObject;

    public void Start()
    {
        characterGameObject = this.gameObject;


        int childCount = characterGameObject.transform.childCount;

        for (int i = 0; i <= childCount - 1; i++)
        {

            if (characterGameObject.transform.GetChild(i).transform.GetComponent<Renderer>() != null)
            {
                int MaterialLength = characterGameObject.transform.GetChild(i).transform.GetComponent<Renderer>().materials.Length - 1;

                int j = 0;

                foreach (Material m in characterGameObject.transform.GetChild(i).GetComponent<Renderer>().materials)
                {
                    MaterialCache[i + j] = m.shader.name;
                    RenderCache[i + j] = m.renderQueue;
                    j++;
                }
            }
        }
    }


    public void fadeOut()
    {       
        StartCoroutine(WaitFadeOut()); 
    }

    IEnumerator WaitFadeOut()
    {
        yield return new WaitForSeconds(1);
        Animator current = gameObject.GetComponent<Animator>();
        float animationLength = current.GetCurrentAnimatorStateInfo(0).length;
        Debug.Log(animationLength);
        yield return new WaitForSeconds(animationLength - 2);
        SetMaterialTransparent();
        iTween.FadeTo(characterGameObject, 0, 1);
       
    }

    public void fadeIn()
    {
        StartCoroutine(WaitFadeIn());
    }

    IEnumerator WaitFadeIn()
    {
        yield return new WaitForSeconds(2);
        iTween.FadeTo(characterGameObject, opacity, 2);
        SetMaterialOpaque();
       

    }

    public void fadeInGhost()
    {
        StartCoroutine(WaitFadeInGhost());
    }

    IEnumerator WaitFadeInGhost()
    {
        yield return new WaitForSeconds(waitTimeGhostFadeIn);
        iTween.FadeTo(characterGameObject, opacity, 2);
        SetMaterialOpaque();
        yield return new WaitForSeconds(waitTimeGhostFadeOut);
        iTween.FadeTo(characterGameObject, 0, 2);
        SetMaterialTransparent();

    }

    private void SetMaterialTransparent()
    {
        int childCount = characterGameObject.transform.childCount;

        

        for (int i = 0; i <= childCount - 1; i++)
        {

            if (characterGameObject.transform.GetChild(i).transform.GetComponent<Renderer>() != null )
            {
                int MaterialLength = characterGameObject.transform.GetChild(i).transform.GetComponent<Renderer>().materials.Length - 1;

                int j = 0;
                //Debug.Log(characterGameObject.name.ToString());
                foreach (Material m in characterGameObject.transform.GetChild(i).transform.GetComponent<Renderer>().materials)
                {
                   // MaterialCache[i + j] = m.shader.name;
                    

                 
                    if (m.name != "Scalp_High_polytail_Transparency_Pbr (Instance)")
                    {
                       // MaterialCache[i + j] = m.shader.name;
                        Shader TransShader = Shader.Find("Transparent/VertexLit with Z");
                       m.shader = TransShader;
                    }

                    

                        m.SetFloat("_Mode", 2);

                        m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);

                        m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

                    //  m.SetInt("_ZWrite", 0);

                    //  m.DisableKeyword("_ALPHATEST_ON");

                    //  m.EnableKeyword("_ALPHABLEND_ON");

                    // m.DisableKeyword("_ALPHAPREMULTIPLY_ON");

                    m.renderQueue = RenderCache[i + j];

                    j++;
                }
            }
        }
    }


    private void SetMaterialOpaque()

    {
        Debug.Log("test");
        int childCount = characterGameObject.transform.childCount;

        for (int i = 0; i <= childCount - 1; i++)
        {

            if (characterGameObject.transform.GetChild(i).transform.GetComponent<Renderer>() != null)
            {
                int MaterialLength = characterGameObject.transform.GetChild(i).transform.GetComponent<Renderer>().materials.Length - 1;

                int j = 0;

                foreach (Material m in characterGameObject.transform.GetChild(i).GetComponent<Renderer>().materials)
                {

                    
                    Shader oldShader = Shader.Find(MaterialCache[i + j]);
                        m.shader = oldShader;



                    //m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);

                    // m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                    //if (m.name != "Scalp_High_polytail_Transparency_Pbr (Instance)")
                    // m.SetInt("_ZWrite", 1);

                    // m.DisableKeyword("_ALPHATEST_ON");

                    //m.DisableKeyword("_ALPHABLEND_ON");

                    //m.DisableKeyword("_ALPHAPREMULTIPLY_ON");

                    m.renderQueue = RenderCache[i + j];
                    j++;
                }
            }
        }
    }
    
}



