using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using YG;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnEnable()
    {
        _text.text = Points.Instance.GetPoint().ToString("f1");

        if (YG.YandexGame.savesData.points < Points.Instance.GetPoint())
        {
            YandexGame.savesData.points = (int)Points.Instance.GetPoint();
            YandexGame.NewLeaderboardScores("TopRecordCountPlayers", (int)Points.Instance.GetPoint());
            YandexGame.SaveProgress();
        }
    }
}
