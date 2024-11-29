using UnityEngine;
using UnityEngine.UI;

public class ToggleSFX : MonoBehaviour
{
    public Sprite sfxOnSprite;    // Sprite for sound effects ON state
    public Sprite sfxOffSprite;   // Sprite for sound effects OFF state
    private bool areSfxOn = true; // Tracks the state of sound effects

    private Image buttonImage;     // Reference to the button's Image component

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        UpdateButtonSprite();
    }

    public void ToggleSfxState() // This method is called on button click
    {
        areSfxOn = !areSfxOn;

        // Enable or disable sound effects globally
        AudioListener.volume = areSfxOn ? 1f : 0f;

        UpdateButtonSprite();
    }

    private void UpdateButtonSprite()
    {
        buttonImage.sprite = areSfxOn ? sfxOnSprite : sfxOffSprite;
    }
}
