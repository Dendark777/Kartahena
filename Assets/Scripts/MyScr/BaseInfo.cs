using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BaseInfo : BaseLogo
{
    [SerializeField] protected EnumCardValue Value;
    public EnumCardValue GetValue => Value;
}