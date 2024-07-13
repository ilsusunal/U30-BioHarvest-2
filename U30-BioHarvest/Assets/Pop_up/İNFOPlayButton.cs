using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class İNFOPlayButton : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(0/*yükelemek istediğimiz sahne numarası*/);
    }
}
