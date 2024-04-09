using UnityEngine;

namespace ColorChooseGame.Bubbles
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
        public static ColorTypes GetRandomColor(ColorTypes[] colors)
        {
            if (colors != new ColorTypes[] { ColorsHolder.Instance.ZeroBubble })
            {
                var randomIndex = Random.Range(0, colors.Length);
                return colors[randomIndex];
            }
            else
            {
                colors = ColorsHolder.Instance.BublesTypes;
                var randomIndex = Random.Range(0, colors.Length);
                return colors[randomIndex];
            }
        }
    }
}

