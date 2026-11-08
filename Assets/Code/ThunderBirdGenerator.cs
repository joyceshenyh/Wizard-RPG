using UnityEngine;

public class ThunderBirdGenerator : MonoBehaviour
{
    public float nextGenerationTime;
    public float generationInterval;
    private GameObject prefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generationInterval = 8;
        nextGenerationTime = Time.time;
        prefab = Resources.Load<GameObject>("ThunderBirdPrefab");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextGenerationTime)
        {
            var randomX = Random.Range(DataKeeper.minX + 1, DataKeeper.maxX - 1);
            var randomY = Random.Range(DataKeeper.minY + 1, DataKeeper.maxY - 1);
            var position = new Vector3(randomX, randomY, -1);
            
            Instantiate(prefab, position, Quaternion.identity);
            nextGenerationTime = Time.time + generationInterval;
        }
    }
}
