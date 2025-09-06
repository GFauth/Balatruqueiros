using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class NewMonoBehaviourScript : MonoBehaviour
{


    public string NomeDaCollider;
    void Update()
    {

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            Vector2 posicaoDoMouseNoMundo = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            // 3. Dispara um raio a partir da posição do mouse
            RaycastHit2D hit = Physics2D.Raycast(posicaoDoMouseNoMundo, Vector2.zero);

            if (hit.collider != null && hit.collider.name == NomeDaCollider)
            {
                System.Environment.Exit(0);
            }
        }
    }
}
