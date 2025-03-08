using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject player; // Objeto que seguirá la cámara

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            
            Vector3 position = transform.position; // Obtener la posición actual de la cámara
            position.x = player.transform.position.x; // Actualizar la posición en X de la cámara
            transform.position = position; // Asignar la nueva posición a la cámara
        }
    }
}
