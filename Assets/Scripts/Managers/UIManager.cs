using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        public GameObject ScoreDisplayGO;
        public GameObject LivesDisplayGO;

        private Text _scoreText;
        private Text _livesText;

        void Start()
        {
            _scoreText = ScoreDisplayGO.GetComponent<Text>();
            _livesText = LivesDisplayGO.GetComponent<Text>();

            if (Instance == null)
                Instance = this;
        }

        public void InitUI(int lives)
        {
            _scoreText.text = "0";
            _livesText.text = lives.ToString();
        }

        public void UpdateScoreDisplay(int newScore)
        {
            _scoreText.text = newScore.ToString();
        }

        public void UpdateLivesDisplay(int newLives)
        {
            _livesText.text = newLives.ToString();
        }
    }
}
