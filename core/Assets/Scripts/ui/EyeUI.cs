using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bubbles;


public class EyeUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private GeneratorSideType _slideType;
    [SerializeField] private Animator _anim;

    public void Inizialize()
    {
        _anim.SetTrigger("start");
        
        Generator.ChangedTask += ChangeEye;
        GameLogic.ChangeColorAnimation += DisactivateButtons;
    }

    private void OnDisable()
    {
        Generator.ChangedTask -= ChangeEye;
        GameLogic.ChangeColorAnimation -= DisactivateButtons;
    }

    private void DisactivateButtons(bool pause, GeneratorSideType type)
    {
        if (_slideType != type)
            return;

        if (pause)
            _anim.SetTrigger("off");
        else
            _anim.SetTrigger("on");
    }

    private void ChangeEye(GeneratorSideType type, ColorTypes[] color, IChooseble method)
    {
        if (_slideType == type)
        {
            ColorType colorType = 0; 

            foreach (var col in color)
            {
                colorType += ((byte)col.color);
            }

            //var ansMethod = ColorsHolder.DictionaryMethods[method.Type];

            foreach (var y in ColorsHolder.Instance.EyesAnswerTypes)
            {
                if (y.ChoseType == method.Type)
                {
                    //Debug.Log(method.Type.ToString() + " " + _slideType);

                    foreach (var col in y.Colors)
                    {
                        //Debug.Log(col.color.ToString());

                        if (col.color.HasFlag(colorType))
                        {
                            _image.sprite = col.image;
                            return;
                        }
                    }
                    break;
                }
            }

            Debug.LogError("Didn't found chose type");
        }
    }

    private void OnValidate()
    {
        _image = GetComponent<Image>();
        _anim = GetComponent<Animator>();
    }
}
