using UnityEngine;

public class CapsuleUpg : MonoBehaviour
{
    public int capsuleIndex = 0;
    public AudioSource clickSound;

    public void OnClick()
    {
        if (GlobalVariables.capsuleCount[capsuleIndex] >= GlobalVariables.capsuleGens[capsuleIndex].upgradePrice)
        {
            GlobalVariables.capsuleCount[capsuleIndex] -= GlobalVariables.capsuleGens[capsuleIndex].upgradePrice;
            GlobalVariables.capsuleGens[capsuleIndex].ps *= 2;
            GlobalVariables.capsuleGens[capsuleIndex].upgradePrice = Mathf.RoundToInt(GlobalVariables.capsuleGens[capsuleIndex].upgradePrice * 20f);
            GlobalVariables.UpdateProduction();
            clickSound.Play();
        }
    }
}
