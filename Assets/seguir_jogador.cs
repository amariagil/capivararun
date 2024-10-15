using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguir_jogador : MonoBehaviour
{
    public Transform player;  // Referência ao jogador
    public Vector3 offset;    // Distância entre a câmera e o jogador
    public float smoothSpeed = 0.125f;  // Suavidade do movimento da câmera

    void LateUpdate()
    {
        // Posição desejada da câmera (baseada na posição do jogador + o offset)
        Vector3 desiredPosition = player.position + offset;

        // Suaviza o movimento da câmera para não ser abrupto
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posição da câmera
        transform.position = smoothedPosition;
    }
}
 
