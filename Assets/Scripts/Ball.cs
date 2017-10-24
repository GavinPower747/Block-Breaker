using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        var brickComponent = collision.gameObject.GetComponent<Brick>();

        if (brickComponent != null)
            brickComponent.Hit();
        
        if(collision.gameObject.tag == "Floor")
            GameManager.Instance.GameOver();        
    }
}
