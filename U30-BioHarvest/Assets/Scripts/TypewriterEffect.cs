using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI[] textMeshPros; 
    public float typingSpeed = 0.05f;

    private void Start()
    {
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (TextMeshProUGUI textMeshPro in textMeshPros)
        {
            if (textMeshPro != null)
            {
                string fullText = textMeshPro.text;
                textMeshPro.text = ""; 

                foreach (char letter in fullText.ToCharArray())
                {
                    textMeshPro.text += letter; 
                    yield return new WaitForSeconds(typingSpeed); 
                }
                yield return new WaitForSeconds(0.5f); 
            }
        }
    }
}
