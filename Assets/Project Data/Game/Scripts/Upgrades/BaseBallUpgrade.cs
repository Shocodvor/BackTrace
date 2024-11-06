using UnityEngine;
using Watermelon.Upgrades;

namespace Watermelon
{
    [CreateAssetMenu(fileName = "BaseBallUpgrade", menuName = "Content/Upgrades/BaseBallUpgrade")]
    public class BaseBallUpgrade : BaseWeaponUpgrade
    {
        public override void Initialise()
        {

        }

        [System.Serializable]
        public class BaseBallUpgradeStage : BaseWeaponUpgradeStage
        {

        }
    }
}