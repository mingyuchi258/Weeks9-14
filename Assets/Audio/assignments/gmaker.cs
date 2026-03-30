using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gmaker : MonoBehaviour
{
    public GameObject Ghost;
    public movecontro player;
    public float contactDistance = 1f;

    List <GameObject> GL;
    public bool gameStart = true;
    float x = 1;
    float waitSpeed = 15;


    void Start()
    {
        GL = new List <GameObject> ();
        StartCoroutine(InstanGhostV());
    }

    void Update()
    {

        for (int i = GL.Count - 1; i >= 0; i--)
        {
            GameObject ghost = GL[i];

            float distance = Vector2.Distance(ghost.transform.position, player.Weapon.position);
            if (distance < contactDistance)
            {
                Destroy(ghost);
                GL.RemoveAt(i);
            }
            else if (ghost.transform.position.x > -1 && ghost.transform.position.x < 1 && ghost.transform.position.y > -1 && ghost.transform.position.y < 1)
            {
                Destroy(ghost);
                GL.RemoveAt(i);
            }
        }
    }

    IEnumerator InstanGhostV()
    {
        while (gameStart == true)
        {
            InstanGhost();
            yield return new WaitForSeconds(waitSpeed);
            x++;
            waitSpeed = waitSpeed + 3;
        }
    }

    
    void InstanGhost()
    {
        for (int i = 0; i < x; i++)
        {
            Vector3 randomP = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            GameObject newGhost = Instantiate(Ghost, transform.position + randomP, Quaternion.identity);
            GL.Add(newGhost);
        }
    }
}
