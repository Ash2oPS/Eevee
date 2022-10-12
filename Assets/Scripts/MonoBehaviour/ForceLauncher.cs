using UnityEngine;
using UnityEngine.SceneManagement;

public class ForceLauncher : MonoBehaviour
{
    private void Start()
    {
        if (PlayerManager.Instance == null)
        {
            SceneManager.LoadScene("Launcher");
            return;
        }

        Destroy(gameObject);
    }
}