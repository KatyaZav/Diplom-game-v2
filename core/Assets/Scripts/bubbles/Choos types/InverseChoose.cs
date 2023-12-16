using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bubbles;
using System.Linq;

public class InverseChoose : IChooseble
{
    public void Chosed()
    {
        throw new System.NotImplementedException();
    }

    public ColorType[] GenerateAnswer(ColorType[] colors)
    {
        var colorsAns = colors.ToList();
        var color = BubbleColorRandom.GetRandomColor(colors);
        
        colorsAns.Remove(color);
                
        return colorsAns.ToArray();
    }
}
