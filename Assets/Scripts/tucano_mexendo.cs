using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tucano_mexendo : MonoBehaviour
{
    public float speed = 90.0f; // Velocidade da plataforma
    public float moveDistance = 210.0f; // Dist�ncia total que a plataforma deve percorrer para cada lado
    private Vector3 startPos; // Posi��o inicial da plataforma
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
        // Move a plataforma na dire��o atual
        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightLimit, speed * Time.deltaTime);

            // Inverte a dire��o ao atingir o limite direito
            if (transform.position == rightLimit)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, leftLimit, speed * Time.deltaTime);

            // Inverte a dire��o ao atingir o limite esquerdo
            if (transform.position == leftLimit)
            {
                movingRight = true;
            }
        }
    }
}
