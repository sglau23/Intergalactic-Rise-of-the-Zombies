using UnityEngine;

public class UnlockCapsule : MonoBehaviour
{
    [Header("Buttons to Activate")]
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public void OnClick()
    {
        if (button1) button1.SetActive(true);
        if (button2) button2.SetActive(true);
        if (button3) button3.SetActive(true);
    }
}