using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuRecords : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _text.text = "Рекорд: " + YG.YandexGame.savesData.points.ToString();
    }
}
