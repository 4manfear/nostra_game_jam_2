using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    public AudioSource musicSource; // Reference to the music AudioSource
    public Sprite musicOnSprite;   // Sprite for music ON state
    public Sprite musicOffSprite;  // Sprite for music OFF state
    private bool isMusicOn = true; // Tracks the state of the music

    private Image buttonImage;     // Reference to the button's Image component

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        UpdateButtonSprite();
    }

    public void ToggleMusicState() // This method is called on button click
    {
        isMusicOn = !isMusicOn;
        musicSource.mute = !isMusicOn;

        UpdateButtonSprite();
    }

    private void UpdateButtonSprite()
    {
        buttonImage.sprite = isMusicOn ? musicOnSprite : musicOffSprite;
    }
}
