using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _count;

    private List<GameObject> _pool = new();

    protected void Initialize(GameObject cubePrefab)
    {
        for (int i = 0; i < _count; i++)
        {
            GameObject spawnedCube = Instantiate(cubePrefab, _container.transform);
            spawnedCube.SetActive(false);

            _pool.Add(spawnedCube);
        }
    }

    protected bool TryGetObject(out GameObject item)
    {
        item = _pool.First(cube => cube.activeSelf == false);

        return item != null;
    }
}
