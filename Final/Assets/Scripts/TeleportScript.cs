using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform[] levelPoints;
    public int hubIndex =6; // index for main area
    private int currLevel = -1; 
    public void TeleportToLevel(int index)
{
    if (index < 0 || index >= levelPoints.Length)
    {
        return; 
    }
    Transform target = levelPoints[index];

        // Preserve headset height offset
    Vector3 offset = transform.position - Camera.main.transform.position;

    transform.position = target.position + offset;
    if(index != hubIndex){
        currLevel = index; 
        if(TimeManager.Instance != null){
            TimeManager.Instance.StartTimer(); 
        }
    }
    else if (currLevel != -1){
        if (TimeManager.Instance != null && ScoreManager.Instance != null)
            {
                float time = TimeManager.Instance.StopTimer();
                ScoreManager.Instance.SaveTime(currLevel, time);

                Debug.Log($"Level {currLevel} completed in {time:F2}s");
            }

            currLevel = -1;
    }
}
}
