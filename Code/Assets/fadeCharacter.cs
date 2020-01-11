using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeCharacter : MonoBehaviour
{


    public string[] MaterialCache = new string[100];
    public int[] RenderCache = new int[100];
    public GameObject characterGameObject;

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
        StartCoroutine(Wait()); 
    }

    IEnumerator Wait()
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
        
        iTween.FadeTo(characterGameObject, 1, 2);
        SetMaterialOpaque();
    }


    private bool IsCharacter(Collider collider)

    {
        // Implement you logic here if it is your player that is the collider
        return true;
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
                    

                    Debug.Log(m.name.ToString());
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


        void OnTriggerExit(Collider collider)

        {

            if (IsCharacter(collider))

            {

                // Set material to opaque

                iTween.FadeTo(characterGameObject, 1, 1);


                Invoke("SetMaterialOpaque", 1.0f);

            }

        }
    }
}



