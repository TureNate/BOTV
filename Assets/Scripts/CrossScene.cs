using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossScene : MonoBehaviour
{
    [SerializeField] public Scene gamescene;

    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void MoveToSceneStart()
    {
        SceneManager.LoadScene(1);
    }

    public void MoveToSceneMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
