using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMotor : MonoBehaviour
    {
        public Vector2 Velocity;

        public float ControllerInputModifier = 0;
        public float MaxSpeed = 10f;
        public float TimeToMaxSpeed = 0.333f;
        public float CurrentSpeed = 0f;
        public float StopDistance = 0.333f;
        public float MinDistanceFromObject = 0.02f;

        private BoxCollider2D _collider;

        void Start()
        {
            _collider = this.GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            UpdateVelocity();
            MovePaddle();
        }

        private void UpdateVelocity()
        {            
            var speed = CurrentSpeed = Mathf.Abs(Velocity.x);
            var maxSpeed = MaxSpeed;
            var absoluteMod = Mathf.Abs(ControllerInputModifier);
            var limit = maxSpeed * absoluteMod;

            if (absoluteMod > 0)
            {
                if(IsDecelerating(speed))
                {
                    float deceleration = Mathf.Pow(maxSpeed, 2f) / (StopDistance * 2);

                    speed -= deceleration * Time.deltaTime;

                    if (speed > limit)
                        speed = limit;
                }
                else
                {
                    float acceleration = absoluteMod * (MaxSpeed / TimeToMaxSpeed);
                    
                    speed += acceleration * Time.deltaTime;

                    if (speed > limit)
                        speed = limit;
                }
            }
            else if(Velocity.x != 0)
            {
                float deceleration = Mathf.Pow(maxSpeed, 2f) / (StopDistance * 2);

                speed -= deceleration * Time.deltaTime;

                if (speed > limit)
                    speed = limit;
            }

            Velocity = GetMovementDirection(speed) * Mathf.Abs(speed);
        }

        private void MovePaddle()
        {
            var velocity3 = (Vector3)Velocity;

            var currentPosition = _collider.bounds.center;
            var newPosition = currentPosition + (velocity3 * Time.deltaTime);
            var toNew = newPosition - currentPosition;

            float distance = toNew.magnitude;

            RaycastHit2D hit = Physics2D.Raycast(currentPosition, toNew / distance, distance);

            transform.position = newPosition;
        }

        private Vector3 GetMovementDirection(float speed)
        {
            var movementDirection = Vector3.zero;
            
            var sign = Mathf.Sign(ControllerInputModifier);

            movementDirection.x = sign;

            return movementDirection;
        }

        private bool IsDecelerating(float speed)
        {
            var absoluteMod = Mathf.Abs(ControllerInputModifier);

            return (
                speed > 0 && speed > absoluteMod * MaxSpeed || 
                speed > 0 && absoluteMod < 0
            );
        }
    }
}
