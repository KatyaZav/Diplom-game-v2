using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpObstacle : BaseObstacle
{
    [SerializeField] GameObject _effect;

    public override void OnCollisionPlayer(PlayerController player)
    {
        player.AddHp();
        Points.Instance.AddPoint(5);
        Instantiate(_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
