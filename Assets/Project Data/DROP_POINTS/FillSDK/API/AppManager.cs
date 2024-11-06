using System;
using System.Collections;
using UnityEngine;

public class AppManager : Singleton<AppManager>
{
    public static Action<int> OnTicketUpdated;
    public static Action<int> OnGameOver;

    protected override void Setup()
    {
        TelegramApiController.OnAppInitialized += TelegramApiControllerOnOnAppInitialized;
        OnGameOver += ClaimReward;
        Debug.Log("AppManager setup");
    }

    private void TelegramApiControllerOnOnAppInitialized()
    {
        Debug.Log("StartApp");
        StartCoroutine(StartApp());
    }

    public void PayTicketAndStart(Action<bool> callback)
    {
        StartCoroutine(APIManager.Instance.PayTicket(callback));

    }

    public void ClaimReward(int value)
    {
        StartCoroutine(APIManager.Instance.ClaimReward(value, () => { Debug.Log("Claimed"); }));
    }

    IEnumerator StartApp()
    {
        yield return APIManager.Instance.GetInfo(user => { OnTicketUpdated?.Invoke(user.Tickets); });
        Debug.Log("StartAppAPIManager");


    }
}