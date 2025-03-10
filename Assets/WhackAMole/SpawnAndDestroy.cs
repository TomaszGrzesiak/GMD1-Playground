using UnityEngine;

public class SpawnAndDestroy : MonoBehaviour
{
    public GameObject spherePrefab;
    public int numberOfSpheres = 10;  // Number of spheres to spawn
    private float spawnRadius = 5f;

    void Start()
    {
        SpawnSpheres();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            //Physics.Raycast(Vector3 origin, Vector3 direction, RaycastHit hitInfo, float distance, int LayerMask);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Sphere"))  // Check if the object is a sphere
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log("Sphere Destroyed: " + hit.collider.gameObject.name);
                }
            }
        }
    }

    void SpawnSpheres()
    {
        for (int i = 0; i < numberOfSpheres; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                Random.Range(1f, 3f), // Spawn a little above ground
                Random.Range(-spawnRadius, spawnRadius)
            );

            GameObject sphere = Instantiate(spherePrefab, randomPosition, Quaternion.identity);
            sphere.tag = "Sphere"; // Assign a tag for easier detection
        }
    }
}