using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private const string SceneName = "SampleScene";

    private void Awake()
    {
        _bird.Dead += ReloadScene;
    }

    private void OnDisable()
    {
        _bird.Dead -= ReloadScene;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
