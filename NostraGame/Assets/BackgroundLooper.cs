using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float backgroundWidth; // Width of the background sprite

    void Update()
    {
        if (transform.position.x + backgroundWidth / 2 < Camera.main.transform.position.x)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += backgroundWidth * 2; // Adjust for looping
            transform.position = newPosition;
        }
    }
}
