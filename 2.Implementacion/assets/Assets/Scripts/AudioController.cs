using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No se encontró el componente AudioSource en la cámara.");
        }
        else
        {
            Debug.Log("AudioSource encontrado. Reproduciendo audio...");
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            Debug.LogWarning("El AudioSource no se está reproduciendo.");
        }
    }
}