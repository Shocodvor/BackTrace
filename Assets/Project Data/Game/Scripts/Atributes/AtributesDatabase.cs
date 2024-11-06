using System.Linq;
using UnityEngine;
using Watermelon;

namespace Watermelon.SquadShooter
{
    [CreateAssetMenu(fileName = "Atribute Database", menuName = "Content/Atributes/Atribute Database")]
    public class AtributeDatabase : ScriptableObject
    {
        [SerializeField] Atribute[] atributes;
        public Atribute[] Atribute => atributes;


        public void Initialise()
        {

            Debug.Log ("InitialiseDataAtributes");

            atributes.OrderBy(c => c.RequiredLevel);

            for (int i = 0; i < atributes.Length; i++)
            {
                atributes[i].Initialise();
            }
        }

        public Atribute GetCharacter(AtributeType atributeType)
        {
            for (int i = 0; i < atributes.Length; i++)
            {
                if (atributes[i].Type == atributeType)
                    return atributes[i];
            }

            return null;
        }

    //    public Character GetLastUnlockedCharacter()
      //  {
        //    for (int i = 0; i < atributes.Length; i++)
        //    {
            //    if (atributes[i].RequiredLevel > ExperienceController.CurrentLevel)
             //   {
                    //return atributes[Mathf.Clamp(i - 1, 0, atributes.Length - 1)];
             //   }
          //  }

          //  return null;
       // }

     //   public Character GetNextCharacterToUnlock()
      //  {
       //     for (int i = 0; i < atributes.Length; i++)
        //    {
          //      if (atributes[i].RequiredLevel > ExperienceController.CurrentLevel)
          //      {
           //         return atributes[i];
           //     }
         //   }

          //  return null;
      //  }
    }
}
