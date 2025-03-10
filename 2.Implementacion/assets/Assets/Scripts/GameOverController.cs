using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    // Método para cargar la Escena 1
    public void LoadScene1()
    {
        // Cambia "Scene1" por el nombre de tu escena
        SceneManager.LoadScene(1);
    }

    // Método para salir del juego
    public void QuitGame()
    {
        // Salir de la aplicación (solo funciona en builds, no en el editor)
        Application.Quit();

        // Si estás en el editor, puedes detener la ejecución
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}