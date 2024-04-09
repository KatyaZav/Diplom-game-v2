using UnityEngine;

namespace ColorChooseGame
{
    public class HpSlider : Slider
    {
        [SerializeField] private float _costOfMistake;
        public override void Inizialize(int maxValue)
        {
            GameLogic.ClickedButton += OnClick;
            GameLogic.ChangeColorAnimation += Pause;

            base.Inizialize(maxValue);
        }

        public void Pause(bool pause, GeneratorSideType type)
        {
            if (_timer != null)
                StopCoroutine(_timer);

            //Debug.Log(pause);

            if (pause == false)
            {
                _timer = StartCoroutine(TimerLogic());
            }
        }

        private void OnDisable()
        {
            GameLogic.ClickedButton -= OnClick;
            GameLogic.ChangeColorAnimation -= Pause;
        }

        void OnClick(bool isGood)
        {
            if (isGood)
                AddTime(_costOfMistake * 1.1f);
            else
                RemoveTime(_costOfMistake);
        }
    }
}
