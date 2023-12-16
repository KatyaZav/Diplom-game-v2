using Bubbles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullChoose : IChooseble
{
    public void Chosed()
    {
        throw new System.NotImplementedException();
    }

    public ColorType[] GenerateAnswer(ColorType[] colors)
    {
        return null;
    }
}
