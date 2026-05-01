using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static TimeManager Instance; 
    private float StartTime; 
    private bool timing = false; 
    void Awake(){
        Instance = this; 
    }
    public void StartTimer(){
        StartTime = Time.time; 
        timing = true; 
    }
    public float StopTimer(){
        if(!timing){
            return 0f;
        }
        float elapsed = Time.time - StartTime; 
        timing = false; 
        return elapsed;
    }
    public float GetCurrentTime(){
        if(!timing){
            return 0f; 
        }
        return Time.time - StartTime; 
    }

}
