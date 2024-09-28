using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Watermelon.LevelSystem;
using Watermelon.SquadShooter;
using webgl;

namespace Watermelon
{
    public class UIGameOver : UIPage
    {
        [SerializeField] DotsBackground dotsBackground;
        [SerializeField] CanvasGroup contentCanvasGroup;

        [Space]
        [SerializeField] Button reviveButton;
        [SerializeField] Button continueButton;

        [Space] 
        [SerializeField] TMP_Text tapToContinueText;


        public CoinsView _coins;



        public override void Initialise()
        {
            reviveButton.onClick.AddListener(Revive);
            continueButton.onClick.AddListener(Replay);

          
        }

        #region Show/Hide
        public override void PlayShowAnimation()
        {
            dotsBackground.ApplyParams();

            contentCanvasGroup.alpha = 0.0f;
            contentCanvasGroup.DOFade(1.0f, 0.4f).SetDelay(0.1f);

            dotsBackground.BackgroundImage.color = Color.white.SetAlpha(0.0f);
            dotsBackground.BackgroundImage.DOFade(1.0f, 0.5f).OnComplete(delegate
            {
                reviveButton.enabled = true;
                UIController.OnPageOpened(this);
            });

            continueButton.enabled = false;
            reviveButton.enabled = false;

            tapToContinueText.alpha = 0;
            tapToContinueText.DOFade(1, 0.5f, 3).OnComplete(() => continueButton.enabled = true);

            Debug.Log("Coins Reaward is" +   LevelController.lastLevelMoneyCollected);
            // LevelController.CurrentLevelData.GetCoinsReward();
            AppManager.OnGameOver.Invoke(LevelController.lastLevelMoneyCollected);

            _coins.CView();




        }

        public override void PlayHideAnimation()
        {
            contentCanvasGroup.DOFade(0.0f, 0.2f);

            dotsBackground.BackgroundImage.DOColor(Color.black, 0.3f).OnComplete(delegate
            {
                UIController.OnPageClosed(this);
            });

          
        }
        #endregion

        #region Buttons 
        public void Replay()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            LevelController.OnGameplayFinish?.Invoke();
            GameController.OnReplayLevel();


           
        }

        public void Revive()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);
            
            Ads.Instance.ShowReward(GameController.OnRevive);
            //
            // AdsManager.ShowRewardBasedVideo((success) =>
            // {
            //     if (success)
            //     {
            //         GameController.OnRevive();
            //     }
            //     else
            //     {
            //         GameController.OnReplayLevel();
            //     }
            // });


        }
        #endregion
    }
}
