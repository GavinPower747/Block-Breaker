using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMotor : MonoBehaviour
    {

        [SerializeField] private float _maxSpeed;
        [SerializeField] private Rigidbody2D _rigidBody;

        void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        public void MovePaddle(float move)
        {
            _rigidBody.velocity = new Vector2(move * _maxSpeed, 0);
        }
    }
}
