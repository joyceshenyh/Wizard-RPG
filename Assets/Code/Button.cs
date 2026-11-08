using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    private float enterTime;
    public float requiredStayTime;

    private void Start()
    {
        requiredStayTime = 2;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log($"Current time: {Time.time}, need to stay until {enterTime + requiredStayTime}");
        // collision is done by player
        if (collision.tag == "Player")
        {
            // player has stayed for long enough
            if (Time.time >= enterTime + requiredStayTime)
            {
                //Debug.Log($"Stayed for long enough! The time is {Time.time} which is larger than {enterTime + requiredStayTime}");
                // update button count
                DataKeeper.UpdateData(buttonChange: 1);
                
                // play a button press sound
                var buttonClip = Resources.Load<AudioClip>("confirmation_001");
                Camera.main.GetComponent<AudioSource>().PlayOneShot(buttonClip, 8);
            
                // delete this button from map
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // record entry time if the collision is done by player
        if(collision.tag == "Player") enterTime = Time.time;
        
        //Debug.Log($"Entered: {enterTime}");
    }
}
