using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] Bubbles.ColorsHolder _holder;
    [SerializeField] private List<Generator> _generators = 
        new List<Generator> { new Generator(GeneratorSideType.left), new Generator(GeneratorSideType.right) };

    public void Inizialize()
    {
        ChangeTask(_generators[0]);
        ChangeTask(_generators[1]);
    }

    void ChangeTask(Generator generator)
    {
        generator.ChangeGenerateMethon(_holder.EyesAnswerTypes);
        generator.GenerateColor(_holder.BublesTypes);


        Debug.Log("Change " + generator._generateMethod);
    }
}
