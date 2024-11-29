using UnityEngine;

public class ParallaxLooper : MonoBehaviour
{
    public float speed; // Speed at which the layer moves
    public float parallaxMultiplier; // Adjusts relative speed for parallax effect
    private float spriteWidth; // Width of the background sprite
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;

        // Calculate sprite width based on the sprite renderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.bounds.size.x;
    }

    void Update()
    {
        // Move the background horizontally
        transform.Translate(Vector3.left * speed * parallaxMultiplier * Time.deltaTime);

        // Loop the background when it's out of view
        if (transform.position.x <= -spriteWidth)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += spriteWidth * 2; // Shift it to the right to loop
            transform.position = newPosition;
        }
    }
}
