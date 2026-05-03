using UnityEngine;
using System.Collections.Generic;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private Dictionary<int, float> bestTimes = new Dictionary<int, float>();

    void Awake()
    {
        Instance = this;
    }

    public void SaveTime(int level, float time)
    {
        if (!bestTimes.ContainsKey(level) || time < bestTimes[level])
        {
            bestTimes[level] = time;
            Debug.Log("New best time for level " + level + ": " + time);
        }
    }

    public float GetBestTime(int level)
    {
        if (bestTimes.ContainsKey(level))
            return bestTimes[level];

        return -1f;
    }
}
