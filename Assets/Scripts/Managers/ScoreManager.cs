using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;

        [SerializeField] private int Score = 0;
        
        void Start()
        {
            if (Instance == null)
                Instance = this;
        }

        public void AddScore(int score)
        {
            Score += score;

            UIManager.Instance.UpdateScoreDisplay(Score);
        }
    }
}