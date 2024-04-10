using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGameObstacle : BaseObstacle
{
    public static Action ColorMinigameCathed;
    public override void OnCollisionPlayer(PlayerController player)
    {
        BaseLevel.StopLevel();
        ColorMinigameCathed?.Invoke();        
    }
}
