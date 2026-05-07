using System.Reflection;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Attach this to a ball (XRGrabInteractable) object.
/// When grabbed with the RIGHT hand, multiplies the player's jump height
/// by jumpMultiplier. Uses reflection to find jumpHeight on the Jump
/// locomotion component, so it works across all XRIT versions.
///
/// SETUP:
///   1. Add this script and an XRGrabInteractable to your ball GameObject.
///   2. In the Inspector, drag your "Jump" GameObject (XR Origin > Locomotion > Jump)
///      into the Jump Provider Object field.
///   3. Adjust Jump Multiplier as needed.
/// </summary>
[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
public class JumpBoostBall : MonoBehaviour
{
    [Header("Jump Boost Settings")]
    [Tooltip("Multiplier applied to the player's jump height when held in the right hand.")]
    public float jumpMultiplier = 2f;

    [Header("Jump Provider")]
    [Tooltip("Drag the 'Jump' GameObject from XR Origin > Locomotion > Jump here.")]
    [SerializeField] private GameObject jumpProviderObject;

    [Header("Right Hand Controller Name")]
    [Tooltip("Must match the name of your right hand controller GameObject in the hierarchy.")]
    [SerializeField] private string rightHandControllerName = "Right Controller";

    // Internal
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private Component jumpComponent;
    private PropertyInfo jumpHeightProperty;
    private float originalJumpHeight;
    private bool boostActive = false;

    // -----------------------------------------------------------------------
    // Unity Lifecycle
    // -----------------------------------------------------------------------

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        ResolveJumpProvider();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    // -----------------------------------------------------------------------
    // Grab Events
    // -----------------------------------------------------------------------

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (!IsRightHand(args.interactorObject)) return;
        if (jumpHeightProperty == null) return;

        jumpHeightProperty.SetValue(jumpComponent, originalJumpHeight * jumpMultiplier);
        boostActive = true;
        Debug.Log("[JumpBoostBall] Jump boost ACTIVATED — height: " + (originalJumpHeight * jumpMultiplier));
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        if (!boostActive) return;
        if (jumpHeightProperty == null) return;

        jumpHeightProperty.SetValue(jumpComponent, originalJumpHeight);
        boostActive = false;
        Debug.Log("[JumpBoostBall] Jump boost DEACTIVATED — height restored to: " + originalJumpHeight);
    }

    // -----------------------------------------------------------------------
    // Helpers
    // -----------------------------------------------------------------------

    /// <summary>
    /// Uses reflection to find a 'jumpHeight' property on any component
    /// attached to the Jump provider GameObject — works across XRIT versions.
    /// </summary>
    private void ResolveJumpProvider()
    {
        if (jumpProviderObject == null)
        {
            Debug.LogWarning("[JumpBoostBall] No Jump Provider Object assigned. " +
                             "Drag your 'Jump' GameObject into the Inspector field.");
            return;
        }

        foreach (Component comp in jumpProviderObject.GetComponents<Component>())
        {
            PropertyInfo prop = comp.GetType().GetProperty(
                "jumpHeight",
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
            );

            if (prop != null && prop.PropertyType == typeof(float))
            {
                jumpComponent = comp;
                jumpHeightProperty = prop;
                originalJumpHeight = (float)prop.GetValue(comp);
                Debug.Log("[JumpBoostBall] Found jumpHeight on: " + comp.GetType().Name +
                          " | Base height: " + originalJumpHeight);
                return;
            }
        }

        Debug.LogWarning("[JumpBoostBall] Could not find a 'jumpHeight' property on any component " +
                         "attached to '" + jumpProviderObject.name + "'. " +
                         "Make sure the correct GameObject is assigned.");
    }

    private bool IsRightHand(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRInteractor interactor)
    {
        return interactor.transform.gameObject.name
               .IndexOf(rightHandControllerName, System.StringComparison.OrdinalIgnoreCase) >= 0;
    }
}