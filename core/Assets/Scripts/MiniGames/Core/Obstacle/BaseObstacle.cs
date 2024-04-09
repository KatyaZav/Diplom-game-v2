using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var y = collision.gameObject.GetComponent<PlayerController>();
        if (y != null)
            OnCollisionPlayer(y);
    }

    public virtual void OnCollisionPlayer(PlayerController player) {}
}
