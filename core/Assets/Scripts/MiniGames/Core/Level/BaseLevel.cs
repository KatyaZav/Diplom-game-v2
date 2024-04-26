using UnityEngine;

namespace Level
{
    public class BaseLevel : MonoBehaviour
    {

        private static float _currentSpeed;
        private static float _previosSpeed;

        public static void RestartSpeed()
        {
            _previosSpeed = 3f;
            _currentSpeed = 3f;
        }
        public static float GetSpeed() => _currentSpeed;

        public static void AddSpeed(float speedAdd = 0.1f)
        {
            _previosSpeed = _currentSpeed;
            _currentSpeed += speedAdd;

            if (_currentSpeed > 7)
                _currentSpeed = 7;

            if (_currentSpeed < -7)
                _currentSpeed = -7;
        }

        public static void StopLevel()
        {
            _previosSpeed = _currentSpeed;
            _currentSpeed = 0;
            //Debug.Log("Stop" + _previosSpeed);
        }
        public static void SetSpeedToPrevious()
        {
            //Debug.Log("Previous" + _previosSpeed);
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
