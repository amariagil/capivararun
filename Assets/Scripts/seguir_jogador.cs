using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jogador; // arraste seu personagem aqui no Inspector
    public Vector3 deslocamento; // ajuste o deslocamento no Inspector para posicionar a c�mera como quiser

    void LateUpdate()
    {
        if (jogador != null)
        {
            // Posi��o desejada da c�mera com base na posi��o do jogador + deslocamento
            Vector3 posicaoDesejada = jogador.position + deslocamento;

            // Aplica a posi��o da c�mera
            transform.position = new Vector3(posicaoDesejada.x, posicaoDesejada.y, transform.position.z);
        }
    }
}
