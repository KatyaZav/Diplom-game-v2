using UnityEngine;
using UnityEngine.Events;

namespace ColorChooseGame
{
    public class MinigameBostrap : MonoBehaviour
    {
        [SerializeField] private GameLogic _gameLogic;
        [SerializeField] private Bubbles.BubblePalette[] _palets;
        [SerializeField] private EyeUI[] _eyeUI;
        [SerializeField] private CharacterAnimator _character;
        [SerializeField] private Slider _slider;
        [SerializeField] private Points _points;

        [SerializeField] private UnityEvent LoseGameEvent; 
        [SerializeField] private UnityEvent WinGameEvent;

        private void OnEnable()
        {
            Slider.GameEnded += GameEnd;
            GameLogic.WinEvent += Win;

            _character.Inizialize();

            foreach (var pallet in _palets)
                pallet.Inizialize();

            foreach (var eye in _eyeUI)
                eye.Inizialize();

            var rnd = Random.Range(2, 5);

            _gameLogic.Inizialize(rnd);
            _points.Inizialize(0);

            _slider.Inizialize(10*PlayerController.GetHealth());
        }

        private void OnDisable()
        {
            Slider.GameEnded -= GameEnd;
            GameLogic.WinEvent -= Win;
        }

        private void GameEnd()
        {
            gameObject.SetActive(false);
            LoseGameEvent?.Invoke();
        }

        private void Win()
        {
            gameObject.SetActive(false);
            WinGameEvent?.Invoke();
        }
    }
}
