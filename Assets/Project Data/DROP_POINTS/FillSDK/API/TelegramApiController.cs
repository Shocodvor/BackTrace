using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

public class TelegramApiController : Singleton<TelegramApiController>
{
    [DllImport("__Internal")]
    private static extern void OnClaimReward();
    public static event Action OnAppInitialized;
    public static bool IsAppInitialised { get; private set; }
    public static AppData AppData { get; private set; }


    private bool isReadyToTap;
    private float delay = 0.7f;
    private float touchTime;

    void Start()
    {
        Debug.Log($"Start AppKitController");
        DontDestroyOnLoad(this);
   #if UNITY_EDITOR
        string appData = JsonConvert.SerializeObject(new AppData { TelegramId =  995850795, Enviroment = "�" });
      //  Debug.Log($"In Editor Initialize");
        //InitializeApp("518055071"); //518055071  118255814
        gameObject.SendMessage("InitializeApp", appData);
    #endif

    }

    public void InitializeApp(string str)
    {

        AppData = JsonConvert.DeserializeObject<AppData>(str);
       // Debug.Log($"InitializeApp Telegram id: {AppData.TelegramId} Env: {AppData.Enviroment}");
        //AppData = new AppData{TelegramId = telegramId};
        IsAppInitialised = true;
        OnAppInitialized?.Invoke();
    }

}

[Serializable]
public class AppData
{
    [JsonProperty("telegramId")]
    public long TelegramId { get; set; }

    [JsonProperty("env")]//[JsonConverter(typeof(StringEnumConverter))]
    public string Enviroment { get; set; }
}

[Serializable]
public enum Env
{
    DEBUG,
    PRODUCTION
}
