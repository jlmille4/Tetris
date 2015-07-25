using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameObjectExtensions
{
    public static List<I> FindObjectsOfInterface<I>() where I : class
    {
        MonoBehaviour[] behaviours = GameObject.FindObjectsOfType<MonoBehaviour>();
        List<I> interfaces = new List<I>();
        foreach(Behaviour behaviour in behaviours)
        {
            I component = behaviour.GetComponent<I>();
            if(component != null)
            {
                interfaces.Add(component);
            }
        }
        return interfaces;
    }
}
