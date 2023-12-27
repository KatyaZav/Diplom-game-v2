using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    [SerializeField] private float speed = 0.05f;
    
    private int _maxValue;
    private float _currentValue;

    public void Inizialize(int maxValue)
    {
        _maxValue = maxValue;
        _currentValue = _maxValue;

        gameObject.transform.localScale = new Vector3(1, 1, 1);

        StartCoroutine(TimerLogic());
    }

    private IEnumerator TimerLogic()
    {
        while (_currentValue > 0)
        {
            _currentValue -= speed;
            //Debug.Log(gameObject.transform.localScale);
            gameObject.transform.localScale -= new Vector3(speed/_maxValue, 0, 0);
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("died");
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
