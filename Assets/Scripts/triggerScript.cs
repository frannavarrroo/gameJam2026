using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScript : MonoBehaviour
{
    public GameObject uiHandler;
    private ElementsUI elementUI;

    void Start() {
        this.elementUI = uiHandler.GetComponent<ElementsUI>();
    }

    private void OnTriggerStay(Collider other) {
        bool isEnemy1 = other.gameObject.CompareTag("enemy1");
        bool isEnemy2 = other.gameObject.CompareTag("enemy2");
        if (isEnemy1 || isEnemy2) {
            this.elementUI.changeHealth(-1);
        }

        if (other.gameObject.CompareTag("health")) {
            this.elementUI.changeHealth(1);
        }
    }

    void Update() {
        if (this.elementUI.GetHealth()<=0) {
            KillPlayer();
        }

        if (Input.GetKeyUp(KeyCode.E)) {
            this.elementUI.changeMasks();
        }
    }

    private void KillPlayer() {
            SceneManager.LoadScene("GameOver");
    }
}
