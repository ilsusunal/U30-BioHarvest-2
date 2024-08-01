using UnityEngine;
using UnityEngine.UI;

public class AstraSitMissio : MonoBehaviour
{
    // astrasit nesnesinin referansý
    public GameObject AstraSit;
    // UI Image bileþeninin referansý
    public Image uiImage;

    void Update()
    {
        // Eðer astrasit nesnesi açýlýrsa
        if (AstraSit.activeSelf)
        {
            // UI Image rengini yeþil yap
            uiImage.color = Color.green;
        }
    }
}