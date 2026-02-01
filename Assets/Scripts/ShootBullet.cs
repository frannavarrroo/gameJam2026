using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    private GameObject instanceBullet;
    public GameObject uiHandler;
    private ElementsUI elementUI;
    public EntitySpawner spawnEnemy1Handler;
    public EntitySpawner spawnEnemy2Handler;

    void Start()
    {
        this.elementUI = uiHandler.GetComponent<ElementsUI>();
    }
    void Update()
    {
        GameObject gunPoint = GameObject.FindGameObjectsWithTag("gunpoint")[0];
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion rotation = gunPoint.transform.rotation;
            instanceBullet = Instantiate(this.bullet,gunPoint.transform.position,gunPoint.transform.rotation);
            if (this.elementUI.imgMask1On())
            {
                instanceBullet.tag = "bullet1";
                instanceBullet.GetComponent<NewMonoBehaviourScript>().spawnEnemy1Handler = spawnEnemy1Handler;
            } else
            {
                instanceBullet.tag = "bullet2";
                instanceBullet.GetComponent<NewMonoBehaviourScript>().spawnEnemy2Handler = spawnEnemy2Handler;
            }
        }
    }
}
