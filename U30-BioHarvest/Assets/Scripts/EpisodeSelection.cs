using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EpisodeSelection : MonoBehaviour
{
    public Button episode2Button;
    public Button episode3Button;

    private void Start()
    {
        StartCoroutine(CheckEpisodeCompletion());
    }

    private IEnumerator CheckEpisodeCompletion()
    {
        string url = "https://66ac7cccf009b9d5c7323d43.mockapi.io/astra/episodes/episodes";
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
                Debug.Log("JSON Response: " + jsonResponse); // Debug: Print the JSON response

                EpisodeList episodes = JsonUtility.FromJson<EpisodeList>("{\"episodes\":" + jsonResponse + "}");

                bool episode1Completed = false;
                bool episode2Completed = false;

                foreach (var episode in episodes.episodes)
                {
                    Debug.Log("Episode ID: " + episode.id + ", Status: " + episode.status); // Debug: Print each episode status

                    if (episode.id == "1" && episode.status)
                    {
                        episode1Completed = true;
                    }
                    if (episode.id == "2" && episode.status)
                    {
                        episode2Completed = true;
                    }
                }

                episode2Button.interactable = episode1Completed;
                episode3Button.interactable = episode1Completed && episode2Completed;

                Debug.Log("Episode 1 completed: " + episode1Completed); // Debug: Print the completion status
                Debug.Log("Episode 2 completed: " + episode2Completed); // Debug: Print the completion status

            }
        }
    }
}

[System.Serializable]
public class Episode
{
    public string id;
    public string name;
    public bool status;
}

[System.Serializable]
public class EpisodeList
{
    public List<Episode> episodes;
}
public enum EpisodeName
{
    HarvestOfSeed,
    CrystalOfLife,
    LandOfTheBees


}
