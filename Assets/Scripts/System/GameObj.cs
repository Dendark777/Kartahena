using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObj
{
    public Sprite logo;

    public GameObj(EnumGameObjValue gameObjValue, string logoPath)
    {
        logo = Resources.Load<Sprite>(logoPath);
    }

}
