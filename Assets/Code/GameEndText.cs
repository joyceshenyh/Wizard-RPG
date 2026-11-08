using UnityEngine;
using TMPro; // Text

public class GameEndText : MonoBehaviour
{
    private TMP_Text endText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endText = GetComponent<TMP_Text>();
        
        if(DataKeeper.isWin)
        {
            endText.text = "<color=#8AC2FF>You Win!</color>\n"
                           + "<color=#FFFFFF>Congratulations!</color>";
        }
        else
        {
            endText.text = "<color=#DB2500>Game Over</color>\n" +
                           "<color=#FFFFFF>Would you like to try again?</color>";
        }
    }
}
