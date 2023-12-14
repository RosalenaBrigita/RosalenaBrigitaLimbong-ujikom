using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public List<GameObject> animalsToSpawn = new List<GameObject>();
    public int maxSpawnCountPerInterval = 1;
    public float spawnInterval = 2f; 
    public float horizontalSpacing = 3f; 

    private float currentSpawnX = 0f; 

    void Start()
    {
        StartCoroutine(SpawnAnimals());
    }

    IEnumerator SpawnAnimals()
    {
        while (true)
        {
            for (int i = 0; i < maxSpawnCountPerInterval; i++)
            {
                GameObject animalPrefab = animalsToSpawn[Random.Range(0, animalsToSpawn.Count)];
                Vector3 spawnPosition = GetNextSpawnPosition();
                GameObject spawnedAnimal = Instantiate(animalPrefab, spawnPosition, Quaternion.identity);

                spawnedAnimal.transform.Rotate(0f, 180f, 0f);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }


    Vector3 GetNextSpawnPosition()
    {
        float spawnDirection = Random.Range(0f, 1f) > 0.5f ? 1f : -1f;

        Vector3 spawnPosition = transform.position + Vector3.right * spawnDirection * Random.Range(currentSpawnX, currentSpawnX + horizontalSpacing);

        currentSpawnX = spawnPosition.x;

        Collider spawnerCollider = GetComponent<Collider>();

        if (spawnerCollider != null)
        {
            Vector3 colliderSize = spawnerCollider.bounds.size;
            spawnPosition.x = Mathf.Clamp(spawnPosition.x, transform.position.x - colliderSize.x / 2f, transform.position.x + colliderSize.x / 2f);
            spawnPosition.z = Mathf.Clamp(spawnPosition.z, transform.position.z - colliderSize.z / 2f, transform.position.z + colliderSize.z / 2f);
        }

        return spawnPosition;
    }

}
