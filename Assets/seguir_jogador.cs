using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguir_jogador : MonoBehaviour
{
    public Transform player;  // Refer�ncia ao jogador
    public Vector3 offset;    // Dist�ncia entre a c�mera e o jogador
    public float smoothSpeed = 0.125f;  // Suavidade do movimento da c�mera

    void LateUpdate()
    {
        // Posi��o desejada da c�mera (baseada na posi��o do jogador + o offset)
        Vector3 desiredPosition = player.position + offset;

        // Suaviza o movimento da c�mera para n�o ser abrupto
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posi��o da c�mera
        transform.position = smoothedPosition;
    }
}
 
