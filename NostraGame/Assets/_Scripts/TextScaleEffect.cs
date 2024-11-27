using UnityEngine;
using TMPro;

public class TextScaleEffect : MonoBehaviour
{
    [Header("Settings")]
    public TextMeshProUGUI textMeshPro; // Reference to the TextMeshProUGUI component
    public float minScale = 0.8f; // Minimum scale factor
    public float maxScale = 1.2f; // Maximum scale factor
    public float speed = 2f; // Speed of the animation

    private Vector3 originalScale;

    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }
        originalScale = textMeshPro.transform.localScale;
    }

    void Update()
    {
        float scale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong(Time.time * speed, 1f));
        textMeshPro.transform.localScale = originalScale * scale;
    }
}
