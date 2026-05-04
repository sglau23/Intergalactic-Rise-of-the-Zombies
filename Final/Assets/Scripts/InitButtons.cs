using UnityEngine;

public class InitButtons : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDeactivate = new GameObject[36];

    void Start()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }
}
