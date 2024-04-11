using UnityEngine;
using midgame;
using Level;

public class Botstrap : MonoBehaviour
{
    [SerializeField] LevelHolder _levelHolder;
    [SerializeField] MinigamesController _minigamesController;
    [SerializeField] LevelGenerator _levelGenerator;

    void Start()
    {
        _levelHolder.Init();
        _minigamesController.Init();
        _levelGenerator.Init(); 
    }
}
