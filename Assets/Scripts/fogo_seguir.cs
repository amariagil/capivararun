using UnityEngine;

public class FogoQueMata : MonoBehaviour
{
    public Transform player; // Referência ao Transform do jogador
    public float followSpeed = 90f; // Velocidade de movimento do fogo
    public float moveDistance = 30.0f; // Distância total que o fogo deve percorrer
    private Vector3 startPos; // Posição inicial do fogo
    private Vector3 rightLimit; // Limite direito do movimento
    private Vector3 leftLimit; // Limite esquerdo do movimento
    private bool movingRight = true; // Direção de movimento

    void Start()
    {
        startPos = transform.position;
        rightLimit = startPos + Vector3.right * moveDistance; // Calcula o limite direito
        leftLimit = startPos - Vector3.right * moveDistance; // Calcula o limite esquerdo
    }

    void Update()
    {
        // Verifica se o jogador está definido
        if (player != null)
        {
            // Seguir o jogador
            transform.position = Vector3.Lerp(transform.position, player.position, followSpeed * Time.deltaTime);
        }
        else
        {
            // Move o fogo entre os limites se o jogador não estiver definido
            if (movingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, rightLimit, followSpeed * Time.deltaTime);

                // Inverte a direção ao atingir o limite direito
                if (Vector3.Distance(transform.position, rightLimit) < 0.01f)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, leftLimit, followSpeed * Time.deltaTime);

                // Inverte a direção ao atingir o limite esquerdo
                if (Vector3.Distance(transform.position, leftLimit) < 0.01f)
                {
                    movingRight = true;
                }
            }
        }
    }

    // Detecta a colisão com o jogador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verifica se o objeto colidido é o jogador
        {
            // Lógica para matar o jogador, por exemplo, reiniciar a cena ou reduzir a vida
            Debug.Log("Jogador atingido pelo fogo!");
            // Aqui você pode adicionar sua lógica para lidar com a morte do jogador
        }
    }
}
