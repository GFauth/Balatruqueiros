using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorLivros : MonoBehaviour
{
    public GameObject Livro1;
    public GameObject Livro2;
    public GameObject Livro3;
    public GameObject Livro4;
    public GameObject Livro5;
    public bool Click1;
    public bool Click2;
    bool Click3;
    bool Click4;
    bool Click5;
    Vector3 postemp;

    GameObject[] Livros;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UnityEngine.Vector3 pos1 = Livro1.transform.position;
        UnityEngine.Vector3 pos2 = Livro2.transform.position;
        UnityEngine.Vector3 pos3 = Livro3.transform.position;
        UnityEngine.Vector3 pos4 = Livro4.transform.position;
        UnityEngine.Vector3 pos5 = Livro5.transform.position;
        Livros = new GameObject[5] {Livro1, Livro2, Livro3, Livro4, Livro5};
    }

    // Update is called once per frame
    void Update()
    {
        if(!Click1)
        Click1 = Mouse.current.leftButton.wasPressedThisFrame && ((Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).x - Livro1.transform.position.x)) < 1) && ((Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).y - Livro1.transform.position.y)) < 4.5);

        if(!Click2)
        Click2 = Mouse.current.leftButton.wasPressedThisFrame && ((Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).x - Livro2.transform.position.x)) < 1) && ((Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).y - Livro2.transform.position.y)) < 4.5);

        if(!Click3)
        Click3 = Mouse.current.leftButton.wasPressedThisFrame && ((Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).x - Livro3.transform.position.x)) < 1) && ((Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).y - Livro3.transform.position.y)) < 4.5);

        if(!Click4)
        Click4 = Mouse.current.leftButton.wasPressedThisFrame && ((Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).x - Livro4.transform.position.x)) < 1) && ((Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).y - Livro4.transform.position.y)) < 4.5);
       
        if(!Click5)
        Click5 = Mouse.current.leftButton.wasPressedThisFrame && ((Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).x - Livro5.transform.position.x)) < 1) && ((Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).y - Livro5.transform.position.y)) < 4.5);
        
        if (GetComponent<Animator>().GetInteger("Livro Selecionado") != 0 && (Click1 || Click2 || Click3 || Click4 || Click5))
        {
            if (Click1)
            {
                postemp = Livros[GetComponent<Animator>().GetInteger("Livro Selecionado")-1].transform.position;
                Livros[GetComponent<Animator>().GetInteger("Livro Selecionado")].transform.position = Livro1.transform.position;
                Livro1.transform.position = postemp;
                Click1 = !Click1;
            }
            else if (Click2)
            {
                postemp = Livros[GetComponent<Animator>().GetInteger("Livro Selecionado")-1].transform.position;
                Livros[GetComponent<Animator>().GetInteger("Livro Selecionado")].transform.position = Livro2.transform.position;
                Livro2.transform.position = postemp;
                Click2 = !Click2;
                Livros[GetComponent<Animator>().GetInteger("Livro Selecionado")].transform.Translate(0, 1, 0);
                Livro2.transform.Translate(0, -1, 0);
            }

        }
    }
}
