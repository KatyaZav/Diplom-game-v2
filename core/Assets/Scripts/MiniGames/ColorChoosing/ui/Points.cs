using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColorChooseGame
{
    public class Points : MonoBehaviour
    {
        [SerializeField] private Text _pointsText;
        [SerializeField] private GameObject[] goodText;
        [SerializeField] private GameObject[] badText;

        private List<GameObject> objects;

        private int points;

        public void Inizialize(int count)
        {
            points = count;
            _pointsText.text = count.ToString();
            objects = new List<GameObject>();

            GameLogic.ClickedButton += OnButtonClick;
        }

        private void OnDisable()
        {
            GameLogic.ClickedButton -= OnButtonClick;

            foreach (var ob in objects)
            {
                if (ob != null)
                    Destroy(ob);
            }
        }

        private void OnButtonClick(bool isGood)
        {
            if (isGood)
            {
                points++;
                _pointsText.text = points.ToString();

                var e = Instantiate(GetRandomText(goodText), transform);
                objects.Add(e);
                Destroy(e, 2);
            }
            else
            {
                var e = Instantiate(GetRandomText(badText), transform);
                objects.Add(e);
                Destroy(e, 2);
            }
        }

        private GameObject GetRandomText(GameObject[] obj)
        {
            return obj[Random.Range(0, obj.Length)];
        }
    }
}
