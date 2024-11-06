using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CapivaraMorte : MonoBehaviour
{
    public GameObject popupMorte; // Arraste o pop-up de morte aqui pelo Inspector

    void Start()
    {
        popupMorte.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se a capivara encostou no fogo
        if (collision.CompareTag("Fogo"))
        {
            MostrarPopupMorte();
        }
    }

    void MostrarPopupMorte()
    {
        popupMorte.SetActive(true); // Mostra o pop-up de morte
        Time.timeScale = 0; // Pausa o jogo
        Debug.Log("A capivara morreu!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Retoma o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia a cena
    }

    public void QuitGame()
    {
        Time.timeScale = 1; // Retoma o jogo
        popupMorte.SetActive(false); // Esconde o pop-up
        // Opcional: feche o jogo ou redirecione o jogador para o menu principal
    }
}
