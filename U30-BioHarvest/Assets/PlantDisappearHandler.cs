using UnityEngine;
using UnityEngine.UI;

public class PlantDisappearHandler : MonoBehaviour
{
    // Plant007 nesnesinin referansý
    public GameObject plant007;
    // UI Image bileþeninin referansý
    public Image uiImage;

    void Update()
    {
        // Eðer plant007 nesnesi devre dýþý býrakýldýysa
        if (!plant007.activeSelf)
        {
            // UI Image rengini yeþil yap
            uiImage.color = Color.green;
        }
    }
}
