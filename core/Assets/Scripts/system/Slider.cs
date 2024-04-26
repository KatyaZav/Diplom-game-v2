using System;
using System.Collections;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public static Action GameEnded;

    [SerializeField] private float speed = 0.01f;

    protected Coroutine _timer;
        
    private float _maxValue;
    private float _currentValue;

    public virtual void Inizialize(float maxValue)
    {
        _maxValue = maxValue;
        _currentValue = _maxValue;

        gameObject.transform.localScale = new Vector3(1, 1, 1);

        //_timer = StartCoroutine(TimerLogic());
    }

    public void AddTime(float value) => StartCoroutine(AddingTime(value));
    public void RemoveTime(float value) => StartCoroutine(RemovingTime(value));

    public virtual void TimerOut()
    {
        Debug.LogWarning("died");
        GameEnded?.Invoke();
    }

    protected IEnumerator TimerLogic()
    {
        while (_currentValue > 0)
        {                        
            yield return new WaitForEndOfFrame();
            
            if (_currentValue <= 0)
                break;

            _currentValue -= speed;
            gameObject.transform.localScale -= new Vector3(speed/_maxValue, 0, 0);
        }

        TimerOut();
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

            value -= speed * 6;
            _currentValue += speed*6;
            
            gameObject.transform.localScale += new Vector3(speed * 6 / _maxValue, 0, 0);
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

            value -= speed * 4;
            _currentValue -= speed * 4;

            gameObject.transform.localScale -= new Vector3(speed * 4 / _maxValue, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }


    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
