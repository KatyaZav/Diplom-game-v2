using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubbles
{
    public class NullChoose : IChooseble
    {
        public void Chosed()
        {
            throw new System.NotImplementedException();
        }

        public ColorTypes[] GenerateAnswer(ColorTypes[] colors)
        {
            return null;
        }
    }
}
