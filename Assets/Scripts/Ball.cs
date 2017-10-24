using Assets.Scripts.Player;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float GradualFall = 0.03f;

    private PlayerController _player;
    private Rigidbody2D _rigidBody;

    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _rigidBody.velocity.y - GradualFall); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var brickComponent = collision.gameObject.GetComponent<Brick>();

        if (brickComponent != null)
            brickComponent.Hit();

        if (collision.gameObject.tag == "Floor")
        {
            var gameOver = _player.Die();

            if (!gameOver)
                Destroy(gameObject);
            else
                _rigidBody.velocity = Vector2.zero;
        }
    }
}
