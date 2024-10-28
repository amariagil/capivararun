using UnityEngine;

public class FogoQueMata : MonoBehaviour
{
    public Transform player; // Refer�ncia ao Transform do jogador
    public float followSpeed = 90f; // Velocidade de movimento do fogo
    public float moveDistance = 30.0f; // Dist�ncia total que o fogo deve percorrer
    private Vector3 startPos; // Posi��o inicial do fogo
    private Vector3 rightLimit; // Limite direito do movimento
    private Vector3 leftLimit; // Limite esquerdo do movimento
    private bool movingRight = true; // Dire��o de movimento

    void Start()
    {
        startPos = transform.position;
        rightLimit = startPos + Vector3.right * moveDistance; // Calcula o limite direito
        leftLimit = startPos - Vector3.right * moveDistance; // Calcula o limite esquerdo
    }

    void Update()
    {
        // Verifica se o jogador est� definido
        if (player != null)
        {
            // Seguir o jogador
            transform.position = Vector3.Lerp(transform.position, player.position, followSpeed * Time.deltaTime);
        }
        else
        {
            // Move o fogo entre os limites se o jogador n�o estiver definido
            if (movingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, rightLimit, followSpeed * Time.deltaTime);

                // Inverte a dire��o ao atingir o limite direito
                if (Vector3.Distance(transform.position, rightLimit) < 0.01f)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, leftLimit, followSpeed * Time.deltaTime);

                // Inverte a dire��o ao atingir o limite esquerdo
                if (Vector3.Distance(transform.position, leftLimit) < 0.01f)
                {
                    movingRight = true;
                }
            }
        }
    }

    // Detecta a colis�o com o jogador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verifica se o objeto colidido � o jogador
        {
            // L�gica para matar o jogador, por exemplo, reiniciar a cena ou reduzir a vida
            Debug.Log("Jogador atingido pelo fogo!");
            // Aqui voc� pode adicionar sua l�gica para lidar com a morte do jogador
        }
    }
}
