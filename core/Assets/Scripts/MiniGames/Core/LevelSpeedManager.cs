using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeedManager : MonoBehaviour
{
    public void Init()
    {
        StartCoroutine(SpeedCoroutine());
    }

    IEnumerator SpeedCoroutine()
    {
        while (true)
        {
            //Debug.Log(Level.BaseLevel.GetSpeed());
            yield return new WaitForSeconds(Level.BaseLevel.GetSpeed()/1.5f);

            if (Level.BaseLevel.GetSpeed() != 0)
                Level.BaseLevel.AddSpeed();
        }
    }
}
