using UnityEngine;
using UnityEngine.SceneManagement;

public class Chegada : MonoBehaviour
{
    [Header("Final")]
    public string Final;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag 'Player'
        if (collision.CompareTag("Player"))
        {
            // Carrega a cena de vitória
            SceneManager.LoadScene(Final);
        }
    }
}


