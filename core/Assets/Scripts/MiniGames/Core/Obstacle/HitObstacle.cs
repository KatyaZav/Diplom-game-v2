using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObstacle : BaseObstacle
{
    public override void OnCollisionPlayer(PlayerController player)
    {
        player.RemoveHp();
        Destroy(gameObject);
    }
}
