using UnityEngine;

namespace Level
{
    public class BaseLevel : MonoBehaviour
    {

        private static float _currentSpeed = 1f;
        private static float _previosSpeed = 1f;

        public static void RestartSpeed()
        {
            _previosSpeed = 1f;
            _currentSpeed = 1f;
        }
        public static float GetSpeed() => _currentSpeed;

        public static void AddSpeed(float speedAdd = 0.1f)
        {
            _previosSpeed = _currentSpeed;
            _currentSpeed += speedAdd;

            if (_currentSpeed > 6)
                _currentSpeed = 6;

            if (_currentSpeed < -6)
                _currentSpeed = -6;
        }

        public static void StopLevel()
        {
            _previosSpeed = _currentSpeed;
            _currentSpeed = 0;
        }
        public static void SetSpeedToPrevious()
        {
            _currentSpeed = _previosSpeed;
        }

        private void Update()
        {
            transform.Translate(transform.up * -1 * _currentSpeed * Time.deltaTime);

            if (transform.position.y <= -16f)
                Destroy(gameObject);                
        }
    }
}
