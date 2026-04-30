using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform[] levelPoints;

    public void TeleportToLevel(int index)
    {
        if (index >= 0 && index < levelPoints.Length)
        {
            transform.position = levelPoints[index].position;
        }
    }
}
