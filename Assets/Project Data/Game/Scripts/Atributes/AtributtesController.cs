using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Watermelon;
using webgl;

namespace Watermelon.SquadShooter
{
    public class AtributeController : MonoBehaviour
    {
        private const CharacterType DEFAULT_CHARACTER_TYPE = CharacterType.Character_03;

        private static AtributeController atributeController;

        [SerializeField] AtributeDatabase database;

        public static int BasePower { get; private set; }

        private static Character selectedCharacter;
        public static Character SelectedCharacter => selectedCharacter;

      //  public static Character LastUnlockedCharacter => atributeController.database.GetLastUnlockedCharacter();
      //  public static Character NextCharacterToUnlock => atributeController.database.GetNextCharacterToUnlock();

        private static CharacterGlobalSave characterSave;

      //  public static event CharacterCallback OnCharacterSelectedEvent;
     //   public static event CharacterCallback OnCharacterUpgradedEvent;

      //  private static List<CharacterUpgrade> keyUpgrades = new List<CharacterUpgrade>();

        public void Initialise()
        {
            atributeController = this;

            // Initialise characters database
            database.Initialise();

            Debug.Log ("InitialiseAtribiteContoller");

            // Get global save
            //TODO:Save
            //characterSave = SaveController.GetSaveObject<CharacterGlobalSave>("characters");
            characterSave = SaveLoad.LoadT<CharacterGlobalSave>("characters");

            // Check if character from save is unlocked
         //   if (IsCharacterUnlocked(characterSave.SelectedCharacterType))
          //  {
                // Load selected character from save
          //      selectedCharacter = database.GetCharacter(characterSave.SelectedCharacterType);
        //    }
         //   else
         //   {
                // Select default character
          //      selectedCharacter = database.GetCharacter(DEFAULT_CHARACTER_TYPE);
         //   }

            for (int i = 0; i < database.Atribute.Length; i++)
            {
                Atribute atribute = database.Atribute[i];

                for (int j = 0; j < atribute.Upgrades.Length; j++)
                {
                    if (atribute.Upgrades[j].Stats.KeyUpgradeNumber != -1)
                    {
                        //keyUpgrades.Add(atribute.Upgrades[j]);

                     //   if (atribute.Upgrades[j].Stats.KeyUpgradeNumber == 0)
                     //   {
                      //      BasePower = character.Upgrades[j].Stats.Power;
                     //   }
                    }
                }
            }

            //keyUpgrades.OrderBy(u => u.Stats.KeyUpgradeNumber);
        }

     //   public static bool IsCharacterUnlocked(CharacterType characterType)
       // {
       //     Character character = atributeController.database.GetCharacter(characterType);
          //  if (character != null)
             //   return character.IsUnlocked();

          //  return false;
      //  }

      //  public static void SelectCharacter(CharacterType characterType)
       // {
        //    if (selectedCharacter.Type == characterType)
         //       return;

           // Character character = atributeController.database.GetCharacter(characterType);
         //   if (character != null)
         //   {
          //      selectedCharacter = character;

           //     characterSave.SelectedCharacterType = characterType;

           //     CharacterBehaviour characterBehaviour = CharacterBehaviour.GetBehaviour();

            //    CharacterStageData characterStage = character.GetCurrentStage();
            //    CharacterUpgrade characterUpgrade = character.GetCurrentUpgrade();

              //  characterBehaviour.SetStats(characterUpgrade.Stats);
              //  characterBehaviour.SetGraphics(characterStage.Prefab, false, false);

                // Invoke select character callback
             //   OnCharacterSelectedEvent?.Invoke(characterType, selectedCharacter);
          //  }
          //  SaveLoad.SaveT(characterSave, "characters");
      //  }

      //  public static void OnCharacterUpgraded(Character character)
     //   {
       //     AudioController.PlaySound(AudioController.Sounds.upgrade);

       //     OnCharacterUpgradedEvent?.Invoke(character.Type, character);
     //   }

        public static AtributeDatabase GetDatabase()
        {
            return atributeController.database;
        }

     //   public static Character GetCharacter(CharacterType characterType)
      //  {
      //      return atributeController.database.GetCharacter(characterType);
      //  }

      //  public static int GetCharacterIndex(CharacterType characterType)
      //  {
       //     return System.Array.FindIndex(atributeController.database.Characters, x => x.Type == characterType);
    //    }

      //  public static int GetCeilingUpgradePower(int currentKeyUpgrade)
      //  {
          //  for (int i = keyUpgrades.Count - 1; i >= 0; i--)
          //  {
            //    if (keyUpgrades[i].Stats.KeyUpgradeNumber <= currentKeyUpgrade)
             //   {
               //     return keyUpgrades[i].Stats.Power;
             //   }
           // }

          //  return keyUpgrades[0].Stats.Power;
      //  }

      //  public delegate void CharacterCallback(CharacterType characterType, Character character);
    }
}