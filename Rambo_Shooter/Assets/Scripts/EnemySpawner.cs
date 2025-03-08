using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] enemyPrefabs; // Array de prefabs de enemigos
    public int numberOfEnemies = 10; // Número de enemigos a generar
    public Vector2 spawnAreaMin; // Límite mínimo del área de spawn
    public Vector2 spawnAreaMax; // Límite máximo del área de spawn

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Seleccionar un prefab de enemigo aleatorio
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Generar una posición aleatoria dentro del área de spawn
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            // Instanciar el enemigo en la posición aleatoria
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Dibujar un gizmo en el Editor para visualizar el área de spawn
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((spawnAreaMin + spawnAreaMax) / 2, spawnAreaMax - spawnAreaMin);
    }
}
