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
        _minigamesController.Init();
        _levelHolder.Init();
        _levelGenerator.Init(); 
    }
}
