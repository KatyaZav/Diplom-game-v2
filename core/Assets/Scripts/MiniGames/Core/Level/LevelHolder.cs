using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHolder : MonoBehaviour
{
    [SerializeField] List<GameObject> _leftLane;
    [SerializeField] List<GameObject> _rightLane;
    [SerializeField] List<GameObject> _bothLane;

    private List<GameObject> _currentLaneMassive;

    public GameObject GetRandomLine()
    {
        var rnd = Random.Range(0, _currentLaneMassive.Count);
        return _currentLaneMassive[rnd];
    }

    public void Init()
    {
        _bothLane.AddRange(_leftLane);
        _bothLane.AddRange(_rightLane);
    }

    public void Changelane(LaneFix lane)
    {
        switch (lane)
        {
            case LaneFix.left:
                _currentLaneMassive = _leftLane;
                break;
            case LaneFix.right:
                _currentLaneMassive = _rightLane;
                break;
            case LaneFix.both:
                _currentLaneMassive = _bothLane;
                break;
        }
    }
}

public enum LaneFix
{
    left = 0,
    right = 1,
    both = 2
}
