using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    public UnityEngine.UI.Button retry;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        retry.onClick.AddListener(Retry);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Retry()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("World 1-1"))
        {
            SceneManager.LoadScene("World 1-1"); ;
        }

        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("World 1-2"))
        { 
            SceneManager.LoadScene("World 1-2");
        }
        
    }
}
