using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform[] levelPoints;
    public int hubIndex = 5;
    public AudioSource[] levelSounds; // One clip per level index
    
    // Static so it survives if this object is destroyed/recreated
    private static int currLevel = -1;

    public void TeleportToLevel(int index)
    {
        Debug.Log($"TeleportToLevel called: index={index}, hubIndex={hubIndex}, currLevel={currLevel}");
        
        if (index < 0 || index >= levelPoints.Length)
        {
            Debug.LogWarning("Invalid level index: " + index);
            return;
        }

        Transform target = levelPoints[index];
        Vector3 offset = transform.position - Camera.main.transform.position;
        transform.position = target.position + offset;
        if (levelSounds != null && index < levelSounds.Length && levelSounds[index] != null)
        {
            levelSounds[index].Play();
        }

        if (index != hubIndex)
        {
            currLevel = index;
            Debug.Log("Started timer for level: " + currLevel);
            if (TimeManager.Instance != null)
                TimeManager.Instance.StartTimer();
            else
                Debug.LogError("TimeManager.Instance is NULL");
        }
        else if (currLevel != -1)
        {
            Debug.Log("Returning to hub, saving score for level: " + currLevel);
            
            if (TimeManager.Instance == null)
                Debug.LogError("TimeManager.Instance is NULL on return");
            if (ScoreManager.Instance == null)
                Debug.LogError("ScoreManager.Instance is NULL on return");

            if (TimeManager.Instance != null && ScoreManager.Instance != null)
            {
                float time = TimeManager.Instance.StopTimer();
                ScoreManager.Instance.SaveTime(currLevel, time);
                Debug.Log($"Saved: Level {currLevel} = {time:F2}s");
            }

            currLevel = -1;
        }
        else
        {
            // currLevel was -1 when returning to hub
            Debug.LogWarning("Returned to hub but currLevel was -1 — score not saved. Did the object reset?");
        }
    }
}