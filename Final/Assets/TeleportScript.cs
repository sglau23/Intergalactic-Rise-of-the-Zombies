using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform[] levelPoints;

    public void TeleportToLevel(int index)
{
    if (index >= 0 && index < levelPoints.Length)
    {
        Transform target = levelPoints[index];

        // Preserve headset height offset
        Vector3 offset = transform.position - Camera.main.transform.position;

        transform.position = target.position + offset;
    }
}
}
