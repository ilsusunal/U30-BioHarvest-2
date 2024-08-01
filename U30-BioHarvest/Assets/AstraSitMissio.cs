using UnityEngine;
using UnityEngine.UI;

public class AstraSitMissio : MonoBehaviour
{
    // astrasit nesnesinin referans�
    public GameObject AstraSit;
    // UI Image bile�eninin referans�
    public Image uiImage;

    void Update()
    {
        // E�er astrasit nesnesi a��l�rsa
        if (AstraSit.activeSelf)
        {
            // UI Image rengini ye�il yap
            uiImage.color = Color.green;
        }
    }
}