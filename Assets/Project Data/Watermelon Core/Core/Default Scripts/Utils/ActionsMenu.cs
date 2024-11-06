using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif
using UnityEngine;
using Watermelon.LevelSystem;
using Watermelon.SquadShooter;

namespace Watermelon
{
    public static class ActionsMenu
    {
#if UNITY_EDITOR
        [MenuItem("Actions/Remove Save  [not runtime]", priority = 1)]
        private static void RemoveSave()
        {
            if (!Application.isPlaying)
            {
                Serializer.DeleteFileAtPDP("save");

                PlayerPrefs.DeleteAll();
            }
        }

        [MenuItem("Actions/Lots of Money", priority = 21)]
        private static void LotsOfMoney()
        {
            if (Application.isPlaying)
            {
               
            }
        }

        [MenuItem("Actions/No Money", priority = 22)]
        private static void NoMoney()
        {
            if (Application.isPlaying)
            {
              
            }
        }

        //[MenuItem("Actions/Lots of Gems", priority = 23)]
        //private static void LotsOfGems()
        //{
        //    if (Application.isPlaying)
        //    {
        //      
        //    }
        //}

        //[MenuItem("Actions/No Gems", priority = 24)]
        //private static void NoGems()
        //{
        //    if (Application.isPlaying)
        //    {
        //      
        //    }
        //}

        //[MenuItem("Actions/Get 10 XP", priority = 35)]
        //private static void Get10XP()
        //{
        //    if (Application.isPlaying)
        //    {
        //       
        //    }
        //}

        [MenuItem("Actions/Next XP Lvl", priority = 36)]
        private static void GetNextLevel()
        {
            if (Application.isPlaying)
            {
                ExperienceController.SetLevelDev(ExperienceController.CurrentLevel + 1);
            }
        }

        [MenuItem("Actions/Set No XP", priority = 37)]
        private static void NoXP()
        {
            if (Application.isPlaying)
            {
               
            }
        }

        //[MenuItem("Actions/Set Max Lvl", priority = 38)]
        //private static void SetMaxLevel()
        //{
        //    if (Application.isPlaying)
        //    {
        //        ExperienceController.SetLevelDev(10);
        //        EditorApplication.ExitPlaymode();
        //    }
        //}

        //[MenuItem("Actions/Skip Tutor", priority = 41)]
        //private static void SkipTutor()
        //{
        //    if (Application.isPlaying)
        //    {
        //        //LevelController.SetTutorialCompletedDev();

        //        EditorApplication.ExitPlaymode();

        //        SaveController.DevAllowRV();
        //    }
        //}




        //[MenuItem("Actions/Alow RV", priority = 95)]
        //private static void AllowRV()
        //{
        //    SaveController.DevAllowRV();
        //}

        //[MenuItem("Actions/Disable RV", priority = 96)]
        //private static void DisableRV()
        //{
        //    SaveController.DevDisableRV();
        //}



        [MenuItem("Actions/All Weapons", priority = 51)]
        private static void UnlockAllWeapons()
        {
            if (Application.isPlaying)
            {
                WeaponsController.UnlockAllWeaponsDev();
                UIController.GetPage<UIWeaponPage>().UpdateWeaponPanel();
            }
        }

        [MenuItem("Actions/Prev Level (menu) [P]", priority = 71)]
        public static void PrevLevel()
        {
           
        }

        [MenuItem("Actions/Next Level (menu) [N]", priority = 72)]
        public static void NextLevel()
        {
           
        }

        [MenuItem("Actions/Skip Room [R]", priority = 73)]
        public static void SkipRoom()
        {
            //LevelController.SkipRoomDev();
        }

        [MenuItem("Actions/Game Scene", priority = 100)]
        private static void GameScene()
        {
            EditorSceneManager.OpenScene(@"Assets\Project Data\Game\Scenes\Game.unity");
        }

        [MenuItem("Actions/Print Shorcuts", priority = 150)]
        private static void PrintShortcuts()
        {
         
        }

#endif
    }
}