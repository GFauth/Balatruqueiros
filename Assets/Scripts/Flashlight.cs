using UnityEngine;
using UnityEngine.InputSystem;


/*
And if you feel that you can't go on
And your will's sinkin' low
Just believe, and you can't go wrong
In the light you will find the road
You will find the road
*/


public class LanternaSegueMouse : MonoBehaviour
{
    public float offsetDeRotacao = 0f;

    void Update()
    {
        // Pega a posi��o do mouse na tela
        Vector2 posicaoMouseNaTela = Mouse.current.position.ReadValue();

        // Converte a posi��o do mouse para o mundo do jogo
        Vector3 posicaoMouseNoMundo = Camera.main.ScreenToWorldPoint(posicaoMouseNaTela);


        // Faz a posi��o deste objeto seguir a posi��o do mouse no mundo
        transform.position = new Vector2(posicaoMouseNoMundo.x, posicaoMouseNoMundo.y);
        

        // C�digo da rota��o
        Vector2 direcao = new Vector2(
            posicaoMouseNoMundo.x - transform.position.x,
            posicaoMouseNoMundo.y - transform.position.y
        );

        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angulo + offsetDeRotacao);
    }
}