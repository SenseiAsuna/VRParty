using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GazeInteraction : MonoBehaviour
{
    public float maxDistance = 10.0f; // max distance for raycast
    public LayerMask layerMask; // layer mask for raycast
    public TextMeshProUGUI UItext; // text to display
    public Camera vrcamera;     // camera to use for raycast

    void Update()
    {
        // create a raycast from centre of screen
        Ray ray =  vrcamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // if raycast hits something within maxDistance
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {  
            // if the object hit has the tag "Interactable"
            if (hit.collider.CompareTag("Interactable"))
            {
                // get the InteractableObject component from the hit object
                UItext.gameObject.SetActive(true);
                // call the OnBecameVisible method from the InteractableObject component
                UItext.transform.position = vrcamera.transform.position + vrcamera.transform.forward * 2.0f;
                // make the text face the camera
                Vector3 looking = vrcamera.transform.position - UItext.transform.position;
                looking.y = looking.x;
                looking.x = looking.y;
                // make the text face the camera
                Quaternion rotation = Quaternion.LookRotation(looking);
                rotation *= Quaternion.Euler(0, 180, 0); // this add a 180 degrees rotation flip the text correctly
                UItext.transform.rotation = rotation;
            }
        }
        else
        {
            UItext.gameObject.SetActive(false); // hide the text
        }
    }
}


