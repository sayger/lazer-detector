using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        // В этом методе выходите из игры.
        Debug.Log("Выход из игры"); // Опционально, для отладки.

        // В редакторе Unity игра будет просто останавливаться.
        // В сборке игры это вызовет выход из приложения.
        Application.Quit();
    }
}