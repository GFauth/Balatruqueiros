using UnityEngine;
using TMPro;
using System.Collections;

public class GameStateManager : MonoBehaviour
{
    // Singleton para garantir que só exista uma instância deste gerenciador
    public static GameStateManager Instance { get; private set; }

    [Header("Componentes de UI")]
    [Tooltip("Arraste o objeto de texto da UI que mostrará todas as mensagens.")]
    public TextMeshProUGUI textoDeStatus; // Unificamos os textos em um só

    [Header("Configurações de Efeitos")]
    [Tooltip("A duração do efeito de fade out em segundos.")]
    public float duracaoDoFade = 2.0f;

    [Header("Configurações de Morte")]
    [Tooltip(":skull_emoji:")]
    public float duracaoDamorte = 3.0f;

    [Tooltip("O GameObject 'âncora' para onde a câmera deve se mover.")]
    public GameObject ancora;
    public GameObject ancora2;
    public GameObject ancoraMorte;

    // A referência para a câmera principal da cena.
    private Camera cameraPrincipal;

    #region Propriedades de Estado do Jogo
    // --- Nossas Variáveis Globais ---
    private bool _venceu;
    public bool Venceu
    {
        get { return _venceu; }
        set
        {
            if (_venceu) return; // Impede que a lógica seja chamada várias vezes
            _venceu = value;
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
            if (_perdeu) return;
            _perdeu = value;
            if (_perdeu)
            {
                HandleDerrota();
            }
        }
    }

    private bool _timeout;
    public bool Timeout
    {
        get { return _timeout; }
        set
        {
            if (_timeout) return;
            _timeout = value;
            if (_timeout)
            {
                HandleTimeOut();
            }
        }
    }
    #endregion

    private void Awake()
    {
        // Lógica do Singleton
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Pega a referência da câmera principal. Essencial para a lógica de movimento.
        cameraPrincipal = Camera.main;
        if (cameraPrincipal == null)
        {
            Debug.LogError("Nenhuma câmera com a tag 'MainCamera' foi encontrada!");
        }
    }

    private void Start()
    {
        // Garante que o texto comece invisível.
        if (textoDeStatus != null)
        {
            textoDeStatus.gameObject.SetActive(false);
        }
    }

    #region Funções de Estado do Jogo (Handlers)

    private void HandleVitoria()
    {
        Debug.Log("VENCEU!");
        if (textoDeStatus != null)
        {
            textoDeStatus.gameObject.SetActive(true);
            textoDeStatus.text = "PUZZLE DONE";
            textoDeStatus.color = Color.grey;
            StartCoroutine(FadeOutCoroutine()); // Inicia o fade out do texto de vitória
        }
    }

    private void HandleDerrota()
    {
        Debug.Log("PERDEU!");
        if (textoDeStatus != null)
        {
            textoDeStatus.gameObject.SetActive(true);
            textoDeStatus.text = "YOU LOST";
            textoDeStatus.color = Color.red;
            StartCoroutine(FadeOutCoroutine()); // Inicia o fade out do texto de derrota
        }
        Morreu();
    }

    private void HandleTimeOut()
    {
        Debug.Log("OUT OF TIME!");
        
        if (textoDeStatus != null)
        {
            textoDeStatus.gameObject.SetActive(true);
            textoDeStatus.text = "OUT OF TIME";
            textoDeStatus.color = Color.red;
            StartCoroutine(FadeOutCoroutine()); // Inicia o fade out do texto de tempo esgotado
        }
        Morreu();
    }

    #endregion

    #region Lógica de Efeitos (Câmera e Fade)

    private void Morreu()
    {
        float tempoDaMorte = 0f;
        // Verificações de segurança para evitar erros NullReferenceException
        if (cameraPrincipal == null)
        {
            Debug.LogError("A referência da Câmera Principal não foi definida!");
            return;
        }
        if (ancora == null)
        {
            Debug.LogError("A referência da Âncora não foi definida no Inspector!");
            return;
        }

        float posZAtualDaCamera = cameraPrincipal.transform.position.z;
        cameraPrincipal.transform.position = new Vector3(ancora.transform.position.x, ancora.transform.position.y, posZAtualDaCamera);
        tempoDaMorte = 0;
        while (tempoDaMorte < duracaoDamorte)
        {
            tempoDaMorte += Time.deltaTime;
        }
        tempoDaMorte = 0;
        float posZAtualDaCamera2 = cameraPrincipal.transform.position.z;
        cameraPrincipal.transform.position = new Vector3(ancora2.transform.position.x, ancora2.transform.position.y, posZAtualDaCamera);
        {
            tempoDaMorte += Time.deltaTime;
        }
        float posZAtualDaCameraMorte = cameraPrincipal.transform.position.z;
        cameraPrincipal.transform.position = new Vector3(ancoraMorte.transform.position.x, ancoraMorte.transform.position.y, posZAtualDaCamera);
    }


    private IEnumerator FadeOutCoroutine()
    {
        Color corOriginal = textoDeStatus.color;
        float alphaInicial = corOriginal.a;
        float tempoPassado = 0f;

        while (tempoPassado < duracaoDoFade)
        {
            float progresso = tempoPassado / duracaoDoFade;
            float novoAlpha = Mathf.Lerp(alphaInicial, 0f, progresso);
            textoDeStatus.color = new Color(corOriginal.r, corOriginal.g, corOriginal.b, novoAlpha);
            tempoPassado += Time.deltaTime;
            yield return null;
        }

        textoDeStatus.color = new Color(corOriginal.r, corOriginal.g, corOriginal.b, 0f);
        Debug.Log("Fade Out concluído.");
    }

    #endregion
}