using Assets.Scripts.Core;
using UnityEngine;

public class moverBala : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float velocidad = 15f;
    [SerializeField] private GameObject efectoChoque;
    private int indexBala = 7;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        Item naveSeleccionada = ItemSet.ProjectileItems[indexBala];

        Debug.Log(naveSeleccionada.name);

        Sprite nuevaSkin = Sprite.Create(
            naveSeleccionada.itemIcon,
            new Rect(0, 0, naveSeleccionada.itemIcon.width, naveSeleccionada.itemIcon.height),
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