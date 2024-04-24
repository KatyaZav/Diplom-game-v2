using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;

public class PlayerController : MonoBehaviour
{
    public static Action<int> AddedHp; 
    public static Action<int> RemovedHp;

    [SerializeField] Animator _anim;
    [SerializeField] GameObject _effect;
    [SerializeField] LevelHolder _levelHolder; 

    [SerializeField] float _speed;
    [SerializeField] Vector3 _targetPosition;

    [SerializeField] float _leftBorder, _rightBorder;
    [SerializeField] Collider2D _colider;

    private static int _health;
    private bool isCrossed = true;
    bool _canMove = true;

    RoadLine _roadLine = RoadLine.both;
    private bool _isLeft = false;

    public static void ReloadHealth()
    {
        _health = 3;
    }

    public void ChangeRoadLine(RoadLine line)
    {
        _roadLine = line;
        _levelHolder.Changelane(_roadLine);
        CrossLine();
    }

    public static int GetHealth() => _health;
       

    public void RemoveHp(int hp = 1)
    {
        _effect.SetActive(true);
        _health -= hp;
        //MakeUnHittable(1.5f);

        RemovedHp?.Invoke(_health);

        if (_health <= 0)
        {
            _anim.SetTrigger("dead");
            Debug.Log("Lose");
        }
        else
        {
            _anim.SetTrigger("hit");
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
        if (Input.GetMouseButton(0) && BaseLevel.GetSpeed() != 0)
        {
            if (_canMove)
                ChooseTargetPoint();
        }

        if (Input.GetMouseButtonUp(0))
            _canMove = true;

        #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space))
                Level.BaseLevel.AddSpeed(1);
        #endif
        
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (CheackIsCrossingLine())
            CrossLine();
    }

    bool CheackIsCrossingLine()
    {
        if (transform.position.x >= 0.35f)
        {
            if (_isLeft == true)
            {
                _isLeft = false;
                return true;
            }

            _isLeft = false;
        }
        else if (transform.position.x <= -0.35f)
        {
            if (_isLeft == false)
            {
                _isLeft = true;
                return true;
            }

            _isLeft = true;
        }

        return false;
    }

    void CrossLine()
    {
        //Debug.Log("CrossLine");

        if (_roadLine == RoadLine.both)
            return;

        if (transform.position.x >= 0.2f && _roadLine == RoadLine.left)
        {
            RemoveHp();
            MoveToCorrectLine();
            return;
        }

        if (transform.position.x <= -0.2f && _roadLine == RoadLine.right)
        {
            RemoveHp();
            MoveToCorrectLine();
            return;
        }
    }

    void MoveToCorrectLine()
    {        
        _canMove = false;
        Debug.Log("Move to "+_roadLine);

        if (_roadLine == RoadLine.left)
        {
            _isLeft = true;
            transform.position = new Vector3(-2, transform.position.y, transform.position.z);
        }

        if (_roadLine == RoadLine.right)
        {
            _isLeft = false;
            transform.position = new Vector3(2, transform.position.y, transform.position.z);
        }

        _targetPosition = transform.position;
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
