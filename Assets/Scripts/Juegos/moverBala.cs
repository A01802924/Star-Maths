using Assets.Scripts.Core;
using UnityEngine;

public class moverBala : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float velocidad = 15f;
    [SerializeField] private GameObject efectoChoque;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        Sprite nuevaSkin = Sprite.Create(
            SessionData.CurrentProjectileItem.itemIcon,
            new Rect(0, 0, SessionData.CurrentProjectileItem.itemIcon.width, SessionData.CurrentProjectileItem.itemIcon.height),
            new Vector2(0.5f, 0.5f)
        );

        sr.sprite = nuevaSkin;
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = velocidad * 1;
        if (transform.position.x >= 10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Meteorito"))
        {
            AudioSource efectoChoque = GameObject.Find("audioDestruyeMeteorito").GetComponent<AudioSource>();
            efectoChoque.Play();

            Instantiate(this.efectoChoque, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}