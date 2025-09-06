using UnityEngine;
using TMPro;
using System.Collections;

public class GameStateManager : MonoBehaviour
{
    // Singleton para garantir que s� exista uma inst�ncia deste gerenciador
    public static GameStateManager Instance { get; private set; }

    [Header("Componentes de UI")]
    [Tooltip("Arraste o objeto de texto da UI que mostrar� todas as mensagens.")]
    public TextMeshProUGUI textoDeStatus; // Unificamos os textos em um s�

    [Header("Configura��es de Efeitos")]
    [Tooltip("A dura��o do efeito de fade out em segundos.")]
    public float duracaoDoFade = 2.0f;

    [Header("Configura��es de Morte")]
    [Tooltip(":skull_emoji:")]
    public float duracaoDamorte = 3.0f;

    [Tooltip("O GameObject '�ncora' para onde a c�mera deve se mover.")]
    public GameObject ancora;
    public GameObject ancora2;
    public GameObject ancoraMorte;

    // A refer�ncia para a c�mera principal da cena.
    private Camera cameraPrincipal;

    #region Propriedades de Estado do Jogo
    // --- Nossas Vari�veis Globais ---
    private bool _venceu;
    public bool Venceu
    {
        get { return _venceu; }
        set
        {
            if (_venceu) return; // Impede que a l�gica seja chamada v�rias vezes
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
        // L�gica do Singleton
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Pega a refer�ncia da c�mera principal. Essencial para a l�gica de movimento.
        cameraPrincipal = Camera.main;
        if (cameraPrincipal == null)
        {
            Debug.LogError("Nenhuma c�mera com a tag 'MainCamera' foi encontrada!");
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

    #region Fun��es de Estado do Jogo (Handlers)

    private void HandleVitoria()
    {
        Debug.Log("VENCEU!");
        if (textoDeStatus != null)
        {
            textoDeStatus.gameObject.SetActive(true);
            textoDeStatus.text = "PUZZLE DONE";
            textoDeStatus.color = Color.grey;
            StartCoroutine(FadeOutCoroutine()); // Inicia o fade out do texto de vit�ria
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

    #region L�gica de Efeitos (C�mera e Fade)

    private void Morreu()
    {
        float tempoDaMorte = 0f;
        // Verifica��es de seguran�a para evitar erros NullReferenceException
        if (cameraPrincipal == null)
        {
            Debug.LogError("A refer�ncia da C�mera Principal n�o foi definida!");
            return;
        }
        if (ancora == null)
        {
            Debug.LogError("A refer�ncia da �ncora n�o foi definida no Inspector!");
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
        Debug.Log("Fade Out conclu�do.");
    }

    #endregion
}