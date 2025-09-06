using UnityEngine;
// N�o se esque�a de adicionar esta linha para gerenciar cenas!
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ClickParaCarregarCena : MonoBehaviour
{
    [Header("Configura��o da Cena")]
    [Tooltip("O nome exato do arquivo da cena que deve ser carregado.")]
    public string nomeDaCenaParaCarregar;

    // A fun��o OnMouseDown � chamada automaticamente pelo Unity
    // quando o mouse clica em um GameObject que possui um Collider.
    private void FixedUpdate()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !string.IsNullOrEmpty(nomeDaCenaParaCarregar))
        {

            Debug.Log("Carregando cena: " + nomeDaCenaParaCarregar);

            // A linha de c�digo que faz a m�gica acontecer!
            SceneManager.LoadScene(nomeDaCenaParaCarregar);
        }
        // ...
    }
}