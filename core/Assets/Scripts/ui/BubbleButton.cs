using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bubbles
{
    public class BubbleButton : MonoBehaviour
    {
        public static Action<GeneratorSideType, ColorTypes> BubbleClicked;

        public GeneratorSideType Type;
        public Button button;

        [SerializeField] private Image _image;
        private ColorTypes _colorType;
        public ColorTypes ColorType { get => _colorType; }

        public void ChangeColor(ColorTypes color)
        {
            _colorType = color;
            _image.sprite = _colorType.image;
        }

        public void OnButtonClick()
        {
            BubbleClicked?.Invoke(Type, _colorType);
        }

        private void OnValidate()
        {
            button = GetComponent<Button>();
        }
    }
}
