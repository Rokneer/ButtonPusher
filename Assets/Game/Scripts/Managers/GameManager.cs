using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private List<Player> _players;

    public void AddPlayerToList(Player player)
    {
        _players.Add(player);
    }
}
