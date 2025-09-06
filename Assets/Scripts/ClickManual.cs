using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManual : MonoBehaviour
{
    void Update()
    {
        // 1. Verifica se o botão esquerdo foi pressionado
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // 2. Converte a posição do mouse na tela para uma posição no mundo 2D
            Vector2 posicaoDoMouseNoMundo = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            // 3. Dispara um raio a partir da posição do mouse
            RaycastHit2D hit = Physics2D.Raycast(posicaoDoMouseNoMundo, Vector2.zero);

            // 4. Verifica se o raio atingiu algo com um collider
            if (hit.collider != null)
            {
                // Se atingiu, imprime o nome do objeto no console!
                Debug.Log("O clique manual atingiu o objeto: " + hit.collider.name);

                // AQUI você pode adicionar sua lógica para mudar de cena,
                // verificando se o nome do objeto atingido é o que você quer.
                // Ex: if (hit.collider.name == "PortalParaNivel2") { ... }
            }
            else
            {
                Debug.Log("O clique não atingiu nenhum collider.");
            }
        }
    }
}
