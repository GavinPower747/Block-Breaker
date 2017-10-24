using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerLauncher : MonoBehaviour
    {
        public GameObject BallGO;
        public int LaunchForce = 200;

        public bool HasBall
        {
            get
            {
                return BallGO != null;
            }
        }

        private Rigidbody2D _ballRidgedBody;
        private PlayerMotor _motor;

        void Start()
        {
            _ballRidgedBody = BallGO.GetComponent<Rigidbody2D>();
            _motor = this.GetComponent<PlayerMotor>();
        }

        public void LaunchBall()
        {
            if(HasBall)
            {
                var velocity = _motor.Velocity;

                BallGO.transform.SetParent(null);
                _ballRidgedBody.AddForce(new Vector2(velocity.x, LaunchForce));
                BallGO = null;
            }
        }
    }
}
