using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ChangeScene : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("GamePlay");
    }

    public void MainGame() {

        Cursor.lockState = CursorLockMode.None; // Frees the cursor
        Cursor.visible = true; 
        
        SceneManager.LoadScene("Presentation");
    }

    public void QuitGame() {
         #if UNITY_EDITOR
            // Stop playing the scene in the Unity Editor
            EditorApplication.isPlaying = false;
        #else
            // Quit the built application
            Application.Quit();
        #endif
    }
}
