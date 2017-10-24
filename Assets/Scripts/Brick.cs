using UnityEngine;

public class Brick : MonoBehaviour
{
    public void Hit()
    {
        Destroy(gameObject);
    }
}
