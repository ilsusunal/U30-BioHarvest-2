using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string playerTag = "Player"; // Oyuncu objesinin tag'i
    public GameObject panel;
    public GameObject canvasF;
    public EpisodeName episodeName;

    private string url = "https://66ac7cccf009b9d5c7323d43.mockapi.io/astra/episodes/episodes";

    private void Start()
    {
        panel.SetActive(false);
        canvasF.SetActive(true);
    }
    public void OpenCanvas()
    {
        canvasF.SetActive(false);
        panel.SetActive(true);
    }



    private void Update()
    {
        if (panel.activeSelf && Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Changing scene");
            StartCoroutine(UpdateEpisodeStatus());
        }
    }

    private IEnumerator UpdateEpisodeStatus()
    {
        // Fetch the current list of episodes
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string jsonResponse = www.downloadHandler.text;
                Debug.Log("JSON Response: " + jsonResponse);

                List<Episode> episodeList = JsonUtility.FromJson<EpisodeList>("{\"episodes\":" + jsonResponse + "}").episodes;

                // Find and update the specific episode
                string episodeId = GetEpisodeId(episodeName);
                bool episodeFound = false;
                foreach (var episode in episodeList)
                {
                    if (episode.id == episodeId)
                    {
                        episode.status = true; // Update the status
                        episodeFound = true;
                        break;
                    }
                }

                if (!episodeFound)
                {
                    Debug.LogError("Episode not found!");
                    yield break;
                }

                // Convert updated episode list to JSON
                string updatedJson = JsonUtility.ToJson(new EpisodeList { episodes = episodeList });

                // Send updated list back to the server
                using (UnityWebRequest putRequest = new UnityWebRequest(url, "PUT"))
                {
                    byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(updatedJson);
                    putRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
                    putRequest.downloadHandler = new DownloadHandlerBuffer();
                    putRequest.SetRequestHeader("Content-Type", "application/json");

                    yield return putRequest.SendWebRequest();

                    if (putRequest.result != UnityWebRequest.Result.Success)
                    {
                        Debug.Log(putRequest.error);
                    }
                    else
                    {
                        Debug.Log("PUT request complete!");
                        SceneManager.LoadScene("SpaceMissionMenu");
                    }
                }
            }
        }
    }

    private string GetEpisodeId(EpisodeName episodeName)
    {
        switch (episodeName)
        {
            case EpisodeName.HarvestOfSeed:
                return "1";
            case EpisodeName.CrystalOfLife:
                return "2";
            case EpisodeName.LandOfTheBees:
                return "3";
            default:
                return "";
        }
    }
}

