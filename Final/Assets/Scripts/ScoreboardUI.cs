using UnityEngine;
using TMPro;

public class ScoreboardUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int totalLevels = 6; // levels BEFORE hub (0–5)

    void Update()
    {
        if (ScoreManager.Instance == null) return;

        string display = "Best Times\n\n";

        for (int i = 0; i < totalLevels; i++)
        {
            float time = ScoreManager.Instance.GetBestTime(i);

            if (time >= 0)
                display += $"Level {i}: {time:F2}s\n";
            else
                display += $"Level {i}: --\n";
        }

        text.text = display;
    }
}