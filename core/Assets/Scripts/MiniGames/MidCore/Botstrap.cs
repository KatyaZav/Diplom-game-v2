using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botstrap : MonoBehaviour
{
    [SerializeField] LevelHolder _levelHolder;
    [SerializeField] MinigamesController _minigamesController;

    void Start()
    {
        _minigamesController.Init();
        _levelHolder.Init();
    }
}
