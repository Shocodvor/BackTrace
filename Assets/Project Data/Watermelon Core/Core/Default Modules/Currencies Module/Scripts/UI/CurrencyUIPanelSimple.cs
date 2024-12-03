using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Watermelon.LevelSystem;

namespace Watermelon
{
    [System.Serializable]
    public class CurrencyUIPanelSimple : MonoBehaviour
    {
        [SerializeField] CurrencyType currencyType;

        [Space]
        [SerializeField] bool updateOnChange = true;
        [SerializeField] bool useFormattedAmount = true;

        [Space]
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] TextMeshProUGUI ticketstext;

        [SerializeField] Image icon;

        public string Text { get => text.text; set => text.text = value; }
        public Sprite Icon { get => icon.sprite; set => icon.sprite = value; }

        private Currency currency;
        public Currency Currency => currency;

        public void Initialise()
        {
            currency = CurrenciesController.GetCurrency(currencyType);

            icon.sprite = currency.Icon;

            Redraw();
            Activate();

         
        }

        public void Redraw()
        {
            text.text = CurrenciesController.Get(CurrencyType.Coin).ToString();
         //   ticketstext.text = APIManager.ticketsAmount.ToString();  //для кэпсов
              ticketstext.text =  LevelController._diamonds.ToString();
           


        }

        public void SetAmount(int amount, bool format = true)
        {
            text.text = LevelController.lastLevelMoneyCollected.ToString();
           





           

        }

        public void Activate()
        {
            if(updateOnChange)
            {
                currency.OnCurrencyChanged += OnCurrencyAmountChanged;

               
            }
        }

        public void Disable()
        {
            if(updateOnChange)
            {
                currency.OnCurrencyChanged -= OnCurrencyAmountChanged;
            }
        }

        private void OnCurrencyAmountChanged(Currency currency, int amountDifference)
        {

        
            text.text = useFormattedAmount ? currency.AmountFormatted : currency.Amount.ToString();
           // capstext.text = LevelController._pointsScore.ToString();

           Debug.Log ("OnCurrencyAmountChanged");

           

        }
    }
}