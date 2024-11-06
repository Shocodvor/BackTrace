using UnityEngine;
using Watermelon.Upgrades;

namespace Watermelon
{
    [CreateAssetMenu(fileName = "NewOneUpgrade", menuName = "Content/Upgrades/NewOneUpgrade")]
    public class NewOneUpgrade : BaseWeaponUpgrade
    {
        public override void Initialise()
        {

        }

        [System.Serializable]
        public class NewOneUpgradeStage : BaseWeaponUpgradeStage
        {

        }
    }
}