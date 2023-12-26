using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    
    [SerializeField, Range(50, 100)] private int _timeBetween;

    private void OnValidate()
    {
        _anim = GetComponent<Animator>();
    }

    public void Inizialize()
    {
        StartCoroutine(MovingNeck());
        StartCoroutine(MovingHead());        
    }

    private void OnDisable()
    {
        StopCoroutine(MovingNeck());
        StopCoroutine(MovingHead());
    }

    private IEnumerator MovingNeck()
    {
        float x = 0;
        while (true)
        {
            var time = _timeBetween;
            var delta = time;

            var x1 = Random.Range(-1f-x, 1f-x);

            while(time > 0)
            {                
                time -= 1;
                x += x1 / delta;
                _anim.SetFloat("moveBody", x);

                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForFixedUpdate();
            yield return new WaitForSeconds(Random.Range(0.5f, 5));
        }
    }

    private IEnumerator MovingHead()
    {
        float x = 0;
        while (true)
        {
            var time = _timeBetween;
            var delta = time;

            var x1 = Random.Range(-1f - x, 1f - x);

            while (time > 0)
            {
                time -= 1;
                x += x1 / delta;
                _anim.SetFloat("headMove", x);

                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForFixedUpdate();
            yield return new WaitForSeconds(Random.Range(2f, 5));
        }
    }
}

public enum GeneratorSideType
{
    left,
    right
}
