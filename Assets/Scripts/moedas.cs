using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moedas : MonoBehaviour
{
    public int moedaValor = 1; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<pontuacao>().AddScore(moedaValor);

            Destroy(gameObject);
        }
    }
}
