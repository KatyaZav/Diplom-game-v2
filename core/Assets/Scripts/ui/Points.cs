using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] private Text _pointsText;
    [SerializeField] private GameObject[] goodText;
    [SerializeField] private GameObject[] badText;

    private int points;

    public void Inizialize(int count)
    {
        points = count;
        _pointsText.text = count.ToString();

        GameLogic.ClickedButton += OnButtonClick;
    }

    private void OnDisable()
    {
        GameLogic.ClickedButton -= OnButtonClick;        
    }

    private void OnButtonClick(bool isGood)
    {
        if (isGood)
        {
            points++;
            _pointsText.text = points.ToString();

            Destroy(Instantiate(GetRandomText(goodText), transform), 2);
        }
        else
            Destroy(Instantiate(GetRandomText(badText), transform), 2);
    }

    private GameObject GetRandomText(GameObject[] obj)
    {
        return obj[Random.Range(0, obj.Length)];
    }
}
