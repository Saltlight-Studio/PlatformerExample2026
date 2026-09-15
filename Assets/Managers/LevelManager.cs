using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] string nextLevel = "";

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
    public void ResetLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
