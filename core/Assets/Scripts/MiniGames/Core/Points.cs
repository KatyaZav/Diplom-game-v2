using UnityEngine;


public class Points : MonoBehaviour
{
    public static Points Instance;

    private float _point; 

    public void Init()
    {
        _point = 0;
        Instance = this;
    }

    public void AddPoint(float point) 
    {
        _point += point;
    }

    public float GetPoint() => _point/10;
}
