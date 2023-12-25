using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubbles
{
    public class ColorsHolder : MonoBehaviour
    {
        public BublesTypes[] EyesAnswerTypes;
        public ColorTypes[] BublesTypes;
    }

    [System.Serializable]
    public class BublesTypes
    {
        public string name;
        public ChosesType ChoseType;
        public ColorTypes[] Colors;
    }

    [System.Serializable]
    public class ColorTypes
    {
        public string name;
        public ColorType color;
        public Sprite image;
    }
}

public enum ChosesType
{
    InverseChoose,
    EverythingChoose,
    NullChoose,
    SimpleChoose
}
