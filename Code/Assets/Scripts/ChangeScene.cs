using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private float timer;
    private Transform cameraTransform;
    private Vector3 oldEulerAngles;

    private void Start()
    {
        cameraTransform = this.GetComponentInParent<Transform>();
        Input.gyro.enabled = true;
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        resetRotation(timer);
      
        Vector3 eulerAngles = Input.gyro.attitude.eulerAngles;

        if (eulerAngles.z - oldEulerAngles.z >= 180)
        {
            NextScene();
        }
    }

    private void NextScene()
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

    private void resetRotation(float timer)
    {
        if (timer >= 1.5)
        {
            oldEulerAngles = this.gameObject.transform.eulerAngles;
            timer = 0;
        }
    }
}
