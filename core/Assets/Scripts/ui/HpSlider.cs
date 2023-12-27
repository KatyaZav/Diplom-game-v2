using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSlider : Slider
{
    [SerializeField] private float _costOfMistake;  
    public override void Inizialize(int maxValue) 
    {
        GameLogic.ClickedButton += OnClick;

        base.Inizialize(maxValue);
    }

    private void OnDisable()
    {
        GameLogic.ClickedButton -= OnClick;        
    }

    void OnClick(bool isGood)
    {
        if (isGood)
            AddTime(_costOfMistake);
        else
            RemoveTime(_costOfMistake);
    }
}
