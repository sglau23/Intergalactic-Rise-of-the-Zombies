using UnityEngine;

public class CapsuleClick : MonoBehaviour
{

    public int capsuleIndex = 0;
    public AudioSource clickSound;

    public void OnClick()
    {
        GlobalVariables.capsuleCount[capsuleIndex]++;
        if (clickSound != null)
        {
            clickSound.Play();
        }
    }
}