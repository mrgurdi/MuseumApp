﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class Initialize : MonoBehaviour {

    string logPath = "/log1.csv";
    string dataPath;
    int logNr = 1;

	// Use this for initialization
	void Start()
    {
        dataPath = Museum.getDataPath();
	}

    void Update()
    {
        // Loop through existing files until one cannot be found.
        while (File.Exists(dataPath + logPath))
        {
            logNr++;
            logPath = "/log" + (logNr) + ".csv";
            Debug.Log(dataPath + logPath);
        }

        Museum.Load("/setup.txt", logPath);
        SceneManager.LoadScene("Scenes/Hallway");
    }
}
