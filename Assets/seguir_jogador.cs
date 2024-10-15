using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class seguir_jogador : MonoBehaviour
{
    public Transform jogador;  
    public Vector3 deslocamento;    
    public float v = 0.125f; 

    void LateUpdate()
    {
        Vector3 posicao_camera = jogador.position + deslocamento;

        Vector3 seguindo_camera = Vector3.Lerp(transform.position, posicao_camera, v);

        transform.position = seguindo_camera;
    }
}
 
