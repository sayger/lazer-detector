using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public RawImage rawImage;

    private WebCamTexture webcamTexture;
    private Texture2D texture;

    private bool isRedDetected;

    private void Start()
    {
        webcamTexture = new WebCamTexture();
        rawImage.texture = webcamTexture;
        webcamTexture.Play();

        texture = new Texture2D(webcamTexture.width, webcamTexture.height);
    }

    private void Update()
    {
        // Получаем текущий кадр с камеры
        Color[] pixels = webcamTexture.GetPixels();

        // Копируем пиксели в текстуру
        texture.SetPixels(pixels);
        texture.Apply();

        // Отображаем текстуру на экране
        rawImage.texture = texture;

    }
}