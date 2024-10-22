using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float v = 100f; // Velocidade de movimento
    public float pulo = 100f; // Força do pulo
    private Rigidbody2D rb;
    public bool estaChao; // Verificação se está no chão
    public Transform verificadorDeChao; // Empty GameObject para verificar o chão
    public float raioVerificacaoChao = 0.2f; // Raio para verificar o chão
    public LayerMask camadaSolo; // Definir quais camadas são solo
    private bool olhandoDireita = true; // Para controlar a direção da sprite

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Checar se o personagem está no chão
        estaChao = Physics2D.OverlapCircle(verificadorDeChao.position, raioVerificacaoChao, camadaSolo);

        // Movimentação horizontal
        float setas_horizontais = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(setas_horizontais * v, rb.velocity.y);

        // Inversão da sprite dependendo da direção
        if (setas_horizontais > 0 && !olhandoDireita)
        {
            InverterSprite();
        }
        else if (setas_horizontais < 0 && olhandoDireita)
        {
            InverterSprite();
        }

        // Pular quando no chão
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

    // Visualizador no editor para verificar o raio de checagem de chão
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(verificadorDeChao.position, raioVerificacaoChao);
    }
}
