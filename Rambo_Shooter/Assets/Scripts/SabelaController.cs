using System;
using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir este namespace para usar la clase Image

public class SabelaController : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody del objeto
    private bool grounded; // Indica si el objeto está en el suelo
    private Animator animator; // Animator del objeto
    private float lastJumpTime = 0f; // Tiempo del último salto
    private int Health = 100; // Vida del jugador
    private float fallLimit = -10f; // Límite de caída

    [Header("Movement Settings")]
    public float moveSpeed = 3f; // Velocidad de movimiento
    public float jumpForce = 2f; // Fuerza de salto
    public float jumpCooldown = 0.5f; // Tiempo de espera entre saltos
    public GameObject BulletPrefb; // Prefab de la bala

    [Header("Health Settings")]
    public Image rellenoBarraVida; // Referencia a la imagen de la barra de vida

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el Rigidbody del objeto
        animator = GetComponent<Animator>(); // Obtener el Animator del objeto
        UpdateHealthBar(); // Inicializar la barra de vida
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0.0f) transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontalInput > 0.0f) transform.localScale = new Vector3(1, 1, 1);

        animator.SetBool("Running", horizontalInput != 0.0f);

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime; // Calcular el movimiento en el eje X
        transform.Translate(movement);

        // Saltar 
        if (Input.GetKeyDown(KeyCode.W) && Time.time > lastJumpTime + jumpCooldown)
        {
            Jump();
            animator.SetBool("Jumping", true); //activar animacion
        }
        else
        {
            animator.SetBool("Jumping", false); //desactivar animacion
        }

        //Disparar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        // Verificar si el personaje cayó del mapa
        if (transform.position.y < fallLimit)
        {
            DestroyPlayer();
        }
    }

    //Saltar
    private void Jump()
    {
        // Aplicar una fuerza hacia arriba para el salto
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // Registrar el tiempo del último salto
        lastJumpTime = Time.time;
    }

    //Disparar
    private void Shoot()
    {
        Vector3 direction = transform.localScale.x > 0 ? Vector3.right : Vector3.left;

        GameObject bullet = Instantiate(BulletPrefb, transform.position + direction * 0.2f, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetDirection(direction);
    }

    public void TakeDamage()
    {
        Health -= 10;
        if (Health <= 0)
        {
            DestroyPlayer();
        }
        UpdateHealthBar(); // Actualizar la barra de vida después de recibir daño
    }

    private void FixedUpdate()
    {
        // Verificar si el objeto está en el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f);
        grounded = hit.collider != null;
    }

    // Método para destruir al personaje y perder una vida
    public void DestroyPlayer()
    {
        Debug.Log("El personaje ha sido destruido.");
        GameManager.Instance.LoseLife(); // Notificar al GameManager
        Destroy(gameObject); // Destruir el objeto del personaje
    }

    // Método para actualizar la barra de vida
    private void UpdateHealthBar()
    {
        if (rellenoBarraVida != null)
        {
            // Ajustar la escala en el eje X de la barra de vida según la vida actual
            rellenoBarraVida.fillAmount = Health / 100f;
        }
    }
}