﻿using UnityEngine;
using System.Collections;

public class OverlaySwirl : MonoBehaviour
{

    public GameObject player;
    public float maxDist = 4;
    public float minDist = 1.5f;
    public float maxScaleX = 16f;
    public float minScaleX = 0.88f;

    float minScaleZ = 0.58f;
    float distance, scaling, newScale;
    Vector3 scale;
    RaycastHit hit;
    bool isLookedAt;

    protected CardboardHead head;

    // Use this for initialization
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        head = Camera.main.GetComponent<StereoController>().Head;
    }

    // Update is called once per frame
    void Update()
    {
        isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);

        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < maxDist)
        {
            //%of scale increase/decrease
            scaling = 1 - ((distance - minDist)/(maxDist - minDist));

            //Absolute increase/decrease
            newScale = (maxScaleX - minScaleX)*scaling;

            transform.localScale = new Vector3(minScaleX + newScale, transform.localScale.y, minScaleZ + newScale);
        }
        else
        {
            transform.localScale = new Vector3(minScaleX, transform.localScale.y, minScaleZ);
        }

    }
}
