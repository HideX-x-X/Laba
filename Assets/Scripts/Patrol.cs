using UnityEngine;

public class Patrol : InteractableObject
{
    public override void Interact()
    {
        Debug.Log("Pickup patrol!");
        Destroy(gameObject);
    }
}
