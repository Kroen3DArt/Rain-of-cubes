using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectPool))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private float _delay = 0.8f;
    [SerializeField] private int _minPositionX;
    [SerializeField] private int _maxPositionX;

    private void Start()
    {
        _objectPool.Initialize(_cubePrefab);
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);

            if (_objectPool.TryGetObject(out Cube cube))
            {
                Vector3 spawnPosition = _spawnPoint.position + new Vector3(Random.Range(_minPositionX, _maxPositionX), 0f, 0f);
                ActivateCube(cube, spawnPosition);
            }
        }
    }

    private void ActivateCube(Cube cube, Vector3 spawnPoint)
    {
        cube.gameObject.SetActive(true);
        cube.transform.position = spawnPoint;
    }
}
