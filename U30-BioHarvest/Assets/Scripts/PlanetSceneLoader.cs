using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetSceneLoader : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
    }
    // Bu metodu butonun OnClick() eventi ile �a��rabilirsiniz
    public void goTutorialScene()
    {
        // Belirtilen sahneye ge�i� yap
        SceneManager.LoadScene("Tutorial Scene");
    }
    public void goJungleMission()
    {
        // Belirtilen sahneye ge�i� yap
        SceneManager.LoadScene("Jungle Mission");
    }
    public void goWaterMission()
    {
        // Belirtilen sahneye ge�i� yap
        SceneManager.LoadScene("Water Mission");
    }
    public void goMountainMission()
    {
        // Belirtilen sahneye ge�i� yap
        SceneManager.LoadScene("Mountain Mission");
    }
}
