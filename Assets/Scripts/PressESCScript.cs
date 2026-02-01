using UnityEngine;
using UnityEngine.SceneManagement;

public class PressESCScript : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("Presentation");
        }    

    }
}
