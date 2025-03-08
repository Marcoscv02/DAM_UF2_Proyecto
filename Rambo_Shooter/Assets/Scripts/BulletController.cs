using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f; // Velocidad de la bala
    public float lifeTime = 2f; // Tiempo de vida de la bala
    public AudioClip shootSound; // Sonido de disparo

    private Rigidbody2D rb; // Rigidbody del objeto
    private Vector2 direction; // Dirección de la bala



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(shootSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }


    public void DestroyBullet()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        
        SabelaController BestTeacher = collision.GetComponent<SabelaController>();
        NoeliaController WorstTeacher = collision.GetComponent<NoeliaController>();

        if (BestTeacher != null)
        {
            BestTeacher.TakeDamage();

        }else if (WorstTeacher != null)
        {
            WorstTeacher.TakeDamage();
        }

        DestroyBullet();
    }
}
