using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoMenu : MonoBehaviour
{

    // Fun��o que ser� chamada pelo bot�o
    public void IrParaMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Ir para o menu");

    }
}
