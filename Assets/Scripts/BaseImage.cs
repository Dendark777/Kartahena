using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseImage
{
    public Sprite Logo;

    public BaseImage(string logoPath)
    {
        Logo = Resources.Load<Sprite>(logoPath);
    }

}
