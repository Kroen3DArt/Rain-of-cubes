using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private const string ObstacleTag = "Obstacle";

    private int _minLiveTime = 2;
    private int _maxLiveTime = 6;
    private bool _isColorChanged = false;
    private Color _defaultColor = Color.white;

    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = _defaultColor;
        _isColorChanged = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(ObstacleTag))
        {
            if (_isColorChanged == false)
            {
                GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
                _isColorChanged = true;
            }
            
            int liveTime = Random.Range(_minLiveTime, _maxLiveTime + 1);
            StartCoroutine(ElapseTame(liveTime));
        }
    }

    private IEnumerator ElapseTame(int liveTime)
    {
        yield return new WaitForSeconds(liveTime);
        gameObject.SetActive(false);
    }
}
