using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public  static  int IndexLastScene {get; set; }
    public  static  int IndexCurrnetScene { get; set; }

    public  static  Settings Setting { get; set; }

    static GameManager()
    {
        Setting = new Settings();
    }

}
