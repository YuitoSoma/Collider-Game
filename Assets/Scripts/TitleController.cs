using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public void OnStartButtonCliced()
    {
        SceneManager.LoadScene("Main");
    }
}
