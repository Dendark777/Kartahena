using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObj
{
    public Sprite Logo;

    public GameObj(EnumGameObjValue gameObjValue, string logoPath)
    {
        Logo = Resources.Load<Sprite>(logoPath);
    }

}
