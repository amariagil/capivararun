using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float v = 100f; // Velocidade de movimento
    public float pulo = 100f; // For�a do pulo
    private Rigidbody2D rb;
    public bool estaChao; // Verifica��o se est� no ch�o
    public Transform verificadorDeChao; // Empty GameObject para verificar o ch�o
    public float raioVerificacaoChao = 0.2f; // Raio para verificar o ch�o
    public LayerMask camadaSolo; // Definir quais camadas s�o solo
    private bool olhandoDireita = true; // Para controlar a dire��o da sprite

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Checar se o personagem est� no ch�o
        estaChao = Physics2D.OverlapCircle(verificadorDeChao.position, raioVerificacaoChao, camadaSolo);

        // Movimenta��o horizontal
        float setas_horizontais = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(setas_horizontais * v, rb.velocity.y);

        // Invers�o da sprite dependendo da dire��o
        if (setas_horizontais > 0 && !olhandoDireita)
        {
            InverterSprite();
        }
        else if (setas_horizontais < 0 && olhandoDireita)
        {
            InverterSprite();
        }

        // Pular quando no ch�o
        if (Input.GetKeyDown(KeyCode.Space) && estaChao == true)
        {
            rb.AddForce(pulo * Vector2.up, ForceMode2D.Impulse);
        }
    }

    private void InverterSprite()
    {
        olhandoDireita = !olhandoDireita;
        Vector3 escalaAtual = transform.localScale;
        escalaAtual.x *= -1; // Inverter a escala no eixo X
        transform.localScale = escalaAtual;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("solo"))
            estaChao = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        estaChao = false;
    }

    // Visualizador no editor para verificar o raio de checagem de ch�o
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(verificadorDeChao.position, raioVerificacaoChao);
    }
}
