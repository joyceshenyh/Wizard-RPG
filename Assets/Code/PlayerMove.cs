using System;
using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager

public class PlayerMove : MonoBehaviour
{
    // grid length and height
    private Vector3 oneGridLength;
    private Vector3 oneGridHeight;
    
    // fire spell
    private GameObject spellPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set position to starting block
        transform.position = new Vector3(-8.2f, -4.2f, -0.5f);
        
        // each move should be 1 grid, store the corresponding distances in the fields
        var grid = FindAnyObjectByType<Grid>();
        oneGridLength = grid.CellToWorld(new Vector3Int(1, 0, 0)) - grid.CellToWorld(new Vector3Int(0, 0, 0));
        oneGridHeight = grid.CellToWorld(new Vector3Int(0, 1, 0)) - grid.CellToWorld(new Vector3Int(0, 0, 0));
        
        // load fire spell prefab
        spellPrefab = Resources.Load<GameObject>("FireSpellPrefab");
    }

    // Update is called once per frame
    void Update()
    {
        TryExit();
        
        TryMove();
        
        TryFire();
        
        // debug code for getting player position
        //if(Input.GetKeyDown(KeyCode.Q)) Debug.Log(transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // the collision object is a thunderbird
        if (collision.collider.GetComponent<ThunderBirdMove>() != null)
        {
            // decrease player health
            DataKeeper.UpdateData(healthChange: -10);
            
            // play a get-hit sound
            var hitClip = Resources.Load<AudioClip>("playerhit");
            Camera.main.GetComponent<AudioSource>().PlayOneShot(hitClip, 5);
            
            // destroy this thunderbird
            Destroy(collision.collider.gameObject);
        }
    }

    private void TryExit()
    {
        // check for able-to-exit conditions
        if (DataKeeper.buttonCount == 4)
        {
            // top block: 8.23, 4.52
            if (transform.position.x > 8.20f && transform.position.y > 4.50f && Input.GetKeyDown(KeyCode.Q))
            {
                transform.position += oneGridLength;
                DataKeeper.EndGame(true);
            }
        }
    }

    private void TryMove()
    {
        // WASD for moving
        if (Input.GetKeyDown(KeyCode.W)) 
            // only move up if the after-move position is within map boundaries
            // otherwise do nothing
            transform.position = (transform.position + oneGridHeight).y >= DataKeeper.maxY ? transform.position : transform.position + oneGridHeight;

        if (Input.GetKeyDown(KeyCode.D)) 
            // move right
            transform.position = (transform.position + oneGridLength).x >= DataKeeper.maxX ? transform.position : transform.position + oneGridLength;

        if (Input.GetKeyDown(KeyCode.S))
            // move down
            transform.position = (transform.position - oneGridHeight).y <= DataKeeper.minY ? transform.position : transform.position - oneGridHeight;
        
        if (Input.GetKeyDown(KeyCode.A))
            // move left
            transform.position = (transform.position - oneGridLength).x <= DataKeeper.minX ? transform.position : transform.position - oneGridLength;
    }

    private void TryFire()
    {
        // firing the spell
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (DataKeeper.SpellCount > 0)
            {
                // reduce spell count by 1
                DataKeeper.UpdateData(spellChange: -1);
                // create the spell from prefab
                Instantiate(spellPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
