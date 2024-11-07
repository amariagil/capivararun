using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoMenu : MonoBehaviour
{

    // Função que será chamada pelo botão
    public void IrParaMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Ir para o menu");

    }
}
