using UnityEngine;
using UnityEngine.InputSystem;

public class MoverCameraAoClicar : MonoBehaviour
{
    [Header("Posição de Destino da Câmera")]
    public GameObject ancora;
    //public Vector2 posicaoAlvo;
    public Camera cameraPrincipal;
    public string nomeDoObjeto;



    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            Vector2 posicaoDoMouseNoMundo = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(posicaoDoMouseNoMundo, Vector2.zero);

            if (hit.collider != null && hit.collider.name == nomeDoObjeto)
            {
                 Vector3 posInicialCamera = cameraPrincipal.transform.position;

                //  Vector3 novaPosicao = new Vector3(posicaoAlvo.x, posicaoAlvo.y, posInicialCamera.z);

                cameraPrincipal.transform.position = new Vector3(ancora.transform.position.x, ancora.transform.position.y, posInicialCamera.z);
            }

        }


        }
}