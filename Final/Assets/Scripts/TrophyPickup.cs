using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrophyPickup : MonoBehaviour
{
    public enum TrophyType
    {
        Bronze,
        Silver,
        Gold
    }

    public TrophyType trophyType;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (trophyType == TrophyType.Bronze)
        {
            GlobalVariables.bronzeTrophyGrabbed = true;
        }
        else if (trophyType == TrophyType.Silver)
        {
            GlobalVariables.silverTrophyGrabbed = true;
        }
        else if (trophyType == TrophyType.Gold)
        {
            GlobalVariables.goldTrophyGrabbed = true;
        }

        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }
}