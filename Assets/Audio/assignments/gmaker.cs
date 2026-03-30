using System.Collections;
using UnityEngine;


public class gmaker : MonoBehaviour
{
    public GameObject Ghost;
    private bool gameStart = true;
    private float x = 1; 
    private float waitSpeed = 15;

    void Start()
    {
        gameStart = true;
        StartCoroutine(SpawnLoop());
    }

    void Update()
    {

            
    }

    void InstanGhost()
    {
        for (int i = 0; i < x; i++)
        {
            Vector3 randomP = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            Vector3 pos = transform.position + randomP;
            GameObject newG = Instantiate(Ghost, pos, Quaternion.identity);
        }
    }
    IEnumerator SpawnLoop()
    {
        while (gameStart)
        {
            InstanGhost();
            yield return new WaitForSeconds(waitSpeed);
            x++;
            waitSpeed = waitSpeed + 3;
        }
    }
}
