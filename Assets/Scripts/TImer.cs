using UnityEngine;
using TMPro;

public class ControladorTimerMilisegundos : MonoBehaviour
{
    // Um 'enum' para controlar os estados do nosso timer de forma organizada.
    private enum EstadoDoTimer { Rodando, TempoEsgotado, Finalizado }
    private EstadoDoTimer estadoAtual;

    [Header("Componentes")]
    [Tooltip("Fonte do texto do timer")]
    public TextMeshProUGUI textoDoTimer;

    [Header("Configurações do Timer")]
    [Tooltip("O tempo inicial do timer, em segundos.")]
    public float tempoRestante = 59.999f;
    [Tooltip("A duração do efeito de fade out quando o tempo acaba.")]
    public float duracaoDoFadeOut = 3f;

    [Header("Configurações de Cor")]
    public Color corInicial = Color.white;
    public Color corFinal = Color.red;
    public float tempoParaMudarDeCor = 30f;

    private Camera cameraPrincipal;
    private Vector3 offset = new Vector3(0, 125f, 0);

    void Start()
    {
        cameraPrincipal = Camera.main;
        textoDoTimer.color = corInicial;
        estadoAtual = EstadoDoTimer.Rodando; // Define o estado inicial.
    }

    void Update()
    {
        // A lógica de seguir a câmera continua a mesma.
        if (cameraPrincipal != null)
        {
            transform.position = cameraPrincipal.transform.position + offset;
        }

        // Usamos um 'switch' para executar lógicas diferentes dependendo do estado atual.
        switch (estadoAtual)
        {
            case EstadoDoTimer.Rodando:
                ExecutarTimerRodando();
                break;

            case EstadoDoTimer.TempoEsgotado:
                ExecutarFadeOut();
                break;

            case EstadoDoTimer.Finalizado:
                // O timer já terminou seu ciclo completo, não faz mais nada.
                break;
        }
    }

    private void ExecutarTimerRodando()
    {
        if (tempoRestante > 0)
        {
            tempoRestante -= Time.deltaTime;

            // Lógica para mudar a cor gradualmente para vermelho
            if (tempoRestante <= tempoParaMudarDeCor)
            {
                float t = (tempoParaMudarDeCor - tempoRestante) / tempoParaMudarDeCor;
                textoDoTimer.color = Color.Lerp(corInicial, corFinal, t);
            }

            AtualizarDisplayDoTimer(tempoRestante);
        }
        else
        {
            // O tempo acabou!
            Debug.Log("O tempo acabou! Iniciando fade out...");
            tempoRestante = 0; // Trava o tempo em 0
            GameStateManager.Instance.Timeout = true;
            AtualizarDisplayDoTimer(tempoRestante);
            estadoAtual = EstadoDoTimer.TempoEsgotado; // Muda para o próximo estado.
        }
    }

    private void ExecutarFadeOut()
    {
        // O tempo continua contando para baixo (ficando negativo) para controlar o fade.
        tempoRestante -= Time.deltaTime;

        // Calcula a opacidade (alpha) de 1 (visível) para 0 (invisível) ao longo de 'duracaoDoFadeOut' segundos.
        float alpha = 1.0f - (Mathf.Abs(tempoRestante) / duracaoDoFadeOut);

        // Garante que o alpha não seja menor que 0.
        alpha = Mathf.Clamp01(alpha);

        // Aplica a nova cor com a opacidade calculada.
        textoDoTimer.color = new Color(corFinal.r, corFinal.g, corFinal.b, alpha);

        // Verifica se o fade out terminou.
        if (Mathf.Abs(tempoRestante) >= duracaoDoFadeOut)
        {
            Debug.Log("Morreu");
            estadoAtual = EstadoDoTimer.Finalizado; // Muda para o estado final.
        }
    }

    private void AtualizarDisplayDoTimer(float tempoParaExibir)
    {
        if (tempoParaExibir < 0)
        {
            tempoParaExibir = 0;
        }

        int segundos = Mathf.FloorToInt(tempoParaExibir);
        float fracao = tempoParaExibir - segundos;
        int milissegundos = Mathf.FloorToInt(fracao * 10000);

        // Corrigido para {0:00} para garantir que segundos abaixo de 10 tenham um zero na frente (ex: 09).
        textoDoTimer.text = string.Format("{0:00}:{1:0000}", segundos, milissegundos);
    }
}