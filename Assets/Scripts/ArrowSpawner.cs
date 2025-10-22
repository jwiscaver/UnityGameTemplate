using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject upArrowPrefab;
    public GameObject downArrowPrefab;
    public GameObject leftArrowPrefab;
    public GameObject rightArrowPrefab;

    // Spawn positions for each arrow
    public Transform upArrowSpawn;
    public Transform downArrowSpawn;
    public Transform leftArrowSpawn;
    public Transform rightArrowSpawn;

    // Target positions (where the arrows move to)
    public Transform upArrowTarget;
    public Transform downArrowTarget;
    public Transform leftArrowTarget;
    public Transform rightArrowTarget;

    // Arrow movement speed, set globally
    public float arrowSpeed = 4f;

    // List of times when arrows should spawn (in seconds)
    public List<float> spawnTimes;

    private int currentSpawnIndex = 0;
    private float musicStartTime;

    void Start()
    {
        // Record the start time for syncing arrows with the music
        musicStartTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - musicStartTime;

        // Check if it's time to spawn the next arrow
        if (currentSpawnIndex < spawnTimes.Count && elapsedTime >= spawnTimes[currentSpawnIndex])
        {
            SpawnRandomArrow();
            currentSpawnIndex++;
        }
    }

    void SpawnRandomArrow()
    {
        // Randomly select an arrow direction
        int randomDirection = Random.Range(0, 4);
        GameObject arrowToSpawn = null;
        Transform spawnPosition = null;
        Transform targetPosition = null;

        // Assign the appropriate arrow prefab, spawn position, and target
        switch (randomDirection)
        {
            case 0:
                arrowToSpawn = upArrowPrefab;
                spawnPosition = upArrowSpawn;
                targetPosition = upArrowTarget;
                break;
            case 1:
                arrowToSpawn = downArrowPrefab;
                spawnPosition = downArrowSpawn;
                targetPosition = downArrowTarget;
                break;
            case 2:
                arrowToSpawn = leftArrowPrefab;
                spawnPosition = leftArrowSpawn;
                targetPosition = leftArrowTarget;
                break;
            case 3:
                arrowToSpawn = rightArrowPrefab;
                spawnPosition = rightArrowSpawn;
                targetPosition = rightArrowTarget;
                break;
        }

        if (arrowToSpawn != null && spawnPosition != null && targetPosition != null)
        {
            // Instantiate the arrow at the correct spawn position
            GameObject spawnedArrow = Instantiate(arrowToSpawn, spawnPosition.position, Quaternion.identity);

            // Set the speed and target for the arrow
            spawnedArrow.GetComponent<ArrowMovement>().SetSpeed(arrowSpeed);
            spawnedArrow.GetComponent<ArrowMovement>().SetTarget(targetPosition);
        }
    }
}