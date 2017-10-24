using UnityEngine;

namespace Assets.Scripts
{
    public class CameraEventDispatcher : MonoBehaviour
    {
        public void RestartGame()
        {
            GameManager.Instance.RestartGame();
        }
    }
}
