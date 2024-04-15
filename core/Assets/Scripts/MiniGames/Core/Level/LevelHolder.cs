using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class LevelHolder : MonoBehaviour
    {
        [SerializeField] List<GameObject> _leftLane;
        [SerializeField] List<GameObject> _rightLane;
        [SerializeField] List<GameObject> _bothLane;

        private List<GameObject> _currentLaneMassive;

        public GameObject GetRandomLine()
        {
            var rnd = Random.Range(0, _currentLaneMassive.Count);
            return _currentLaneMassive[rnd];
        }

        public void Init()
        {
            _bothLane.AddRange(_leftLane);
            _bothLane.AddRange(_rightLane);

            _currentLaneMassive = _bothLane;
        }

        public void Changelane(RoadLine lane)
        {
            switch (lane)
            {
                case RoadLine.left:
                    _currentLaneMassive = _leftLane;
                    break;
                case RoadLine.right:
                    _currentLaneMassive = _rightLane;
                    break;
                case RoadLine.both:
                    _currentLaneMassive = _bothLane;
                    break;
            }
        }
    }

    public enum RoadLine
    {
        left = 0,
        right = 1,
        both = 2
    }
}
