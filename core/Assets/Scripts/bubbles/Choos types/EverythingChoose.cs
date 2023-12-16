using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubbles
{
    public class EverythingChoose : IChooseble
    {
        public void Chosed()
        {
            throw new System.NotImplementedException();
        }

        public ColorType[] GenerateAnswer(ColorType[] colors)
        {
            return colors;
        }
    }
}
