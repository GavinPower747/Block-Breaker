using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float ControllerInputThreshold = 0.2f;
        public int Lives = 3;

        public GameObject BallPrefab;

        private PlayerMotor _motor;
        private PlayerLauncher _launcher;

        void Start()
        {
            _motor = GetComponent<PlayerMotor>();
            _launcher = GetComponent<PlayerLauncher>();
        }

        void Update()
        {
            if(Mathf.Abs(Input.GetAxis("Horizontal")) > ControllerInputThreshold)
            {
                _motor.MovePaddle(Input.GetAxis("Horizontal"));
            }
            else
            {
                _motor.MovePaddle(0);
            }

            if(Input.GetButtonDown("Fire1"))
            {
                _launcher.LaunchBall();
            }
        }

        public bool Die()
        {
            var isGameOver = GameManager.Instance.PlayerDied();

            if(!isGameOver)
            {
                Lives--;
                
                var newBall = Instantiate(BallPrefab, transform.position, transform.rotation, transform);
                newBall.transform.localPosition = new Vector3(0, 1.4f, 0);
                _launcher.BallGO = newBall.gameObject;
            }

            return isGameOver;
        }
    }
}
