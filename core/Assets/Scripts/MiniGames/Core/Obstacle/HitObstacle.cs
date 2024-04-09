using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObstacle : BaseObstacle
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnCollisionPlayer(PlayerController player)
    {
        player.RemoveHp();
    }
}
