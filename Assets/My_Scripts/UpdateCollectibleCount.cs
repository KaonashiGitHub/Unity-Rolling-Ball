using UnityEngine;
using TMPro;

public class UpdateCollectibleCount : MonoBehaviour
{
    private TextMeshProUGUI collectibleText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();
        if (collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }
        UpdateCollectibleDisplay(); // Initial update on start
    }

    void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        int totalCollectibles = FindObjectsOfType<Collectible>().Length;

        // Update the collectible count display
        collectibleText.text = $"{totalCollectibles}";
    }

    // Public method to get the total number of collectibles
    public int GetTotalCollectibles()
    {
        return FindObjectsOfType<Collectible>().Length;
    }
}