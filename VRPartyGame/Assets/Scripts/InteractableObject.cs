using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public void OnBecameInvisible()
    {
        // change the color of the object to white
        GetComponent<Renderer>().material.color = Color.red;
    }
}
