using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    public static Action GameEnded;

    [SerializeField] private float speed = 0.05f;
        
    private int _maxValue;
    private float _currentValue;

    public virtual void Inizialize(int maxValue)
    {
        _maxValue = maxValue;
        _currentValue = _maxValue;

        gameObject.transform.localScale = new Vector3(1, 1, 1);

        StartCoroutine(TimerLogic());
    }

    public void AddTime(float value) => StartCoroutine(AddingTime(value));
    public void RemoveTime(float value) => StartCoroutine(RemovingTime(value));

    public virtual void TimerOut()
    {
        Debug.LogWarning("died");
        GameEnded?.Invoke();
    }

    private IEnumerator AddingTime(float value)
    {
        //Debug.Log("Add time");
        while (value > 0)
        {
            if (_currentValue >= _maxValue)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }

            value -= speed * 2;
            _currentValue += speed*2;
            
            gameObject.transform.localScale += new Vector3(speed * 2 / _maxValue, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator RemovingTime(float value)
    {
        //Debug.Log("Remove time");
        while (value > 0)
        {
            if (_currentValue <= 0)
            {
                TimerOut();
                StopAllCoroutines();
                break;
            }

            value -= speed;
            _currentValue -= speed;

            gameObject.transform.localScale -= new Vector3(speed / _maxValue, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator TimerLogic()
    {
        while (_currentValue > 0)
        {                        
            if (_currentValue <= 0)
                break;

            _currentValue -= speed;
            gameObject.transform.localScale -= new Vector3(speed/_maxValue, 0, 0);


            yield return new WaitForEndOfFrame();
        }

        TimerOut();
    }    

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
