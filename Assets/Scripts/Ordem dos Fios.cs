using UnityEngine;
using System.Collections.Generic; 
using System.Linq;

public class ControladorFios : MonoBehaviour
{
    public static ControladorFios instancia;

    [Header("Configuração dos Fios")]
    [Tooltip("so GameObjects dos fios")]
    public List<Fios_scr> FiosDisponiveis;

    [Header("Nº de fios Corretos")]
    [Tooltip("Quantos fios corretos devem existir na sequência.")]
    public int numeroDeFios = 7;

    // --- listas ----
    private List<int> sequenciaCorreta;
    private List<int> fiosFalsos;

    private int passoAtual = 0;
    private bool Finalizado = false;

    // Versão mais segura do Awake() para o ControladorFios.cs
    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            // Se já existir uma instância, destrói esta para evitar duplicatas.
            Destroy(gameObject);
            return;
        }

        SequenciaAleatoria();
    }

    void SequenciaAleatoria()
    {
        // Cria uma lista com os IDs de todos os fios disponíveis.
        List<int> idsDeFios = new List<int>();
        foreach (Fios_scr fio in FiosDisponiveis)
        {
            idsDeFios.Add(fio.idDoFio);
        }

        // embralha os fios
        for (int i = idsDeFios.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = idsDeFios[i];
            idsDeFios[i] = idsDeFios[j];
            idsDeFios[j] = temp;
        }

        //Define a sequência correta
        sequenciaCorreta = idsDeFios.Take(numeroDeFios).ToList();
        fiosFalsos = idsDeFios.Skip(numeroDeFios).ToList();

        // --- PARA DEBUG ---
        // mostra a sequência gerada no console 
        Debug.Log("Sequência: " + string.Join(", ", sequenciaCorreta));
        Debug.Log("Fios Falsos: " + string.Join(", ", fiosFalsos));
    }

    public void FioFoiCortado(int idDoFio)
    {
        if (Finalizado) return;

        // ---  já pode morrer ----
        //Verifica se o fio cortado está na lista de fios falsos
        if (fiosFalsos.Contains(idDoFio))
        {
            Debug.Log($"VOCÊ CORTOU O FIO FALSO {idDoFio}!");
            Perdeu();
            return;
        }

        // verifica se o fio cortado é o correto para o passo atual da sequência.
        if (passoAtual < sequenciaCorreta.Count && idDoFio == sequenciaCorreta[passoAtual])
        {
            // fio certo
            passoAtual++;

            // --- gg wp ---
            if (passoAtual >= sequenciaCorreta.Count)
            {
                Debug.Log("Conseguiu");
                Venceu();
            }
        }
        else
        {
            // O jogador cortou um fio da sequência, mas na ordem errada ou um fio que não é falso mas não é o próximo.
            Debug.Log($"ORDEM ERRADA! O fio correto era {sequenciaCorreta[passoAtual]},foi cortado: {idDoFio}");
            Perdeu();
        }
    }

    private void Venceu()
    {
        Finalizado = true;
        // ativa vitória no Game State Manager
        GameStateManager.Instance.Venceu = true;
    }

    private void Perdeu()
    {
        Finalizado = true;
        // ativa a derrota no Game Estata Manager
        GameStateManager.Instance.Perdeu = true;
    }
}