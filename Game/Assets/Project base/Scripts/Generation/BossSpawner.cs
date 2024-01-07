using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    
    [SerializeField] public GameObject BossEnemy;  //selects what object to be spawned 
    [SerializeField] public GameObject bossDetector; 

    void Start() 
    {
        float randomX = Random.Range(2, 5); //gets a random number between 3 and 5
        float randomZ = Random.Range(2, 5); //gets a random number between 3 and 5

        // Multiply both numbers by 18
        randomX *= 18;
        randomZ *= 18;

        
        Instantiate(BossEnemy, new Vector3(randomX,0,-randomZ),Quaternion.identity); //spawn BossEnemy at that location
        Object.Destroy(this.gameObject); //destroy current object 
        bossDetector.transform.position = new Vector3(randomX, 0, -randomZ); //move boss detector to the room as well
        Object.Destroy(BossEnemy); //destroy the boss prefab
    }

}