using UnityEngine;
using Watermelon.SquadShooter;
using webgl;

namespace Watermelon.LevelSystem
{
    [CreateAssetMenu(fileName = "Level Tutorial Behaviour", menuName = "Content/New Level/Behaviours/Tutorial")]
    public sealed class TutorialLevelSpecialBehaviour : LevelSpecialBehaviour, ITutorial
    {
        [SerializeField] TutorialID tutorialId;
        public TutorialID TutorialID => tutorialId;

        [System.NonSerialized]
        private bool isInitialised;
        public bool IsInitialised => isInitialised;

        private Transform finishPointTransform;
        private TutorialLabelBehaviour tutorialLabelBehaviour;

        public bool IsActive => saveData.isActive;
        public bool IsFinished => saveData.isFinished;
        public int Progress => saveData.progress;



        private TutorialBaseSave saveData;

        private LineNavigationArrowCase arrowCase;

        private CharacterBehaviour characterBehaviour;
        private BaseEnemyBehavior enemyBehavior;

        private AbstractChestBehavior chestBehavior;
        
        public void Initialise()
        {
            isInitialised = true;

            // Load save file
            //TODO:Save
            //saveData = SaveController.GetSaveObject<TutorialBaseSave>(string.Format(ITutorial.SAVE_IDENTIFIER, tutorialId.ToString()));
            saveData = SaveLoad.LoadT<TutorialBaseSave>(string.Format(ITutorial.SAVE_IDENTIFIER, tutorialId.ToString()));
        }

        public void StartTutorial()
        {
            if (saveData.isFinished) return;
            LevelController.OnGameplayStart?.Invoke();
            // Activate tutorial
            saveData.isActive = true;

            characterBehaviour = CharacterBehaviour.GetBehaviour();

            // Force game start
            LevelController.OnGameStarted(immediately: true);
            SaveLoad.SaveT(saveData, string.Format(ITutorial.SAVE_IDENTIFIER, tutorialId.ToString()));
        }

        private void OnEnemyDied(BaseEnemyBehavior enemy)
        {

            
                 chestBehavior = ActiveRoom.chests[0];

                  

                

   if (enemy == enemyBehavior)
            {
                BaseEnemyBehavior.OnDiedEvent -= OnEnemyDied;

                if (arrowCase != null)
                {
                    arrowCase.DisableArrow();
                    arrowCase = null;
                }
                tutorialLabelBehaviour.Disable();

                arrowCase = NavigationArrowController.RegisterLineArrow(characterBehaviour.transform, (finishPointTransform.position));

                 ActiveRoom.ExitPointBehaviour.OnExitActivated();


                LevelController.OnPlayerExitLevelEvent += OnPlayerExitLevel;

                 FinishTutorial();
            }
        }

        private void OnPlayerExitLevel()
        {
            LevelController.OnPlayerExitLevelEvent -= OnPlayerExitLevel;

            if (arrowCase != null)
            {
                arrowCase.DisableArrow();
                arrowCase = null;
            }

            FinishTutorial();
        }

        public void FinishTutorial()
        {

           
         
            saveData.isFinished = true;

            isInitialised = false;
            SaveLoad.SaveT(saveData, string.Format(ITutorial.SAVE_IDENTIFIER, tutorialId.ToString()));
            LevelController.IncreaseLevelInSave();
         
        }

        public void Unload()
        {
            if (arrowCase != null)
                arrowCase.DisableArrow();
        }

        public override void OnLevelCompleted()
        {

        }

        public override void OnLevelFailed()
        {

        }

        public override void OnLevelInitialised()
        {
            isInitialised = false;

            TutorialController.ActivateTutorial(this);
        }

        public override void OnLevelLoaded()
        {

         

          //  finishPointTransform = ActiveRoom.  activeObjects [2].transform;

          finishPointTransform = GameObject.FindGameObjectWithTag("PedestalInGame").GetComponent<Transform> ();
          

            if(isInitialised)
                StartTutorial();
        }

        public override void OnLevelStarted()
        {
            if (saveData.isFinished) return;

            LevelController.EnableManualExitActivation();

            enemyBehavior = ActiveRoom.Enemies[0];

            chestBehavior = ActiveRoom.chests[0];



            arrowCase = NavigationArrowController.RegisterLineArrow(characterBehaviour.transform, chestBehavior.transform.position);
            arrowCase.FixArrowToTarget(chestBehavior.transform);

            tutorialLabelBehaviour = TutorialController.CreateTutorialLabel(TextTranslator.GetText("Открой сундук", "Open the chest"), chestBehavior.transform, new Vector3(0, 20.0f, 0));




            BaseEnemyBehavior.OnDiedEvent += OnEnemyDied;

          //  AbstractChestBehavior.OnChestOpenedEvent += ChestTutorialOpen;


        }

        public void ChestTutorialOpen ()
        {

     

        }




        public override void OnLevelUnloaded()
        {

        }

        public override void OnRoomEntered()
        {

           

        }

        public override void OnRoomLeaved()
        {

        }
    }
}
