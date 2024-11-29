using UnityEngine;
using UnityEngine.SceneManagement;

public class TapSceneChange : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Name of the scene to load

    void Update()
    {
        // Detect screen tap for mobile or mouse click for PC
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad); // Load the specified scene
        }
        else
        {
            Debug.LogError("Scene name is not set. Please assign a scene name in the Inspector.");
        }
    }
}
