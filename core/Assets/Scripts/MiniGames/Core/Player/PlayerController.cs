using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Vector3 _targetPosition;

    [SerializeField] float _leftBorder, _rightBorder;

    private int _health = 3;

    public void RemoveHp(int hp = 1)
    {
        _health -= hp;

        if (_health <= 0)
        {
            Debug.Log("Lose");
        }
    }
    public void AddHp(int hp = 1)
    {
        _health += hp;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ChooseTargetPoint();
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    void ChooseTargetPoint()
    {
        var mousePos = Input.mousePosition;
        var mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        if (mouseWorldPosition.x < _leftBorder)
            mouseWorldPosition.x = _leftBorder;

        if (mouseWorldPosition.x > _rightBorder)
            mouseWorldPosition.x = _rightBorder;

        mouseWorldPosition.y = transform.position.y;
        mouseWorldPosition.z = 0;

        _targetPosition = mouseWorldPosition;
    }

    private void OnValidate()
    {
        _targetPosition = transform.position;
    }
}
