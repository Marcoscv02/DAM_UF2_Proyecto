using System;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    [Header("Enemies")]
    public int totalEnemies; // Total de enemigos en la escena
    private int enemiesDefeated = 0; // Enemigos derrotados

    [Header("Scene Management")]
    public string gameOverSceneName = "GameOverScene"; // Nombre de la escena de Game Over


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
}

    private void Start()
    {
        // Contar los enemigos al inicio
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Método para manejar la destrucción del jugador
    public void PlayerDestroyed()
    {
        SceneManager.LoadScene(2); // Cargar la escena de Game Over
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

    public void WinGame()
    {
        SceneManager.LoadScene(4); // Cargar la escena de victoria
    }
}