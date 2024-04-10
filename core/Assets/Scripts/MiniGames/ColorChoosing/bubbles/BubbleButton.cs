using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorChooseGame.Bubbles
{
    public class BubbleButton : MonoBehaviour
    {
        public static Action<GeneratorSideType, ColorTypes> BubbleClicked;

        public GeneratorSideType Type;
        public Button button;

        [SerializeField] private Image _image;
        [SerializeField] private Animator _anim;
        private ColorTypes _colorType;

        public ColorTypes ColorType { get => _colorType; }

        public void ActivateButton(bool isPauseEnable)
        {
            button.enabled = !isPauseEnable;
            //_image.enabled = isPauseEnable;

            if (isPauseEnable)
                _anim.SetTrigger("off");
            else
                _anim.SetTrigger("on");
        }

        public void ChangeColor(ColorTypes color)
        {
            _image.enabled = true;
            button.enabled = true;

            _colorType = color;
            _image.sprite = _colorType.image;
        }

        public void OnButtonClick()
        {
            _image.enabled = false;
            button.enabled = false;

            Instantiate(_colorType.goodEffect, transform.position, Quaternion.identity);
            BubbleClicked?.Invoke(Type, _colorType);
        }

        private void OnValidate()
        {
            button = GetComponent<Button>();
            _anim = GetComponent<Animator>();
        }
    }
}
