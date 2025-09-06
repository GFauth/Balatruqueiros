using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;




public class MoveCenaPorCollider : MonoBehaviour
{

    
    public string NomeDaCena;

    
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
                SceneManager.LoadScene(NomeDaCena);
            }
        }
    }
}




