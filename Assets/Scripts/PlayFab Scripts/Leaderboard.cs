using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using System;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] GameObject row;
    [SerializeField] Transform tabel;
    [SerializeField] FloatVariable score;

    void Start()
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
            new StatisticUpdate {
                StatisticName = "Highscore",
                Value = Convert.ToInt32(score.value)
            }
        }
        }, result => OnStatisticsUpdated(result), FailureCallback);
    }

    private void OnStatisticsUpdated(UpdatePlayerStatisticsResult updateResult)
    {
        GetLeaderboard();
    }

    private void FailureCallback(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Highscore",
            StartPosition = 0,
            MaxResultsCount = 5

        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, FailureCallback);
    }
    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(Transform transform in tabel)
        {
            Destroy(transform);
        }
        foreach( var item in result.Leaderboard)
        {
            GameObject newRow = Instantiate(row, tabel);
            TMP_Text[] texts = newRow.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

        }
    }
}
