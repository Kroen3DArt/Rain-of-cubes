using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private int _minLiveTime = 2;
    private int _maxLiveTime = 6;
    private bool _isColorChanged = false;
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void OnEnable()
    {
        _material.color = Color.white;
        _isColorChanged = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Platform>())
        {
            if (_isColorChanged == false)
            {
                _material.color = Random.ColorHSV();
                _isColorChanged = true;
            }
            
            int liveTime = Random.Range(_minLiveTime, _maxLiveTime + 1);
            StartCoroutine(CountLiveTime(liveTime));
        }
    }

    private IEnumerator CountLiveTime(int liveTime)
    {
        yield return new WaitForSeconds(liveTime);
        gameObject.SetActive(false);
    }
}
