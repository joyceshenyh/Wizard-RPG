using UnityEngine;
using TMPro; // Text
using UnityEngine.SceneManagement; // SceneManager

public class DataKeeper : MonoBehaviour
{
    public static float Health { get; private set; }
    public static int SpellCount { get; private set; }
    public static int buttonCount { get; private set; }
    
    // the status text
    private static TMP_Text statusText;
    
    // lock icon at the exit
    private static GameObject exitLock;
    
    // how did the game end?
    public static bool isWin { get; private set; }
    
    // boundary coordinates for the game map
    public static float maxX, minX, maxY, minY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = 100;
        SpellCount = 2;
        buttonCount = 0;
        
        statusText = GetComponent<TMP_Text>();
        statusText.text = $"<color=#DB2500>Health</color><color=#FFFFFF>: {Health}</color>\n" + 
                          $"<color=#FFC038>Spell</color><color=#FFFFFF>: {SpellCount}</color>\n" + 
                          $"<color=#8AC2FF>Buttons</color><color=#FFFFFF>: {buttonCount} / 4</color>";
        
        exitLock = GameObject.FindWithTag("Finish");
        
        // record boundary coordinates for the game map
        minX = -9.20f;
        minY = -5.20f;
        maxX = 9.30f;
        maxY = 5.60f;
    }

    public static void UpdateData(float healthChange = 0, int spellChange = 0, int buttonChange = 0)
    {
        Health += healthChange;
        SpellCount += spellChange;
        buttonCount += buttonChange;
        statusText.text = $"<color=#DB2500>Health</color><color=#FFFFFF>: {Health}</color>\n" + 
                          $"<color=#FFC038>Spell</color><color=#FFFFFF>: {SpellCount}</color>\n" + 
                          $"<color=#8AC2FF>Buttons</color><color=#FFFFFF>: {buttonCount} / 4</color>";
    }

    void Update()
    {
        if (Health <= 0)
        {
            // game ends if player health become zero or negative
            EndGame(false);
        }
        
        if (buttonCount == 4)
        {
            // all buttons are pressed, the player can exit now
            Destroy(exitLock);
        }
    }

    public static void EndGame(bool win)
    {
        if (win) isWin = true;
        else isWin = false;
        
        SceneManager.LoadScene("GameEndScene");
    }
}
