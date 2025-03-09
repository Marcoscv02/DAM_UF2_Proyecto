using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    [Header("Game Settings")]
    public int maxLives = 3; // Vidas máximas
    private int currentLives; // Vidas actuales

    [Header("Game State")]
    public bool gameOver = false; // Indica si el juego ha terminado
    public bool gameWon = false; // Indica si el jugador ha ganado

    [Header("Enemies")]
    public int totalEnemies; // Total de enemigos en la escena
    private int enemiesDefeated = 0; // Enemigos derrotados

    [Header("Scene Management")]
    public string gameOverSceneName = "GameOverScene"; // Nombre de la escena de Game Over

    private void Start()
    {
        // Contar los enemigos al inicio
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void Awake()
    {
        // Configurar el singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persistir entre escenas
        }
        else
        {
            Destroy(gameObject);
        }

        // Inicializar vidas
        currentLives = maxLives;
    }

    // Método para perder una vida
    public void LoseLife()
    {
        if (gameOver) return; // Si el juego ya terminó, no hacer nada

        currentLives--;
        Debug.Log("Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            GameOver(false); // Pierde el juego
        }
    }

    // Método para ganar el juego
    public void WinGame()
    {
        if (gameOver) return; // Si el juego ya terminó, no hacer nada

        GameOver(true); // Gana el juego
    }

    // Método para manejar el fin del juego
    private void GameOver(bool isWin)
    {
        gameOver = true;
        gameWon = isWin;

        if (isWin)
        {
            Debug.Log("¡Has ganado!");
            // Aquí puedes cargar una escena de victoria o mostrar un mensaje
        }
        else
        {
            Debug.Log("¡Has perdido!");
            LoadGameOverScene(); // Cargar la escena de Game Over
        }
    }

    // Método para cargar la escena de Game Over
    private void LoadGameOverScene()
    {
        if (!string.IsNullOrEmpty(gameOverSceneName))
        {
            SceneManager.LoadScene(gameOverSceneName); // Cargar la escena de Game Over
        }
        else
        {
            Debug.LogError("Nombre de la escena de Game Over no asignado.");
        }
    }

    // Método para verificar si el jugador ganó
    public void CheckWinCondition()
    {
        enemiesDefeated++;

        if (enemiesDefeated >= totalEnemies)
        {
            WinGame(); // Gana el juego
        }
    }
}