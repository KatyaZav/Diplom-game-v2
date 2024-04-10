using UnityEngine;
using midgame;
using Level;

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
