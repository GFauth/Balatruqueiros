using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fios : MonoBehaviour
{
    public Sprite Cortado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - transform.position.x <= Mathf.Abs(10)) && (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - transform.position.y <= Mathf.Abs(0.001f)))
        {
            //GetComponent<Animator>().SetBool("Corte", true);
            GetComponent<SpriteRenderer>().sprite = Cortado;
        }
    }
}
