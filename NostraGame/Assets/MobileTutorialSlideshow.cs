using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import SceneManager
using System.Collections;

public class MobileTutorialSlideshow : MonoBehaviour
{
    public Image tutorialImage;          // The UI Image component displaying the slides
    public Sprite[] tutorialSlides;      // Array to hold tutorial images
    private int currentSlideIndex = 0;   // Index to track the current slide
    private float fadeDuration = 1f;     // Duration of the fade effect
    public string nextSceneName;         // Name of the scene to load after the last slide

    void Start()
    {
        // Display the first slide
        if (tutorialSlides.Length > 0)
        {
            tutorialImage.sprite = tutorialSlides[currentSlideIndex];
            StartCoroutine(FadeIn());
        }
    }

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            // Check if the touch has ended (to detect a tap)
            if (touch.phase == TouchPhase.Ended)
            {
                ShowNextSlide();
            }
        }
    }

    private void ShowNextSlide()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = tutorialImage.color;
        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            tutorialImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        color.a = 1f;
        tutorialImage.color = color;
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = tutorialImage.color;
        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            tutorialImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        color.a = 0f;
        tutorialImage.color = color;

        // Check if this is the last slide
        if (currentSlideIndex >= tutorialSlides.Length - 1)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            // Move to the next slide
            currentSlideIndex++;
            tutorialImage.sprite = tutorialSlides[currentSlideIndex];
            StartCoroutine(FadeIn());
        }
    }
}
