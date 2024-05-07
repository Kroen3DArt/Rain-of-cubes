using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _count;

    private List<Cube> _pool = new();

    protected void Initialize(Cube cubePrefab)
    {
        for (int i = 0; i < _count; i++)
        {
            Cube spawnedCube = Instantiate(cubePrefab, _container.gameObject.transform);
            spawnedCube.gameObject.SetActive(false);

            _pool.Add(spawnedCube);
        }
    }

    protected bool TryGetObject(out Cube item)
    {
        item = _pool.First(cube => cube.gameObject.activeSelf == false);

        return item != null;
    }
}
