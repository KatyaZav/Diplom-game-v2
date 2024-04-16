using UnityEngine;

public abstract class BaseObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var y = collision.gameObject.GetComponent<PlayerController>();
        //Debug.Log("Hitted " + gameObject.name);
        if (y != null)
            OnCollisionPlayer(y);
    }

    public virtual void OnCollisionPlayer(PlayerController player) {}
}
