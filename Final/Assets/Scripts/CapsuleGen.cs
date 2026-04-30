using UnityEngine;

public class CapsuleGen : MonoBehaviour
{
    public int capsuleIndex = 0;
    public AudioSource clickSound;

    public void OnClick() 
    {
        if (GlobalVariables.capsuleCount[capsuleIndex] >= GlobalVariables.capsuleGens[capsuleIndex].price)
        {
            GlobalVariables.capsuleCount[capsuleIndex] -= GlobalVariables.capsuleGens[capsuleIndex].price;
            GlobalVariables.capsuleGens[capsuleIndex].count++;
            GlobalVariables.UpdateProduction();
            clickSound.Play();
        }
    }
}
