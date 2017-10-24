using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject MainCameraGO;
    public GameObject BallGO;

    private Animator _cameraAnimator;
    private Rigidbody2D _ballPhysics;

    void Start()
    {
        _cameraAnimator = MainCameraGO.GetComponent<Animator>();
        _ballPhysics = BallGO.GetComponent<Rigidbody2D>();

        if (Instance == null)
            Instance = this;
    }

    public void GameOver()
    {
        _ballPhysics.velocity = Vector2.zero;
        _cameraAnimator.SetTrigger("GameOver");
    }

    public void RestartGame()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
