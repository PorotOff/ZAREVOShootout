using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour, INavigatable
{
    [SerializeField] private int sceneIndex;

    public void Navigate()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}