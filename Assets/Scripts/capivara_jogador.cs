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
    private int contadorPulos; // Contador de pulos
    public int maxPulos = 2; // Quantidade máxima de pulos (pulo duplo = 2)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Checar se o personagem está no chão
        estaChao = Physics2D.OverlapCircle(verificadorDeChao.position, raioVerificacaoChao, camadaSolo);

        if (estaChao)
        {
            contadorPulos = 0; // Reseta o contador de pulos ao tocar o chão
        }

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

        // Pular (verifica se ainda há pulos disponíveis)
        if (Input.GetKeyDown(KeyCode.Space) && contadorPulos < maxPulos)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Zera a velocidade vertical para pulo mais consistente
            rb.AddForce(pulo * Vector2.up, ForceMode2D.Impulse);
            contadorPulos++; // Incrementa o contador de pulos
        }
    }

    private void InverterSprite()
    {
        olhandoDireita = !olhandoDireita;
        Vector3 escalaAtual = transform.localScale;
        escalaAtual.x *= -1; // Inverter a escala no eixo X
        transform.localScale = escalaAtual;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(verificadorDeChao.position, raioVerificacaoChao);
    }
}
