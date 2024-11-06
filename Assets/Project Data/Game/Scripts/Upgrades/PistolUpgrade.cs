using UnityEngine;
using Watermelon.Upgrades;

namespace Watermelon
{
    [CreateAssetMenu(fileName = "Pistol Upgrade", menuName = "Content/Upgrades/Pistol Upgrade")]
    public class PistolUpgrade : BaseWeaponUpgrade
    {
        public override void Initialise()
        {

        }

        [System.Serializable]
        public class PistolUpgradeStage : BaseWeaponUpgradeStage
        {

        }
    }
}