using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fios_scr : MonoBehaviour
{
    [Header("Identificação do Fio")]
    [Tooltip("Numere os fios de 0 a 7")]
    public int idDoFio; // ID único para este fio (de 0 a 7)

    public Sprite Cortado;
    
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && ((Mathf.Abs(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - transform.position.x)) <= 0.2f) && ((Mathf.Abs(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - transform.position.y)) <= 1.6f))
        {
            //GetComponent<Animator>().SetBool("Corte", true);
            GetComponent<SpriteRenderer>().sprite = Cortado;
        }
    }
}
