using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoadObstacle : BaseObstacle
{
    [SerializeField] Level.RoadLine _line;

    public override void OnCollisionPlayer(PlayerController player)
    {
        player.ChangeRoadLine(_line);
    }
}
