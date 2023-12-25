using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubbles
{
    public class BubbleColorRandom
    {
        private ColorType[] _colors;

        public BubbleColorRandom(ColorType[] colors)
        {
            _colors = colors;
        }

        /// <summary>
        /// Get random color from class list
        /// </summary>
        public ColorType GetRandomColor()
        {
            var randomIndex = Random.Range(0, _colors.Length);
            return _colors[randomIndex];
        }

        /// <summary>
        /// Get random color from list
        /// </summary>
        public static ColorType GetRandomColor(ColorTypes[] colors)
        {
            var randomIndex = Random.Range(0, colors.Length);
            return colors[randomIndex].color;
        }
    }
}

