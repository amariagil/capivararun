using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 100f;// Velocidade de movimento
    public float jumpForce = 5f;  // For�a do pulo
    private Rigidbody2D rb;            // Componente Rigidbody2D do jogador

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Obt�m o Rigidbody2D do jogador
    }

    void Update()
    {
        // Movimento horizontal (setas esquerda e direita)
        float moveInput = Input.GetAxis("Horizontal");  // Acessa as setinhas (esquerda/direita)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);  // Define a velocidade no eixo X

        // Verifica se o jogador est� no ch�o e o comando de pular (barra de espa�o)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // Adiciona a for�a para pular no eixo Y
        }
    }



}
