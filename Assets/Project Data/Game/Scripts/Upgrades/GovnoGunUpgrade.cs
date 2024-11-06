using UnityEngine;
using Watermelon.Upgrades;

namespace Watermelon
{
    [CreateAssetMenu(fileName = "Govno Gun Upgrade", menuName = "Content/Upgrades/Govno Gun Upgrade")]
    public class GovnoGunUpgrade : BaseWeaponUpgrade
    {
        public override void Initialise()
        {

        }

        [System.Serializable]
        public class GovnoGunUpgradeStage : BaseWeaponUpgradeStage
        {

        }
    }
}