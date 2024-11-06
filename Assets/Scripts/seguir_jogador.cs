using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jogador; // arraste seu personagem aqui no Inspector
    public Vector3 deslocamento; // ajuste o deslocamento no Inspector para posicionar a câmera como quiser

    void LateUpdate()
    {
        if (jogador != null)
        {
            // Posição desejada da câmera com base na posição do jogador + deslocamento
            Vector3 posicaoDesejada = jogador.position + deslocamento;

            // Aplica a posição da câmera
            transform.position = new Vector3(posicaoDesejada.x, posicaoDesejada.y, transform.position.z);
        }
    }
}
