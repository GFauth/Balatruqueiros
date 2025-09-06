using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class MudançadeLivors : MonoBehaviour
{

    [Header("Genesis")]
    public GameObject Genesis;
    [Header("The Second Sex")]
    public GameObject The_Second_Sex;
    [Header("Between Heaven and Hell")]
    public GameObject Between_Heaven_and_Hell;
    [Header("The four Horsemen of the Apocalypse")]
    public GameObject The_four_Horsemen_of_the_Apocalypse;
    [Header("Eternity's end")]
    public GameObject Eternitys_end;

    

    [Header("Gameobject do livro do GameObject")]
    public GameObject Livro;

    Vector3 Temp;
     int flag = 0;




    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            Vector2 posicaoDoMouseNoMundo = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(posicaoDoMouseNoMundo, Vector2.zero);

            if (hit.collider != null && hit.collider.name == Livro.name && flag == 0)
            {
                Temp = Livro.transform.position;
                Debug.Log("click no livro");

                flag = 1;

            }

            if (hit.collider != null && hit.collider.name == Genesis.name && flag == 1)
            {
                
                Livro.transform.position = Genesis.transform.position;
                Genesis.transform.position = Temp;
                flag = 0;
            }
            if (hit.collider != null && hit.collider.name == The_Second_Sex.name && flag == 1)
            {
                
                Livro.transform.position = The_Second_Sex.transform.position;
                The_Second_Sex.transform.position = Temp;
                flag = 0;
            }

            if (hit.collider != null && hit.collider.name == Between_Heaven_and_Hell.name && flag == 1)
            {
                
                Livro.transform.position = Between_Heaven_and_Hell.transform.position;
                Between_Heaven_and_Hell.transform.position = Temp;
                flag = 0;
            }

            if (hit.collider != null && hit.collider.name == The_four_Horsemen_of_the_Apocalypse.name && flag == 1)
            {
                
                Livro.transform.position = The_four_Horsemen_of_the_Apocalypse.transform.position;
                The_four_Horsemen_of_the_Apocalypse.transform.position = Temp;
                flag = 0;
            }

            if (hit.collider != null && hit.collider.name == Eternitys_end.name && flag == 1)
            {
                
                Livro.transform.position = Eternitys_end.transform.position;
                Eternitys_end.transform.position = Temp;
                flag = 0;
            }

        }
    }
}
