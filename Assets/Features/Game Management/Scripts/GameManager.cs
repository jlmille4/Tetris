using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using gov.nasa.ksc.it.itacl.common;

[RequireComponent (typeof(GameTime))]
[RequireComponent (typeof(StandardInput))]
public class GameManager : MonoBehaviour 
{
    private IPlayableTime time = null;
    private IInput input = null;
    public void Awake()
    {
        time = GetComponent<GameTime>();
        input = GetComponent<StandardInput>();
    }

	// Use this for initialization
	void Start () 
    {
        InitializeInput();
        InitializeTime();
	    
	}

    private void InitializeTime()
    {
        List<IRequirePlayableTime> scripts = GameObjectExtensions.FindObjectsOfInterface<IRequirePlayableTime>();
        foreach (IRequirePlayableTime script in scripts)
        {
            script.PlayableTime = time;
        }
    }

    private void InitializeInput()
    {
        List<IRequireInput> scripts = GameObjectExtensions.FindObjectsOfInterface<IRequireInput>();
        foreach(IRequireInput script in scripts)
        {
            script.Input = input;
        }
    }

}
