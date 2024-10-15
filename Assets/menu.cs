using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Jogar()
    {
        Debug.Log("Botão Jogar clicado");
        SceneManager.LoadScene("Level1");
    }

    public void Sair()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }
}
