using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Watermelon.LevelSystem;

public class CoinsView : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI text;



    public void CView ()
    {
        text.text = LevelController.lastLevelMoneyCollected.ToString();

    }

   
 
}
