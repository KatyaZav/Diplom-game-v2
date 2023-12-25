using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Bubbles
{
    public class InverseChoose : IChooseble
    {
        public void Chosed()
        {
            throw new System.NotImplementedException();
        }

        public ColorType[] GenerateAnswer(ColorTypes[] colors)
        {
            List<ColorType> ans = new List<ColorType>();

            foreach (var color in colors)
            {
                ans.Add(color.color);
            }

            var removedColor = BubbleColorRandom.GetRandomColor(colors);
        
            ans.Remove(removedColor);
                
            return ans.ToArray();
        }
    }
}
