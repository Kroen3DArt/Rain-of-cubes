using UnityEngine;
using System.Collections;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _delay = 0.8f;
    [SerializeField] private int _minPositionX;
    [SerializeField] private int _maxPositionX;

    private void Start()
    {
        Initialize(_cubePrefab);
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);

            if (TryGetObject(out GameObject cube))
            {
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
