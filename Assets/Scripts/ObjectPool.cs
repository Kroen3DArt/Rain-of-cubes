using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _count = 15;

    private List<Cube> _pool = new();

    public void Initialize(Cube cubePrefab)
    {
        for (int i = 0; i < _count; i++)
        {
            Cube spawnedCube = Instantiate(cubePrefab, _container.gameObject.transform);
            spawnedCube.gameObject.SetActive(false);

            _pool.Add(spawnedCube);
        }
    }

    public bool TryGetObject(out Cube item)
    {
        item = _pool.FirstOrDefault(cube => cube.gameObject.activeSelf == false);

        return item != null;
    }
}
