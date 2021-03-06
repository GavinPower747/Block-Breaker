﻿using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameObject MainCameraGO;
        public GameObject PaddleGO;
        public int Lives = 3;

        private Animator _cameraAnimator;
        private PlayerLauncher _playerLauncher;

        void Start()
        {
            _cameraAnimator = MainCameraGO.GetComponent<Animator>();
            _playerLauncher = PaddleGO.GetComponent<PlayerLauncher>();

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

        public bool BallLost()
        {
            if(Lives > 0)
                Lives--;

            UIManager.Instance.UpdateLivesDisplay(Lives);

            var isGameOver = Lives <= 0;

            if (isGameOver)
                GameOver();
            else
                _playerLauncher.SpawnNewBall();

            return isGameOver;
        }
    }
}