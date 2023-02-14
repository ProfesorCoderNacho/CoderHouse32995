using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("Clase10");
    }
}