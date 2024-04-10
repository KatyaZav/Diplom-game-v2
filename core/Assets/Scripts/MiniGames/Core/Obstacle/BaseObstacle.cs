using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var y = collision.gameObject.GetComponent<PlayerController>();
        Debug.Log("Hitted to " + y);
        if (y != null)
            OnCollisionPlayer(y);
    }

    public virtual void OnCollisionPlayer(PlayerController player) {}
}
