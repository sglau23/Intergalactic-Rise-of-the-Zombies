using UnityEngine;

public class TrophyManager : MonoBehaviour
{
    public GameObject bronzeTrophy;
    public GameObject silverTrophy;
    public GameObject goldTrophy;

    void Start()
    {
        UpdateTrophies();
    }

    void Update()
    {
        UpdateTrophies();
    }

    void UpdateTrophies()
    {
        bronzeTrophy.SetActive(GlobalVariables.bronzeTrophyGrabbed);
        silverTrophy.SetActive(GlobalVariables.silverTrophyGrabbed);
        goldTrophy.SetActive(GlobalVariables.goldTrophyGrabbed);
    }
}
