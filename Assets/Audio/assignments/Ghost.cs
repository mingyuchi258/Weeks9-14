using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    void Update()
    {
        //Keep moving towards the center
        Vector3 SC = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        transform.position = Vector3.MoveTowards(transform.position, SC, 0.5f * Time.deltaTime);

    }
}