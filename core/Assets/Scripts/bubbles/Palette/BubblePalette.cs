using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bubbles
{

    public class BubblePalette : MonoBehaviour
    {
        [SerializeField] private GeneratorSideType _type;
        [SerializeField] private BubbleButton[] _buttons;

        public void Inizialize()
        {
            Generator.ChangedTask += CheckSlideType;
        }

        private void OnDisable()
        {
            Generator.ChangedTask -= CheckSlideType;            
        }

        private void CheckSlideType(GeneratorSideType type, ColorTypes[] ans, IChooseble u)
        {
            if (_type == type)
            {
                var correctAns = Random.Range(0, _buttons.Length);

                for (var i=0; i<_buttons.Length; i++)
                {
                    if (i == correctAns)
                    {
                        ButtonActivate(_buttons[i],ChooseColor(ans));
                    }
                    else
                    {
                        ButtonActivate(_buttons[i], ChooseColor(ColorsHolder.Instance.BublesTypes));
                    }
                }
            }
        }

        private ColorTypes ChooseColor(ColorTypes[] colors)
        {
            return BubbleColorRandom.GetRandomColor(colors);
        }

        private void ButtonActivate(BubbleButton button, ColorTypes color)
        {
            button.ChangeColor(color);
        }
    }
}

