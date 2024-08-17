using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public string nextSceneName = "ShowScore";
    private UpdateCollectibleCount collectibleCountScript;

    void Start()
    {
        collectibleCountScript = FindObjectOfType<UpdateCollectibleCount>();
        if (collectibleCountScript == null)
        {
            Debug.LogError("UpdateCollectibleCount script not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectibleCountScript != null && collectibleCountScript.GetTotalCollectibles() == 0)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}