using UnityEngine;
using UnityEngine.InputSystem;


public class AlicateUI : MonoBehaviour
{
    public GameManager AgarrarAlicate;
    Vector3 offset = new Vector3(-10.8f, -3.75f, 5f);
    Vector3 morte = new Vector3(1000, 1000, 20f);
    private Camera cameraPrincipal;

    void Start()
    {
        // Pega a referência da câmera principal da cena.
        cameraPrincipal = Camera.main;
    }

    void Update()
    {
        // ---- EXEMPLO DE COMO CHAMAR A SUB-ROTINA ----
        // Vamos chamar a função quando a tecla 'P' for pressionada.

        if (AgarrarAlicate)
        {
            // Chama a nossa sub-rotina, passando o transform do objeto como argumento.
            transform.position = cameraPrincipal.transform.position + offset;
        }
        else
        {
            Vector3 posicaoAlvo = morte;
        }
    }
}