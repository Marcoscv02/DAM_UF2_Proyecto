using System;
using UnityEngine;

public class NoeliaController : MonoBehaviour
{
    [SerializeField]
    public GameObject Sabela;
    public GameObject BulletPrefb;

    private float lastShootTime;
      private int Health = 50; // Vida del jugador

    public void Update()
    {
        if (Sabela == null) return;
        //Esto sirve para que Noelia mire a Sabela
        Vector3 direction = Sabela.transform.position - transform.position;

        if (direction.x < 0.0f) transform.localScale = new Vector3(-1, 1, 1);
        else if (direction.x >= 0.0f) transform.localScale = new Vector3(1, 1, 1);


        float distance = Mathf.Abs(Sabela.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > lastShootTime + 0.5f)
        {
            //Esto sirve para que Noelia dispare a Sabela
            Shoot();
            lastShootTime = Time.time;
        }
    }

    private void Shoot()
    {
        Debug.Log("Noelia dispara a Sabela");

        Vector3 direction = transform.localScale.x > 0 ? Vector3.right : Vector3.left;

        GameObject bullet = Instantiate(BulletPrefb, transform.position + direction * 0.2f, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetDirection(direction);
    }


    public void TakeDamage()
    {
        Health -= 10;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Notificar al GameManager que un enemigo fue destruido
        GameManager.Instance.CheckWinCondition();
    }
}
