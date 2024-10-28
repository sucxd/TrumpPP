using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawerHandle : MonoBehaviour
{
    private DrawerLimit drawerLimit;

    private void Start()
    {
        // Assuming the DrawerLimit script is on the parent drawer
        drawerLimit = GetComponentInParent<DrawerLimit>(); 
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        drawerLimit.StartInteracting(); // Start interacting with the drawer
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        drawerLimit.StopInteracting(); // Stop interacting with the drawer
    }
}
