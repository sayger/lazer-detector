using UnityEngine;
using UnityEngine.UI;

public class ColorDetector : MonoBehaviour
{
    [Header("Настройки детектора")]
    public GameObject rawImageCube;
    public AudioClip detectionSound;
    public Color targetColor = Color.red;
    public float detectionThreshold = 0.1f;

    private RawImage rawImageComponent;
    private AudioSource audioSource;
    private bool isColorDetected = false;

    void Start()
    {
        rawImageComponent = rawImageCube.GetComponent<RawImage>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Texture2D texture = (Texture2D)rawImageComponent.texture;
        Color[] pixels = texture.GetPixels();

        foreach (Color pixelColor in pixels)
        {
            // Проверяем, соответствует ли цвет целевому цвету и порогу.
            if (ColorCheck(pixelColor, targetColor, detectionThreshold))
            {
                if (!isColorDetected)
                {
                    // Обнаружен целевой цвет, проигрываем звук.
                    audioSource.PlayOneShot(detectionSound);
                    isColorDetected = true;
                }
                return; // Прерываем цикл, как только один пиксель целевого цвета обнаружен.
            }
        }

        // Если целевой цвет не обнаружен, выключаем звук.
        if (isColorDetected)
        {
            audioSource.Stop();
            isColorDetected = false;
        }
    }

    // Метод для проверки цвета с учетом порога.
    private bool ColorCheck(Color pixelColor, Color targetColor, float threshold)
    {
        // Рассчитываем квадрат расстояния между цветами.
        float distanceSquared = Mathf.Pow(pixelColor.r - targetColor.r, 2) +
                                Mathf.Pow(pixelColor.g - targetColor.g, 2) +
                                Mathf.Pow(pixelColor.b - targetColor.b, 2);
        // Сравниваем квадрат расстояния с квадратом порога.
        return distanceSquared < Mathf.Pow(threshold, 2);
    }
}