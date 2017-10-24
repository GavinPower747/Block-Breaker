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
        
        private Rigidbody2D _paddleRigidBody;

        void Start()
        {
            _paddleRigidBody = this.GetComponent<Rigidbody2D>();
        }

        public void LaunchBall()
        {
            if(HasBall)
            {
                var velocity = _paddleRigidBody.velocity;
                var ballPhysics = BallGO.GetComponent<Rigidbody2D>();

                BallGO.transform.SetParent(null);
                ballPhysics.simulated = true;
                ballPhysics.AddForce(new Vector2(velocity.x, LaunchForce));

                BallGO = null;
            }
        }
    }
}
