using Assets.Scripts.Managers;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int Score = 100;

    public void Hit()
    {
        ScoreManager.Instance.AddScore(Score);
        Destroy(gameObject);
    }
}
