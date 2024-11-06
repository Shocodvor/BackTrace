using UnityEngine;
using Watermelon.Upgrades;

namespace Watermelon
{
    [CreateAssetMenu(fileName = "SMGUpgrade", menuName = "Content/Upgrades/SMGUpgrade")]
    public class SMGUpgrade : BaseWeaponUpgrade
    {
        public override void Initialise()
        {

        }

        [System.Serializable]
        public class SMGUpgradeStage : BaseWeaponUpgradeStage
        {

        }
    }
}