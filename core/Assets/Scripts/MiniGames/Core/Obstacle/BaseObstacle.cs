using UnityEngine;

public abstract class BaseObstacle : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    [SerializeField] AudioSource _sorce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var y = collision.gameObject.GetComponent<PlayerController>();
        //Debug.Log("Hitted " + gameObject.name);
        if (y != null)
            OnCollisionPlayer(y);
    }

    public virtual void OnCollisionPlayer(PlayerController player) 
    {
        if (_sorce != null)
        {
            _sorce.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
            _sorce.PlayOneShot(_clip);
            //Debug.LogWarning(_clip);
        }
        //else
        //    Debug.LogError("source is null");
    }
}
