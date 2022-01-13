using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player
{   
    public Player(EnumPlayerColor playerColor,List<Card> playerHand, List<Chip> playerChip)
    {

    }
}

public static class PlayersManager
{
    public static List<Player> allPlayers = new List<Player>();
}


public class PlayersManagerScr : MonoBehaviour
{
    
}

public enum EnumPlayerColor
{
    красный,
    оранжевый,
    желтый,
    зеленый,
    синий
}