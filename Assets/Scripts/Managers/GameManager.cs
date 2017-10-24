using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameObject MainCameraGO;
        public int Lives = 3;

        private Animator _cameraAnimator;

        void Start()
        {
            _cameraAnimator = MainCameraGO.GetComponent<Animator>();

            UIManager.Instance.InitUI(Lives);
    
            if (Instance == null)
                Instance = this;
        }

        public void GameOver()
        {
            _cameraAnimator.SetTrigger("GameOver");
        }

        public void RestartGame()
        {
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }

        public bool PlayerDied()
        {
            Lives--;

            UIManager.Instance.UpdateLivesDisplay(Lives);

            var isGameOver = Lives <= 0;

            if (isGameOver)
                GameOver();

            return isGameOver;
        }
    }
}