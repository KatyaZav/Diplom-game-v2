using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bubbles;

public class SimpleChoose : IChooseble
{
    public void Chosed()
    {
        throw new System.NotImplementedException();
    }

    public ColorType[] GenerateAnswer(ColorType[] colors)
    {
        return new ColorType[] { BubbleColorRandom.GetRandomColor(colors) };
    }
}
