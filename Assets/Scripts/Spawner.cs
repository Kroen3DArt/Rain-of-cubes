using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private int _minPositionX;
    [SerializeField] private int _maxPositionX;

    private float _elapsedTime;

    private void Start()
    {
        Initialize(_cubePrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeBetweenSpawn)
        {
            if (TryGetObject(out GameObject cube))
            {
                _elapsedTime = 0;
                Vector3 spawnPosition = _spawnPoint.position + new Vector3(Random.Range(_minPositionX, _maxPositionX), 0f, 0f); 
                SetCube(cube, spawnPosition);
            }
        }
    }

    private void SetCube(GameObject cube, Vector3 spawnPoint)
    {
        cube.SetActive(true);
        cube.transform.position = spawnPoint;
    }
}
