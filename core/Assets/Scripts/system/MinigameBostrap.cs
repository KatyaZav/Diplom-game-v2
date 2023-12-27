using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBostrap : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private Bubbles.BubblePalette[] _palets;
    [SerializeField] private EyeUI[] _eyeUI;
    [SerializeField] private CharacterAnimator _character;
    [SerializeField] private Slider _slider;


    private void OnEnable()
    {
        Slider.GameEnded += GameEnd;

        _character.Inizialize();

        foreach (var pallet in _palets)
            pallet.Inizialize();

        foreach (var eye in _eyeUI)
            eye.Inizialize();

        _slider.Inizialize(100);

        _gameLogic.Inizialize();
    }

    private void GameEnd()
    {
        gameObject.SetActive(false);
    }
}
