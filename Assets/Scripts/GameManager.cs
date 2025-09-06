using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    [Header("Estados Globais")]
    public bool AgarrarAlicate = true; // true = pode, false = nn

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}