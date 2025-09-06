using UnityEngine;
// Não se esqueça de adicionar esta linha para gerenciar cenas!
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ClickParaCarregarCena : MonoBehaviour
{
    [Header("Configuração da Cena")]
    [Tooltip("O nome exato do arquivo da cena que deve ser carregado.")]
    public string nomeDaCenaParaCarregar;

    // A função OnMouseDown é chamada automaticamente pelo Unity
    // quando o mouse clica em um GameObject que possui um Collider.
    private void FixedUpdate()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !string.IsNullOrEmpty(nomeDaCenaParaCarregar))
        {

            Debug.Log("Carregando cena: " + nomeDaCenaParaCarregar);

            // A linha de código que faz a mágica acontecer!
            SceneManager.LoadScene(nomeDaCenaParaCarregar);
        }
        // ...
    }
}