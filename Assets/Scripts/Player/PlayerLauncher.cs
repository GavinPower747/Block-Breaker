using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerLauncher : MonoBehaviour
    {
        public int LaunchForce = 200;

        public GameObject BallPrefab;
        
        private Rigidbody2D _paddleRigidBody;
        private const string BallName = "Ball";

        void Start()
        {
            _paddleRigidBody = this.GetComponent<Rigidbody2D>();
        }

        public void LaunchBall()
        {
            var ball = transform.Find(BallName);

            if(ball != null)
            {
                var velocity = _paddleRigidBody.velocity;
                var ballPhysics = ball.GetComponent<Rigidbody2D>();

                var xForce = 
                    Mathf.Abs(velocity.x) > 0 
                    ? (Mathf.Abs(velocity.x) + LaunchForce) * Mathf.Sign(velocity.x) 
                    : 0;

                ball.transform.SetParent(null);
                ballPhysics.simulated = true;
                ballPhysics.AddForce(new Vector2(xForce, LaunchForce));
            }
        }

        public void SpawnNewBall()
        {
            var newBall = Instantiate(BallPrefab, transform.position, transform.rotation, transform);
            newBall.transform.localPosition = new Vector3(0, 1.4f, 0);
            newBall.name = BallName;
        }

    }
}
