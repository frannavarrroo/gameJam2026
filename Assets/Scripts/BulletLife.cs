using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 8f;
    public float lifetime = 10f;
    public Material material1;
    public Material material2;
    public EntitySpawner spawnEnemy1Handler;
    public EntitySpawner spawnEnemy2Handler;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (gameObject.CompareTag("bullet1"))
        {
            rend.material = material1;
        } else
        {
            rend.material = material2;
        }
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        bool part1 = other.gameObject.CompareTag("enemy1") && gameObject.CompareTag("bullet1");
        bool part2 = other.gameObject.CompareTag("enemy2") && gameObject.CompareTag("bullet2");
        if (part1 || part2) {
            if (other.gameObject.CompareTag("enemy1"))
            {
                spawnEnemy1Handler.EntityDestroyed();
            } else
            {
                spawnEnemy2Handler.EntityDestroyed();
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
