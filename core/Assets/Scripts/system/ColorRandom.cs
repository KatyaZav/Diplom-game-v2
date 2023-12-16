using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubbles
{
    public class BubbleColorRandom
    {
        private GameObject[] _colors;

        public BubbleColorRandom(GameObject[] colors)
        {
            _colors = colors;
        }

        public GameObject GetRandomColor()
        {
            var randomIndex = Random.Range(0, _colors.Length);
            return _colors[randomIndex];
        }

        public static GameObject GetRandomColor(GameObject[] colors)
        {
            var randomIndex = Random.Range(0, colors.Length);
            return colors[randomIndex];
        }
    }
}

