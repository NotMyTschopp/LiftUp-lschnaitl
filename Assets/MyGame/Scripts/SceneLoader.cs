using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{    
    public void SwitchToScene (string name)
    {
        SceneManager.LoadScene(name);
    }
}
