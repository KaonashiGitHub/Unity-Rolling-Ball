using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float time;
    private bool isGameFinished = false;

    void Start()
    {
        time = 0;
    }

    void Update()
    {
        if (!isGameFinished)
        {
            time += Time.deltaTime;
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int seconds = Mathf.FloorToInt(time);
        timerText.text = string.Format("{0:D2}", seconds);
    }

    public void FinishGame()
    {
        isGameFinished = true;

        SceneManager.LoadScene("ShowScore");
    }
}
