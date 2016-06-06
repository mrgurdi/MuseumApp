﻿using UnityEngine;
using System.Collections;

public class SceneSwapChecker : MonoBehaviour
{
    public Transform PlayerTransform;
    public float SpawnRadius;
    public GameObject CurrentScene;
    public GameObject NextScene;
    public SceneOrchestrator Orchestrator;

    private bool IsSwappingToNextScene = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float paintingDistance = Vector3.Distance(PlayerTransform.position, transform.position);

	    if (paintingDistance < SpawnRadius)
	    {
	        if (!IsSwappingToNextScene)
	        {
	            // swap to painting scene
	            IsSwappingToNextScene = true;
                SceneOrchestrator.currentScene = NextScene.name;
	            Orchestrator.SwapScene(CurrentScene, NextScene);
	        }
	    }
	    else
	    {
	        if (IsSwappingToNextScene)
	        {
                //swap to Museum
                IsSwappingToNextScene = false;
                SceneOrchestrator.currentScene = CurrentScene.name;
                Orchestrator.SwapScene(NextScene, CurrentScene);
	        }
	    }
	}
}
