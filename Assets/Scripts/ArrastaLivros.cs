using System;
using System.Numerics;
using NUnit.Framework.Internal;
using Unity.Multiplayer.Center.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrastaLivros : MonoBehaviour
{
    public GameObject anc1;
    public GameObject anc2;
    public GameObject anc3;
    public GameObject anc4;
    public GameObject anc5;
    public GameObject Controler;
    public int BookID;

    int holding_book = 0;

    void Start()
    {
        UnityEngine.Vector3 pos1 = anc1.transform.position;
        UnityEngine.Vector3 pos2 = anc2.transform.position;
        UnityEngine.Vector3 pos3 = anc3.transform.position;
        UnityEngine.Vector3 pos4 = anc4.transform.position;
        UnityEngine.Vector3 pos5 = anc5.transform.position;
        
    }
    void Update()
    {
        int Selected = Controler.GetComponent<Animator>().GetInteger("Livro Selecionado");
        if (Selected == 0 && Mouse.current.leftButton.wasPressedThisFrame && (Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position).x) < 1) && (Mathf.Abs((Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position).y) < 4.5))
        {
            Selected = BookID;
            transform.Translate(0, 1, 0);
        }
        else if (Selected == BookID && Mouse.current.leftButton.wasPressedThisFrame)
        { 
            Selected = 0;
            transform.Translate(0, -1, 0);
        }
        
        Controler.GetComponent<Animator>().SetInteger("Livro Selecionado", Selected);

    }
}
