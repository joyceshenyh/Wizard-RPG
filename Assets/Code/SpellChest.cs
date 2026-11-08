using UnityEngine;

public class SpellChest : MonoBehaviour
{
    private GameObject spellUIPrefab;
    private float enterTime;
    private float requiredStayTime;
    private bool isOpened;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spellUIPrefab = Resources.Load<GameObject>("FireSpellChestUIPrefab");
        requiredStayTime = 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enterTime = Time.time;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isOpened && Time.time > enterTime + requiredStayTime)
            {
                Instantiate(spellUIPrefab, transform.position, Quaternion.identity);
            
                DataKeeper.UpdateData(spellChange: 1);
            
                isOpened = true;
            }
        }
    }
}
