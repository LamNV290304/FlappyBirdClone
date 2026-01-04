using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public float spawnRate = 1.0f;
    public float minHeight = -1.0f;
    public float maxHeight = 1.0f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPrefabs), 0.0f, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPrefabs));
    }

    private void SpawnPrefabs()
    {
        GameObject pipes = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
