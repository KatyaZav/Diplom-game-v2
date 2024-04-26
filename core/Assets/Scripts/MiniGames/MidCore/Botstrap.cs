using UnityEngine;
using midgame;
using Level;

public class Botstrap : MonoBehaviour
{
    [SerializeField] LevelHolder _levelHolder;
    [SerializeField] MinigamesController _minigamesController;
    [SerializeField] LevelGenerator _levelGenerator;
    [SerializeField] HealthUI _healthUi;
    [SerializeField] Points _point;
    [SerializeField] LevelSpeedManager _levelManager;

    void OnEnable()
    {
        _levelHolder.Init();
        _minigamesController.Init();
        _levelGenerator.Init();
        _healthUi.Init();
        _point.Init();
        _levelManager.Init();

        BaseLevel.RestartSpeed();
        PlayerController.ReloadHealth();
    }
}
