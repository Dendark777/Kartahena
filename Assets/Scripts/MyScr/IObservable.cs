using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IObservable
{
    void AddObserver(MonoBehaviour o);
    void RemoveObserver(MonoBehaviour o);
    void NotifyObservers();
}
