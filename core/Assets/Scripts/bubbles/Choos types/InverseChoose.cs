using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Bubbles
{
    public class InverseChoose : IChooseble
    {
        public ChosesType Type { get => ChosesType.InverseChoose; }
        public void Chosed()
        {
            throw new System.NotImplementedException();
        }

        public ColorTypes[] GenerateAnswer(ColorTypes[] colors)
        {
            var ans = colors.ToList();

            var removedColor = BubbleColorRandom.GetRandomColor(colors);
        
            ans.Remove(removedColor);
                
            return ans.ToArray();
        }
    }
}
