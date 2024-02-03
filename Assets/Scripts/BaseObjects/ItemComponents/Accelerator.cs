using UnityEngine;

namespace BounceFactory.BaseObjects.ItemComponents
{
    public class Accelerator
    {
        private float _accelerationAmount;
        private Vector3 _direction;

        public Accelerator(float accelerationAmount, Vector3 direction)
        {
            _accelerationAmount = accelerationAmount;
            _direction = direction == null ? Vector3.one : direction;
        }

        public void SetAcceleration(Rigidbody2D rigidbody)
        {
            rigidbody.velocity = _direction * _accelerationAmount;
        }
    }
}