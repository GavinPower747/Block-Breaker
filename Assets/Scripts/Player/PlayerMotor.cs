using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMotor : MonoBehaviour
    {
        public int MaxSpeed = 10;
        public float InputModifier = 0;
        
        private Rigidbody2D _rigidBody;

        void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            _rigidBody.velocity = new Vector2(InputModifier * MaxSpeed, 0);
        }
    }
}
