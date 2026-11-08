using UnityEngine;

public class ThunderBirdMove : MonoBehaviour
{
    // player object, used to find player position and direct thunderbird movement
    private GameObject player;
    
    // the time when this thunderbird instance is spawned
    private float spawnTime;
    
    // thunderbirds will despawn if they were in game for longer than this time
    public float surviveTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnTime = Time.time;
        surviveTime = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime + surviveTime)
        {
            Destroy(gameObject); // destroy this thunderbird
        }
        
        // move towards the player's current position
        var playerDirection = (player.transform.position - transform.position).normalized;
        var moveRandomFactor = Random.Range(0.003f, 0.006f); // this prevents all thunderbirds moving at the exact same speed
        transform.position += new Vector3(playerDirection.x * moveRandomFactor, playerDirection.y * moveRandomFactor, 0);
    }
}
