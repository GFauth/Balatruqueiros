using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        SwapManager.Instance.Select(this.gameObject);
    }
}