using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelOnSwtich : MonoBehaviour
{
    // Start is called before the first frame update

    

   public void ModelOn(GameObject a)
    {
       
        if (a.activeSelf == false)
        {
            a.gameObject.SetActive(true);
            Debug.Log("s");
        }

    }
    public void ModelOff(GameObject a)
    {

        if (a.activeSelf == true)
        {
            a.gameObject.SetActive(false);
            Debug.Log("a");
        }
      

    }

}
