using UnityEngine;

public class SwapManager : MonoBehaviour
{
    public static SwapManager Instance;

    private GameObject selectedObject1 = null;
    private GameObject selectedObject2 = null;

    private Vector3 originalPos1;

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

    public void Select(GameObject obj)
    {
        if (selectedObject1 == null)
        {
            // First object selected
            selectedObject1 = obj;
            originalPos1 = selectedObject1.transform.position;
            
            // Raise the object to indicate it's selected
            selectedObject1.transform.position += Vector3.up * 0.5f;

            Debug.Log("Objeto 1 selecionado: " + selectedObject1.name);
        }
        else if (selectedObject2 == null && obj != selectedObject1)
        {
            // Second object selected
            selectedObject2 = obj;

            Debug.Log("Objeto 2 selecionado: " + selectedObject2.name);
            
            SwapObjects();
        }
        else if (obj == selectedObject1)
        {
            // Deselect if the same object is clicked again
            Deselect();
        }
    }

    private void SwapObjects()
    {
        // Get the position of the second object before swapping
        Vector3 originalPos2 = selectedObject2.transform.position;

        // Perform the swap
        selectedObject1.transform.position = originalPos2;
        selectedObject2.transform.position = originalPos1;

        Debug.Log("Trocando " + selectedObject1.name + " com " + selectedObject2.name);

        // Reset the selection variables
        selectedObject1 = null;
        selectedObject2 = null;
    }

    private void Deselect()
    {
        // Return the object to its original position
        selectedObject1.transform.position = originalPos1;
        
        selectedObject1 = null;
        Debug.Log("Seleção cancelada.");
    }
}