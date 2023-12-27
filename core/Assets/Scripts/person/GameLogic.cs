using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bubbles;

public class GameLogic : MonoBehaviour
{ 
    public static Action<bool> ClickedButton;

    //[SerializeField] Bubbles.ColorsHolder _holder;
    [SerializeField] private List<Generator> _generators = 
        new List<Generator>
    { 
        new Generator(GeneratorSideType.left), new Generator(GeneratorSideType.right)
    };

    private int _timeBetweenSpawn = 5;

    public void Inizialize()
    {
        //ChangeTask(_generators[1]);

        BubbleButton.BubbleClicked += OnButtonClick;

        StartCoroutine(ChangeTaskByTime(GeneratorSideType.right));
        StartCoroutine(ChangeTaskByTime(GeneratorSideType.left));

    }

    private IEnumerator ChangeTaskByTime(GeneratorSideType type)
    {
        while (true)
        {
            Debug.Log("Set anim and change");
            
            yield return new WaitForSeconds(1);
            
            ChangeTask(_generators[(int)type]);

            yield return new WaitForSeconds(_timeBetweenSpawn - 1);           

        }
    }

    private void OnDisable()
    {
        BubbleButton.BubbleClicked -= OnButtonClick;
    }

    private void OnButtonClick(GeneratorSideType type, ColorTypes color)
    {
        ClickedButton?.Invoke(_generators[(int)type].CheckAnswer(color));

        StopCoroutine(ChangeTaskByTime(type));
        StartCoroutine(ChangeTaskByTime(type));
    }

    private void ChangeTask(Generator generator)
    {
        generator.ChangeGenerateMethon(ColorsHolder.Instance.EyesAnswerTypes);
        generator.GenerateColor(ColorsHolder.Instance.BublesTypes);

        //Debug.Log("Change " + generator._generateMethod);
    }
}
