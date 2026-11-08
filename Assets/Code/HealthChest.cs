using UnityEngine;

public class HealthChest : MonoBehaviour
{
    private GameObject healthUIPrefab;
    private float enterTime;
    private float requiredStayTime;
    private bool isOpened;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthUIPrefab = Resources.Load<GameObject>("HealthChestUIPrefab");
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
                Instantiate(healthUIPrefab, transform.position, Quaternion.identity);
            
                // Player's health cannot pass beyond 100, only add health if health is not full
                if(DataKeeper.Health < 100)
                    DataKeeper.UpdateData(healthChange: 10);
            
                isOpened = true;
            }
        }
    }
}
