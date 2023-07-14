using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _fishPrefabs;
    [SerializeField] private Transform[] _spawnAreas;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _spawnRange;

    private float _spawnTime = 0.5f;
    private float _elapsedTime = 0f;
    private int _startPoint = 0;
    
    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        
        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            _elapsedTime = 0f;
            CreateFishInArea();
        }
    }

    private void CreateFishInArea()
    {
        int spawnPointNumber = Random.Range(_startPoint, _spawnAreas.Length);
        Vector3 spawnPosition = GetRandomPosition(spawnPointNumber);
        
        GameObject fish = Instantiate(GetRandomPrefab(_fishPrefabs), spawnPosition, _spawnAreas[spawnPointNumber].rotation);
        fish.transform.parent = _spawnAreas[spawnPointNumber];
        FishMover fishMovement = fish.GetComponent<FishMover>();
    }

    private Vector3 GetRandomPosition(int spawnPointNumber)
    {
        Vector3 randomPosition = new Vector3(
            _spawnAreas[spawnPointNumber].position.x, 
            _spawnAreas[spawnPointNumber].position.y, 
            Random.Range(_spawnAreas[spawnPointNumber].position.z - _spawnRange, _spawnAreas[spawnPointNumber].position.z + _spawnRange));

        return randomPosition;
    }

    private GameObject GetRandomPrefab(GameObject[] prefabs)
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject prefab = prefabs[randomIndex];

        return prefab;
    }
}
