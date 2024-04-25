using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    }
}
