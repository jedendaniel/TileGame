using UnityEngine;

public class GUI : MonoBehaviour
{
    public void Display()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
