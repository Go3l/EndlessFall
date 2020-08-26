using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private float platformSpeed = 0.1f;

    private float spawnRate = 0.8f;
    private float initialSpawnRate = 0.8f;
    private const float speedIncrement = 0.0001f;
    private const float initialPlatformSpeed = 0.1f;

    [SerializeField] private Vector3 startPosition;
    public GameObject platformPrefab;

    private void Start()
    {
        initialSpawnRate = spawnRate;
        StartCoroutine(Spawn(1));
    }

    private IEnumerator Spawn(float delay)
    {
        yield return new WaitForSeconds(spawnRate);
        SpawnPlatform();
        StartCoroutine(Spawn(0));
    }

    private void SpawnPlatform()
    {
        GameObject platform = ObjectPooler.SharedInstance.GetPooledObject();

        if (platform != null)
        {
            var platformScript = platform.GetComponent<MovingPlatform>();
            platformScript.ChangeSpeed(platformSpeed);
            platformSpeed += speedIncrement;
            SpawnSpeedUpdate();

            platform.transform.position = startPosition;
            platform.transform.rotation = Quaternion.identity;
            platform.SetActive(true);
            platformScript.scoredUp = false;
        }
    }

    private void SpawnSpeedUpdate()
    {
        spawnRate = (initialPlatformSpeed * initialSpawnRate) / platformSpeed;
    }
}
