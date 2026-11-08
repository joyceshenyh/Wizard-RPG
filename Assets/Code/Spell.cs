using System;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private float instantiateTime;
    private float surviveTime;
    private GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instantiateTime = Time.time;
        surviveTime = 5;
        player = GameObject.FindGameObjectWithTag("Player");
        
        // play a firing sound
        var spellClip = Resources.Load<AudioClip>("LEGIT_FIR_Fire_Staff 3-Audio");
        Camera.main.GetComponent<AudioSource>().PlayOneShot(spellClip, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // spell only lives for 5 seconds
        if(Time.time > instantiateTime + surviveTime) Destroy(gameObject);
        
        // make the spell follow the player
        transform.position = player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<ThunderBirdMove>() != null)
        {
            // hit a thunderbird! The bird dies
            Destroy(collision.collider.gameObject);
            // Make the spell despawn as well?
            Destroy(gameObject);
        }
    }
}
