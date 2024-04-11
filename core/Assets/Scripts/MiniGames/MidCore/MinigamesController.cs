using UnityEngine;
using Level;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace midgame
{
    public class MinigamesController : MonoBehaviour
    {

        [SerializeField] GameObject _colorChooseGame;

        [SerializeField] UnityEvent LosedGame;

        public void Init()
        {
            ColorGameObstacle.ColorMinigameCathed += ActivateColorGame;
            PlayerController.RemovedHp += CheckLose;
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            LosedGame?.Invoke();
        }

        private void OnDisable()
        {
            ColorGameObstacle.ColorMinigameCathed -= ActivateColorGame;
            PlayerController.RemovedHp -= CheckLose;
        }

        void CheckLose(int a)
        {
            if (a <= 0)
                ReloadScene();
        }

        void ActivateColorGame()
        {
            PauseGame();
            _colorChooseGame.SetActive(true);
        }
    }
}
