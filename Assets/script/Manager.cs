using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Manager : MonoBehaviour
{
    public List<Sprite> playerSprites;
    public List<PlayerInput> players;
    public void OnPlayerJoined(PlayerInput player)
    {
        players.Add(player);

        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = playerSprites[player.playerIndex];

        LMContro controllor = player.GetComponent<LMContro>();
        controllor.manager = this;
    }

    public void plyaerAttacking(PlayerInput attackingplayer)
    {
        for (int i = 0; i < players.Count; i++)
        {
           if(Vector2.Distance(attackingplayer.transform.position, players[i].transform.position) < 0.5f)
            {
                Debug.Log("player"+ attackingplayer.playerIndex + "attacked player" + players[i].playerIndex);
            }
         }
    }
}
