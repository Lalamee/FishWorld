using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _fishPrefab;
    [SerializeField] private Transform[] _spawnAreas;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _spawnRange;

    private float _elapsedTime = 0f;
    
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
        int spawnPointNumber = Random.Range(0, _spawnAreas.Length);
        Vector3 spawnPosition = GetRandomPosition(spawnPointNumber);

        Instantiate(_fishPrefab, spawnPosition, _spawnAreas[spawnPointNumber].rotation);
        FishMover fishMovement = _fishPrefab.GetComponent<FishMover>();
    }

    private Vector3 GetRandomPosition(int spawnPointNumber)
    {
        Vector3 randomPosition = new Vector3(
            _spawnAreas[spawnPointNumber].position.x, 
            _spawnAreas[spawnPointNumber].position.y, 
            Random.Range(_spawnAreas[spawnPointNumber].position.z - _spawnRange, _spawnAreas[spawnPointNumber].position.z + _spawnRange));

        return randomPosition;
    }
}
