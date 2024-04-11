using UnityEngine;
using System;

public class GenerateZone : BaseObstacle
{
    public static Action<Transform> NeedGenerateNewZone;

    [SerializeField] Transform _endBlockPosition; 
    
    public override void OnCollisionPlayer(PlayerController player)
    {
        NeedGenerateNewZone?.Invoke(_endBlockPosition);
    }
}
