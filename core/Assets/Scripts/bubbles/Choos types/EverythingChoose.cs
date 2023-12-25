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

        public ColorType[] GenerateAnswer(ColorTypes[] colors)
        {
            List<ColorType> ans = new List<ColorType>();

            foreach(var color in colors)
            {
                ans.Add(color.color);
            }

            return ans.ToArray();
        }
    }
}
