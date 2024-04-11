using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level {
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] LevelHolder _levelHolder;

        public void Init()
        {
            GenerateZone.NeedGenerateNewZone += GenerateLevel;
        }

        private void OnDisable()
        {
            GenerateZone.NeedGenerateNewZone -= GenerateLevel;            
        }

        private void GenerateLevel(Transform parent)
        {
            Vector3 vector = new Vector3(parent.position.x, parent.position.y + parent.lossyScale.y / 2, parent.position.z);
            Instantiate(_levelHolder.GetRandomLine(), vector, Quaternion.identity);            
        }
    }    
}
