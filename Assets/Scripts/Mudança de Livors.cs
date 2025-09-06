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




    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            Vector2 posicaoDoMouseNoMundo = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(posicaoDoMouseNoMundo, Vector2.zero);

            if (hit.collider != null && hit.collider.name == Livro.name)
            {

                if(hit.collider != null && hit.collider.name == Genesis.name)
                {
                    Temp = Livro .transform.position;
                    Livro.transform.position = Genesis.transform.position;
                    Genesis.transform.position = Temp;
                }

                if (hit.collider != null && hit.collider.name == The_Second_Sex.name)
                {
                    Temp = Livro.transform.position;
                    Livro.transform.position = The_Second_Sex.transform.position;
                    The_Second_Sex.transform.position = Temp;
                }

                if (hit.collider != null && hit.collider.name == Between_Heaven_and_Hell.name)
                {
                    Temp = Livro.transform.position;
                    Livro.transform.position = Between_Heaven_and_Hell.transform.position;
                    Between_Heaven_and_Hell.transform.position = Temp;
                }

                if (hit.collider != null && hit.collider.name == The_four_Horsemen_of_the_Apocalypse.name)
                {
                    Temp = Livro.transform.position;
                    Livro.transform.position = The_four_Horsemen_of_the_Apocalypse.transform.position;
                    The_four_Horsemen_of_the_Apocalypse.transform.position = Temp;
                }

                if (hit.collider != null && hit.collider.name == Eternitys_end.name)
                {
                    Temp = Livro.transform.position;
                    Livro.transform.position = Eternitys_end.transform.position;
                    Eternitys_end.transform.position = Temp;
                }
            }

        }


    }
}
