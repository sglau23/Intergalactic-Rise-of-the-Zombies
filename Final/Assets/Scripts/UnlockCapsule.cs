using UnityEngine;

public class UnlockCapsule : MonoBehaviour
{
    [Header("Buttons to Activate")]
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public int currCapsuleIndex = 1;
    public GameObject text;
    public GameObject text2;

    public void OnClick()
    {
        if (GlobalVariables.capsuleCount[currCapsuleIndex - 1] >= 100)
        {
            GlobalVariables.capsuleCount[currCapsuleIndex - 1] -= 100;
            if (button1) button1.SetActive(true);
            if (button2) button2.SetActive(true);
            if (button3) button3.SetActive(true);
            if (text) text.SetActive(false);
            if (text2) text2.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}