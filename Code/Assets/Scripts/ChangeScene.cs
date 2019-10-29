using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //TS

    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = this.GetComponentInParent<Transform>();
    }

    private void Update()
    {
        //probably completely fucking wrong, but who cares for now x)
        //if(cameraTransform.rotation.eulerAngles.z >= 180)
       // {
       //     NextScene();
      //  }
    }

    private void TestNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "PrototypePastScene")
        {
            SceneManager.LoadScene("PrototypeFutureScene");
        }
        if(scene.name == "PrototypeFutureScene")
        {
            SceneManager.LoadScene("PrototypePastScene");
        }
    }
}
