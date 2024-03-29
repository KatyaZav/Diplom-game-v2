using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bubbles;

public class GameLogic : MonoBehaviour
{ 
    public static Action<bool> ClickedButton;
    public static Action<bool, GeneratorSideType> ChangeColorAnimation;

    //[SerializeField] Bubbles.ColorsHolder _holder;
    [SerializeField] private List<Generator> _generators = 
        new List<Generator>
    { 
        new Generator(GeneratorSideType.left), new Generator(GeneratorSideType.right)
    };

    private int _timeBetweenSpawn = 10;

    private Coroutine gen1;
    private Coroutine gen2;

    public void Inizialize()
    {
        //ChangeTask(_generators[1]);

        BubbleButton.BubbleClicked += OnButtonClick;

        gen1 = StartCoroutine(ChangeTaskByTime(GeneratorSideType.right));
        gen2 = StartCoroutine(ChangeTaskByTime(GeneratorSideType.left));

    }

    private IEnumerator ChangeTaskByTime(GeneratorSideType type)
    {
        while (true)
        {
            //Debug.Log("Set anim and change");

            ChangeColorAnimation?.Invoke(true, type);
            yield return new WaitForSeconds(1);
            
            ChangeTask(_generators[(int)type]);
            ChangeColorAnimation?.Invoke(false, type);

            CheckDoubleMethod();

            yield return new WaitForSeconds(_timeBetweenSpawn - 1);           

        }
    }

    private void OnDisable()
    {
        BubbleButton.BubbleClicked -= OnButtonClick;
    }

    private void OnButtonClick(GeneratorSideType type, ColorTypes color)
    {
        //Debug.Log("button clicked");
        ClickedButton?.Invoke(_generators[(int)type].CheckAnswer(color));

        if (type == GeneratorSideType.right)
        {
            StopCoroutine(gen1);
            gen1 = StartCoroutine(ChangeTaskByTime(type));
        }
        else
        {
            StopCoroutine(gen2);
            gen2 = StartCoroutine(ChangeTaskByTime(type));
        }

    }

    private void ChangeTask(Generator generator)
    {
        generator.ChangeGenerateMethon(ColorsHolder.Instance.EyesAnswerTypes);
        generator.GenerateColor(ColorsHolder.Instance.BublesTypes);

        //Debug.Log("Change " + generator.GenerateMethon);
    }

    private void CheckDoubleMethod()
    {
        if (_generators[0].GenerateMethon.Type == _generators[1].GenerateMethon.Type)
        {
            if (_generators[0].GenerateMethon.Type == ChosesType.NullChoose)
            {
                var rand = UnityEngine.Random.Range(0, 2);

                ChangeTask(_generators[rand]);
            }

        }
    }
}
