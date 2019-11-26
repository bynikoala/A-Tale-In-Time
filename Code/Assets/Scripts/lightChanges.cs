using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightChanges : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void adjustIntensity (float intensity)
    {
        Light light = gameObject.GetComponent<Light>();
        light.intensity = intensity;
    }
    public void adjustSunRotX(float rotX)
    {
        gameObject.transform.eulerAngles = new Vector3(rotX, gameObject.transform.localRotation.y, gameObject.transform.localRotation.z);
    }
    public void adjustSunRotY(float rotY)
    {
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.localRotation.x, rotY, gameObject.transform.localRotation.z);
    }
}
