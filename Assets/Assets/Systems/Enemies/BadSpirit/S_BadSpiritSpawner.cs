using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class S_BadSpiritSpawner : MonoBehaviour
{
    public int simulEnemies;
    [SerializeField] int currentEnemies;
    [SerializeField] private GameObject badSpirit;
    [SerializeField] private List<Transform> SpawnLocations;

    [SerializeField] private float spawnTimer;
    public float timeStamp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeStamp = Time.time+spawnTimer;
    }

    private void FixedUpdate()
    {
        if(timeStamp <= Time.time)
        {
            
            if (currentEnemies < simulEnemies)
            {
                GameObject SpawnedBadSpirit = Instantiate<GameObject>(badSpirit, ChooseRandomSpawnLocation());
                SpawnedBadSpirit.GetComponent<S_BadSpiritBehaviour>().SetSpawner(this);
                currentEnemies++;
                timeStamp = Time.time + spawnTimer;
            }
            else
            {
                timeStamp = Time.time + spawnTimer;
            }
        }
    }

    private Transform ChooseRandomSpawnLocation()
    {
        // Eliminar referencias a objetos destruidos.
        SpawnLocations.RemoveAll(location => location == null);

        if (SpawnLocations.Count == 0)
            return null;

        int randomIndex = UnityEngine.Random.Range(0, SpawnLocations.Count);

        return SpawnLocations[randomIndex];
    }

    public void SubstractCurrentEnemies()
    {
        currentEnemies--;
    }
}
