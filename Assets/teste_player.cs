using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float v = 5f;
    public float pulo = 10f;  
    private Rigidbody2D rb;          

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        
        float setas_horizontais = Input.GetAxis("Horizontal"); 
        rb.velocity = new Vector2(setas_horizontais * v, rb.velocity.y);  

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, pulo);  
        }
    }



}
