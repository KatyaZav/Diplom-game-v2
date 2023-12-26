using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bubbles;
using System;

[System.Serializable]
public class Generator
{
    public static Action<GeneratorSideType, ColorTypes[]> ChangedTask;

    [SerializeField] private string name;
    [SerializeField] private Image _eyeImage;
    [SerializeField] private GeneratorSideType _sideType;

    private ColorTypes[] _colorTypeChoosed;
    private IChooseble _generateMethod;

    public GeneratorSideType SideType { get => _sideType; }

    public IChooseble GenerateMethon
    {
        get => _generateMethod;
        private set { _generateMethod = value; }
    }

    public Generator(GeneratorSideType type)
    {
        name = type.ToString();
        _sideType = type;
        _colorTypeChoosed = null;
        _generateMethod = new SimpleChoose();
    }


    /// <summary>
    /// Check color answer with generator
    /// </summary>
    public bool CheckAnswer(ColorTypes colorAnswer)
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

        var ans = UnityEngine.Random.Range(0, probability);

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

        ChangedTask?.Invoke(_sideType, _colorTypeChoosed);
    }
}



