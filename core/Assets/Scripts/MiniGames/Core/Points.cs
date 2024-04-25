using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points Instance;

    private int _point;

    public void Init()
    {
        _point = 0;
        Instance = this;
    }

    public void AddPoint(int point) 
    {
        _point += point;
    }

    public int GetPoint() => _point;
}
