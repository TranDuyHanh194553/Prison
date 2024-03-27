using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Analytics;


public class UGS_Analytics : MonoBehaviour
{
    public int currentLevel;
    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            GiveConsent(); //Get user consent according to various legislations
        }
        catch (ConsentCheckException e)
        {
            Debug.Log(e.ToString());
        }
    }

    public void LevelCompletedCustomEvent()
    {
        // Define Custom Parameters
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "levelName", currentLevel.ToString()},
             { "timeToFinish", Time.time }
        };

        // The ‘levelCompleted’ event will get cached locally
        //and sent during the next scheduled upload, within 1 minute
        AnalyticsService.Instance.CustomData("levelCompleted", parameters);
        // You can call Events.Flush() to send the event immediately
        // AnalyticsService.Instance.Flush();
    }

    public void DeadReasonCustomEvent(string deadBecauseOf)
    {
        // Define Custom Parameters
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "levelName", currentLevel.ToString()},
             { "deadBy", deadBecauseOf.ToString()}
        };

        // The ‘levelCompleted’ event will get cached locally
        //and sent during the next scheduled upload, within 1 minute
        AnalyticsService.Instance.CustomData("deadReason", parameters);
        // You can call Events.Flush() to send the event immediately
        // AnalyticsService.Instance.Flush();
    }


    public void RestartCountCustomEvent(int count)
    {
        // Define Custom Parameters
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "levelName", currentLevel.ToString()},
             { "retryCount", count}             
        };
        // The ‘levelCompleted’ event will get cached locally
        //and sent during the next scheduled upload, within 1 minute
        AnalyticsService.Instance.CustomData("retryInLevel", parameters);
        // You can call Events.Flush() to send the event immediately
        // AnalyticsService.Instance.Flush();
    }



    public void FlushData()
    {
        AnalyticsService.Instance.Flush();
    }

    public void GiveConsent()
    {
  // Call if consent has been given by the user
        AnalyticsService.Instance.StartDataCollection();
        Debug.Log($"Consent has been provided. The SDK is now collecting data!");
    }

}
