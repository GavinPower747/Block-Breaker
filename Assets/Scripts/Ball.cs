using Assets.Scripts.Managers;
using Assets.Scripts.Player;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private PlayerController _player;
    private Rigidbody2D _rigidBody;

    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var brickComponent = collision.gameObject.GetComponent<Brick>();

        if (brickComponent != null)
            brickComponent.Hit();

        if (collision.gameObject.tag == "Floor")
        {
            var gameOver = GameManager.Instance.BallLost();

            if (!gameOver)
                Destroy(gameObject);
            else
                _rigidBody.velocity = Vector2.zero;
        }
    }
}
