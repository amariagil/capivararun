using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float v = 100f;
    public float pulo = 100f;
    private Rigidbody2D rb;
    public bool estaChao; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float setas_horizontais = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(setas_horizontais * v, rb.velocity.y);

        

        if (Input.GetKeyDown(KeyCode.Space)&& estaChao == true)
        {
            rb.AddForce(pulo * Vector2.up, ForceMode2D.Impulse);
            //rb.velocity = new Vector2(rb.velocity.x, pulo);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("solo"))
        estaChao = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        estaChao = false;
        
    }

}
