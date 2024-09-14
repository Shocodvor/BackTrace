using System;
using UnityEngine;
using Watermelon.LevelSystem;

namespace Watermelon.SquadShooter
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] EnemiesDatabase database;
        public static EnemiesDatabase Database => instance.database;

        private static EnemyController instance;
        public static bool IgnoreAttackAfterDamage = false; // used only by Creatives to ignore attack after damage

        private static LevelData currentLevelData;

        public GameObject Sphere;

        public void Start()
        {
         //   GameObject newObject = Instantiate(Sphere, new Vector3(0,0,0), Quaternion.identity) as GameObject;

        }

        public void Initialise()
        {
            instance = this;

            Character baseCharacter = CharactersController.GetCharacter(CharacterType.Character_01);
            database.InitialiseStatsRealation(baseCharacter.Upgrades[0].Stats.Health);
        }

        // set current character and weapon data - to be used in stats calculation for enemies that will be spawned in a moment
        public static void OnLevelWillBeStarted()
        {
            CharacterStats characterStats = CharactersController.SelectedCharacter.GetCurrentUpgrade().Stats;

            Database.SetCurrentCharacterStats(characterStats.Health, CharacterBehaviour.GetBehaviour().Weapon.Damage.Lerp(0.5f));
        }
    }
}