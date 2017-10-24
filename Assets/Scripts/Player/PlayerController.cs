using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float ControllerInputThreshold = 0.5f;

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
                _motor.ControllerInputModifier = Input.GetAxis("Horizontal");
            }
            else
            {
                _motor.ControllerInputModifier = 0;
            }

            if(Input.GetButtonDown("Fire1"))
            {
                _launcher.LaunchBall();
            }
        }
    }
}
