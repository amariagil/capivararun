using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pontuacao : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacao;
    private int pontos = 0;

    public void AddScore(int valor)
    {
        pontos += valor;
        atualizarPontuacao();
    }

    void atualizarPontuacao()
    {
        textoPontuacao.text = "Pontuação: " + pontos.ToString();
    }
}
