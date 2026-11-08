using UnityEngine;

public class ChestLootUI : MonoBehaviour
{
    //private float creationTime;
    //private float displayTime; // allow removal after displayed for some amount of time
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //creationTime = Time.time;
        //displayTime = 1;
        
        // play a chest opening sound
        var chestClip = Resources.Load<AudioClip>("toggle_002");
        Camera.main.GetComponent<AudioSource>().PlayOneShot(chestClip, 5);
    }
}
