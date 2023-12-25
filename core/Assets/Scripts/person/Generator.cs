using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bubbles;

[System.Serializable]
public class Generator
{
    [SerializeField] private string name;
    [SerializeField] private Image _eyeImage;
    [SerializeField] private GeneratorSideType _sideType;

    private ColorType[] _colorTypeChoosed;
    public IChooseble _generateMethod;

    public IChooseble GenerateMethon
    {
        get => _generateMethod;
        private set { _generateMethod = value; }
    }

    public Generator(GeneratorSideType type)
    {
        name = type.ToString();
        _sideType = type;
        _colorTypeChoosed = new ColorType[] { ColorType.blue };
        _generateMethod = new SimpleChoose();
    }


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
    public void ChangeGenerateMethon(BublesTypes[] methonds)
    {
        var probability = 0;

        foreach (var methond in methonds)
        {
            probability += methond.Probability;
        }

        var ans = Random.Range(0, probability);

        foreach (var methond in methonds)
        {
            ans -= methond.Probability;
            if (ans <= 0)
            {
                GenerateMethon = ColorsHolder.DictionaryMethods[methond.ChoseType];
                return;
            }
        }

        throw new System.Exception("Something vent wrong");
    }

    /// <summary>
    /// Generate colors answer 
    /// </summary>
    public void GenerateColor(ColorTypes[] colors)
    {
        _colorTypeChoosed = _generateMethod.GenerateAnswer(colors);
        Debug.Log("Invoke change color");
    }
}



