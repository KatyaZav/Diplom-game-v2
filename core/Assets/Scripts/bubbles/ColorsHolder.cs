using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubbles
{
    public class ColorsHolder : MonoBehaviour
    {
        public static ColorsHolder Instance;

        public static Dictionary<ChosesType, IChooseble> DictionaryMethods = new Dictionary<ChosesType, IChooseble>()
        {
            {ChosesType.InverseChoose, new InverseChoose()},
            {ChosesType.EverythingChoose, new EverythingChoose()},
            {ChosesType.NullChoose, new NullChoose()},
            {ChosesType.SimpleChoose, new SimpleChoose()},
        };

        [SerializeField] private BublesTypes[] _eyesAnswerTypes;
        [SerializeField] private ColorTypes[] _bublesTypes;
        [SerializeField] private ColorTypes _zeroBubble;

        public BublesTypes[] EyesAnswerTypes { get => _eyesAnswerTypes; }
        public ColorTypes[] BublesTypes { get => _bublesTypes; }
        public ColorTypes ZeroBubble { get => _zeroBubble; }

        private void Awake()
        {
            Instance ??= this;
        }
    }

    [System.Serializable]
    public class BublesTypes
    {
        public string name;
        public ChosesType ChoseType;
        public ColorTypes[] Colors;
        public int Probability;
    }

    [System.Serializable]
    public class ColorTypes
    {
        public string name;
        public ColorType color;
        public Sprite image;

        public GameObject goodEffect;
    }
}

public enum ChosesType
{
    InverseChoose,
    EverythingChoose,
    NullChoose,
    SimpleChoose
}
