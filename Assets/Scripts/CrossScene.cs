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

    public void MoveToScene()
    {
        SceneManager.LoadScene(1);
    }
}
