using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bubbles;


public class EyeUI : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] GeneratorSideType _slideType;

    public void Inizialize()
    {
        Generator.ChangedTask += ChangeEye;
    }

    private void OnDisable()
    {
        Generator.ChangedTask -= ChangeEye;
    }

    private void ChangeEye(GeneratorSideType type, ColorTypes[] color, IChooseble method)
    {
        if (_slideType == type)
        {
            var colorType = color[0].color;

            Debug.Log("eye" + method.Type.ToString() + " " + type);

            //var ansMethod = ColorsHolder.DictionaryMethods[method.Type];

            foreach (var y in ColorsHolder.Instance.EyesAnswerTypes)
            {
                if (y.ChoseType == method.Type)
                {
                    Debug.Log(method.Type.ToString() + " " + _slideType);

                    foreach (var col in y.Colors)
                    {
                        if (col.color == colorType)
                        {
                            _image.sprite = col.image;
                            return;
                        }
                    }
                }
            }
        }
    }

    private void OnValidate()
    {
        _image = GetComponent<Image>();
    }
}
