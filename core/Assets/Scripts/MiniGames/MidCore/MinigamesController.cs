using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesController : MonoBehaviour
{
    [SerializeField] GameObject _colorChooseGame;

    public void Init()
    {
        ColorGameObstacle.ColorMinigameCathed += ActivateColorGame;    
    }

    public void PauseGame()
    {
        BaseLevel.StopLevel();
    }

    public void ContinueGame()
    {
        Debug.Log("added some points");
        BaseLevel.SetSpeedToPrevious();
    }

    public void LoseGame()
    {
        Debug.Log("lose minigame");
    }

    private void OnDisable()
    {
        ColorGameObstacle.ColorMinigameCathed -= ActivateColorGame;   
    }

    void ActivateColorGame()
    {
        PauseGame();
        _colorChooseGame.SetActive(true);
    }
}
