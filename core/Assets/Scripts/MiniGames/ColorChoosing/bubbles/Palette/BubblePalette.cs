using UnityEngine;


namespace ColorChooseGame.Bubbles
{
    public class BubblePalette : MonoBehaviour
    {
        [SerializeField] private GeneratorSideType _type;
        [SerializeField] private BubbleButton[] _buttons;

        public void Inizialize()
        {
            Generator.ChangedTask += CheckSlideType;
            GameLogic.ChangeColorAnimation += DisactivateButtons;

            foreach (var button in _buttons)
                button.Type = _type;
        }


        private void OnDisable()
        {
            Generator.ChangedTask -= CheckSlideType;
            GameLogic.ChangeColorAnimation -= DisactivateButtons;
        }               

        private void DisactivateButtons(bool pause, GeneratorSideType type)
        {
            if (_type == type)
            {
                foreach (var button in _buttons)
                {
                    button.ActivateButton(pause);
                }
            }
        }
            
        private void CheckSlideType(GeneratorSideType type, ColorTypes[] ans, IChooseble u)
        {
            if (_type == type)
            {
                var correctAns = Random.Range(0, _buttons.Length);

                for (var i=0; i<_buttons.Length; i++)
                {
                    if (i == correctAns && u.Type != ChosesType.NullChoose)
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

