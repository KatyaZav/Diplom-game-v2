using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bubbles
{
    public class BubbleButton : MonoBehaviour
    {
        [SerializeField] private Image _image;
        private ColorTypes _color;

        public void ChangeColor(ColorTypes color)
        {
            _color = color;
            _image.sprite = _color.image;
        }
    }
}
