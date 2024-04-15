using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;

public class PlayerController : MonoBehaviour
{
    public static Action<int> AddedHp; 
    public static Action<int> RemovedHp;

    [SerializeField] LevelHolder _levelHolder; 

    [SerializeField] float _speed;
    [SerializeField] Vector3 _targetPosition;

    [SerializeField] float _leftBorder, _rightBorder;
    [SerializeField] Collider2D _colider;

    private static int _health = 3;
    private bool isCrossed = true;

    RoadLine _roadLine = RoadLine.both;

    public void ChangeRoadLine(RoadLine line)
    {
        _roadLine = line;
        _levelHolder.Changelane(_roadLine);
        CrossLine();
    }

    public static int GetHealth() => _health;
       

    public void RemoveHp(int hp = 1)
    {
        _health -= hp;
        //MakeUnHittable(1.5f);

        RemovedHp?.Invoke(_health);

        if (_health <= 0)
        {
            Debug.Log("Lose");
        }
    }
    public void AddHp(int hp = 1)
    {
        _health += hp;

        AddedHp?.Invoke(_health);
    }

    private void MakeUnHittable(float time)
    {
        _colider.enabled = false;
        Invoke("MakeHitteble", time);
    }

    private void MakeHitteble()
    {
        _colider.enabled = true;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ChooseTargetPoint();
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Level.BaseLevel.AddSpeed(1);

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (CheackIsCrossingLine())
            CrossLine();
    }

    bool CheackIsCrossingLine()
    {
        if (transform.position.x >= -0.65f && transform.position.x <= 0.65f)
        {
            if (isCrossed)
            {
                isCrossed = false;
                return true;
            }
        }
        else{
            isCrossed = true;
            return false;
        }

        return false;
    }

    void CrossLine()
    {
        Debug.Log("CrossLine");

        if (_roadLine == RoadLine.both)
            return;

        if (transform.position.x > 0.65f && _roadLine == RoadLine.left)
        {
            RemoveHp();
            return;
        }

        if (transform.position.x < 0.65f && _roadLine == RoadLine.right)
        {
            RemoveHp();
            return;
        }
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
