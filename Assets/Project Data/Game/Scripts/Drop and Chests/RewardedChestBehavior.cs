using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using webgl;
using Watermelon.LevelSystem;

namespace Watermelon.SquadShooter
{
    public class RewardedChestBehavior : AbstractChestBehavior
    {
        protected static readonly int IS_OPEN_HASH = Animator.StringToHash("IsOpen");

        [SerializeField] Animator rvAnimator;
        [SerializeField] Button rvButton;
        [SerializeField] Transform adHolder;
        [SerializeField] Canvas adCanvas;

        public Animator CapsClaim;


            

         private static UIGame uiGame;

        private void Awake()
        {
          //  rvButton.onClick.AddListener(OnButtonClick);
            // rvButton.onClick.AddListener(OnTutorialFinish);

            adHolder.transform.localScale = Vector3.zero;
        }

        private void LateUpdate()
        {
            adCanvas.transform.forward = Camera.main.transform.forward;
        }

        public override void Init(List<DropData> drop)
        {
            base.Init(drop);

            rvAnimator.transform.localScale = Vector3.zero;

            isRewarded = true;
        }

        public override void ChestApproached()
        {
            if (opened)
                return;

            animatorRef.SetTrigger(SHAKE_HASH);
            rvAnimator.SetBool(IS_OPEN_HASH, true);
        }

        public override void ChestLeft()
        {
            if (opened)
                return;

            animatorRef.SetTrigger(IDLE_HASH);
            rvAnimator.SetBool(IS_OPEN_HASH, false);

            Debug.Log("ChestLeft");
        }

        private void OnButtonClick()
        {

            AppManager.Instance.PayTicketAndStart((success) =>
             {
                 if (success)
                 {
                    opened = true;
            
                     animatorRef.SetTrigger(OPEN_HASH);
                    rvAnimator.SetBool(IS_OPEN_HASH, false);
            
                     Tween.DelayedCall(0.3f, () =>
                     {
                       DropResources();
                       particle.SetActive(false);


                       
                    //   Vibration.Vibrate(AudioController.Vibrations.shortVibration);
                     });
                 } 
             });

               uiGame = UIController.GetPage<UIGame>();
                       
              uiGame.UpdateCaps();
       
    }

    public void OnTutorialFinish ()

    {
      
        PlayerPrefs.SetString ("Drones", "Open");

         for (int i = 0; i < dropData.Count; i++)
                {

          if (dropData[i].dropType == DropableItemType.Currency)
                    {


                         for (int k =0; k<10;k++){   
                        int health = 100;
                          Drop.DropItem(new DropData() { dropType = DropableItemType.Heal, amount = health }, transform.position, Vector3.zero.SetY(Random.Range(0f, 360f)), DropFallingStyle.Coin, 0.3f, -1);

                         }

                    }

                }
      //   CapsClaim. Play ("1");

    }


    public void LoadRamdomWorld ()

    {

          CurrenciesController.Add(CurrencyType.Coin, LevelController.lastLevelMoneyCollected);
            AppManager.OnGameOver.Invoke(LevelController._pointsScore);
            LevelController._pointsScore = 0;
         //   LevelController.lastLevelMoneyCollected = 0;

                 uiGame = UIController.GetPage<UIGame>();
                       
                uiGame.UpdateCaps();

          

         if (PlayerPrefs.GetString (key: "Drones") == "Open")  // обучение закончено


                    {
                     //   if ( LevelController. lastLevelMoneyCollected > 0)
                       // {
                           // LevelController.LoadLevel(0,2); 
                           
                          LevelController.  LoadCurrentLevel();

                            GameController.OnReplayTutorialLevel();
                             // LevelController.OnGameplayStart?.Invoke();
                              LevelController.OnGameStarted();
                      //  }
                         
                            

                    }



    }


}
}