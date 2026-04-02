using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gmaker : MonoBehaviour
{
    //the prefab to be generated
    public GameObject PF;
    public movecontro player;
    //triggered when the prefab comes into contact with the stronghold
    public UnityEvent GhostAttack;
    //Triggered when the prefab disappears after being attacked by a player
    public UnityEvent HealthEffect;

    //list that stores prefabs
    List<GameObject> GL;
    public bool gameStart = true;
    //Number of prefabs generated each time
    float x = 1;
    //Waiting time between each generation
    float waitSpeed = 15;


    void Start()
    {
        GL = new List<GameObject>();

        StartCoroutine(InstanGhostV());
        StartCoroutine(InstanHealthV());
    }

    void Update()
    {

        for (int i = GL.Count - 1; i >= 0; i--)
        {
            GameObject PF = GL[i];

            // Detect the distance between the prefab and the weapon
            float distance = Vector2.Distance(PF.transform.position, player.Weapon.position);
            //If they come into contact, an event is triggered and destroy prefab
            if (distance < 1)
            {
                HealthEffect.Invoke();
                Destroy(PF);
                GL.RemoveAt(i);
            }

            //Detect whether the prefab has contacted the stronghold
            else if (PF.transform.position.x > -1 && PF.transform.position.x < 1 && PF.transform.position.y > -1 && PF.transform.position.y < 1)
            {
                //If get close to the stronghold, trigger the event, and destroy the prefab
                GhostAttack.Invoke();
                Destroy(PF);
                GL.RemoveAt(i);
            }
        }
    }

    IEnumerator InstanGhostV()
    {
        //Ghost generation rule
        while (gameStart == true)
        {
            //After generating the prefab, wait 15 seconds before generating it again. Each time, generate one more prefab than the last time, and wait 3 seconds longer than the last time
            InstanGhost();
            yield return new WaitForSeconds(waitSpeed);
            x++;
            waitSpeed = waitSpeed + 3;
        }
    }

    void InstanGhost()
    {
        //Randomly generate a specified number of prefabs within the specified range and add them to the list
        for (int i = 0; i < x; i++)
        {
            Vector3 randomP = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            GameObject newGhost = Instantiate(PF, transform.position + randomP, Quaternion.identity);
            GL.Add(newGhost);
        }
    }

    IEnumerator InstanHealthV()
    {
        //Medicine generation rule
        while (gameStart == false)
        {
            //Randomly generate a specified number of prefabs within the specified range and add them to the list
            for (int i = 0; i < x; i++)
            {
                Vector3 randomP = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);
                GameObject newGhost = Instantiate(PF, transform.position + randomP, Quaternion.identity);
                GL.Add(newGhost);
            }
            //Generates every 40 seconds
            yield return new WaitForSeconds(40);
        }
    }

}
