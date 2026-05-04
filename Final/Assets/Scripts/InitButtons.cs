using UnityEngine;

public class InitButtons : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDeactivate = new GameObject[36];
    [SerializeField] private GameObject[] objectzToDeactivate = new GameObject[12];

    void Start()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
                obj.SetActive(false);
        }
        foreach (GameObject obj in objectzToDeactivate)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }
}
