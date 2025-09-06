using UnityEngine;
using TMPro; 

public class GameStateManager : MonoBehaviour
{
 
    public static GameStateManager Instance { get; private set; }

    [Header("Componentes de UI")]
    [Tooltip("Arraste o objeto de texto da UI que mostrar� as mensagens de vit�ria/derrota.")]
    public TextMeshProUGUI textoDeStatus;

    // --- Vari�veis Globais ---
    private bool _venceu;
    public bool Venceu
    {
        get { return _venceu; }
        set
        {
            _venceu = value;
            // Se o novo valor for 'true', chama a fun��o de vit�ria.
            if (_venceu)
            {
                HandleVitoria();
            }
        }
    }

    private bool _perdeu;
    public bool Perdeu
    {
        get { return _perdeu; }
        set
        {
            _perdeu = value;
            // Se o novo valor for 'true', chama a fun��o de derrota.
            if (_perdeu)
            {
                HandleDerrota();
            }
        }
    }

  

    private void Start()
    {
        // Garante que o texto comece invis�vel.
        if (textoDeStatus != null)
        {
            textoDeStatus.gameObject.SetActive(false);
        }
    }

    private void HandleVitoria()
    {
        Debug.Log("VENCEU!");
        if (textoDeStatus != null)
        {
            textoDeStatus.gameObject.SetActive(true); 
            textoDeStatus.text = "VENCEU";           
            textoDeStatus.color = Color.green;        
        }
        
    }

    private void HandleDerrota()
    {
        Debug.Log("PERDEU");
        if (textoDeStatus != null)
        {
            textoDeStatus.gameObject.SetActive(true); 
            textoDeStatus.text = "PERDEU";           
            textoDeStatus.color = Color.red;          
        }
        
    }
}