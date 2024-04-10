using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesController : MonoBehaviour
{
    [SerializeField] GameObject _colorChooseGame;

    void Init()
    {
        ColorGameObstacle.ColorMinigameCathed += ActivateColorGame;    
    }

    private void OnDisable()
    {
        ColorGameObstacle.ColorMinigameCathed -= ActivateColorGame;   
    }

    void ActivateColorGame()
    {
        _colorChooseGame.SetActive(true);
    }
}
