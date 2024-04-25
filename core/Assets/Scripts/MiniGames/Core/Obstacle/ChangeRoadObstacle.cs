using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoadObstacle : BaseObstacle
{
    [SerializeField] Level.RoadLine _line;

    public override void OnCollisionPlayer(PlayerController player)
    {
        Points.Instance.AddPoint(10);
        player.ChangeRoadLine(_line);
    }
}
