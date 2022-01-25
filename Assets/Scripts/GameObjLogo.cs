using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObj
{
    public Sprite Logo;

    public GameObj(EnumCardValue gameObjValue, string logoPath)
    {
        Logo = Resources.Load<Sprite>(logoPath);
    }

}
