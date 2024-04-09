using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevel : MonoBehaviour
{

    private static float _speed = 1f;

    public static float GetSpeed() => _speed;

    public static void UpdateSpeed(float speedAdd = 0.1f)
    {
        _speed += speedAdd;

        if (_speed > 5)
            _speed = 5;

        if (_speed < -5)
            _speed = -5;
    }

    private void Update()
    {
        transform.Translate(transform.up * -1 * _speed * Time.deltaTime);
    }
}
