using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bubbles;
using System.Linq;

public class Generator : MonoBehaviour
{
    private ColorType[] _colorTypeChoosed;
    private IChooseble _generateMethon;

    /// <summary>
    /// Check color answer with generator
    /// </summary>
    public bool CheckAnswer(ColorType colorAnswer)
    {
        foreach (var color in _colorTypeChoosed)
        {
            if (color == colorAnswer)
                return true;
        }

        return false;
    }

    /// <summary>
    /// change generation color method
    /// </summary>
    public void ChangeGenerateMethon(MethondProbability[] methonds)
    {
        var probability = 0;

        foreach (var methond in methonds)
        {
            probability += methond.probability;
        }

        var ans = Random.Range(0, probability);

        foreach (var methond in methonds)
        {
            ans -= methond.probability;
            if (ans <= 0)
            {
                _generateMethon = methond.method;
                return;
            }
        }

        throw new System.Exception("Something vent wrong");
    }
}

[System.Serializable]
public class MethondProbability
{
    public IChooseble method;
    public int probability;
}
