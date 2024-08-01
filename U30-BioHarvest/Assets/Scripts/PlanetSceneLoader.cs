using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetSceneLoader : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
    }
    // Bu metodu butonun OnClick() eventi ile çaðýrabilirsiniz
    public void goTutorialScene()
    {
        // Belirtilen sahneye geçiþ yap
        SceneManager.LoadScene("Tutorial Scene");
    }
    public void goJungleMission()
    {
        // Belirtilen sahneye geçiþ yap
        SceneManager.LoadScene("Jungle Mission");
    }
    public void goWaterMission()
    {
        // Belirtilen sahneye geçiþ yap
        SceneManager.LoadScene("Water Mission");
    }
    public void goMountainMission()
    {
        // Belirtilen sahneye geçiþ yap
        SceneManager.LoadScene("Mountain Mission");
    }
}
