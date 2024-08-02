using UnityEngine;
using UnityEngine.UI;

public class PlantDisappearHandler : MonoBehaviour
{
    // Plant007 nesnesinin referans�
    public GameObject plant007;
    // UI Image bile�eninin referans�
    public Image uiImage;

    void Update()
    {
        // E�er plant007 nesnesi devre d��� b�rak�ld�ysa
        if (!plant007.activeSelf)
        {
            // UI Image rengini ye�il yap
            uiImage.color = Color.green;
        }
    }
}
