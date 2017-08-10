﻿using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    //The point to move to
    public Transform target;

    private Seeker seeker;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 2;

    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    public float repathRate = 0.25f;

    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    private Animator anim;
    private float lastRepath = -999f;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        anim = GetComponent<Animator>();
        //Start a new path to the targetPosition, return the result to the OnPathComplete function
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        StartCoroutine(RepeatTrySearchPath());
    }

    private IEnumerator RepeatTrySearchPath()
    {
        while (true) yield return new WaitForSeconds(TrySearchPath());
    }

    public float TrySearchPath()
    {
        if (Time.time - lastRepath >= repathRate && target != null)
        {
            SearchPath();
            return repathRate;
        }
        else
        {
            float v = repathRate - (Time.time - lastRepath);
            return v < 0 ? 0 : v;
        }
    }

    private void SearchPath()
    {
        if (target == null) throw new System.InvalidOperationException("Target is null");
        lastRepath = Time.time;
        Vector3 targetPosition = target.position;
        seeker.StartPath(transform.position, targetPosition, OnPathComplete);
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            Debug.Log("End Of Path Reached");
            return;
        }

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.deltaTime;
        this.gameObject.transform.Translate(dir);

        if (dir != Vector3.zero)
        {
            if (Mathf.Abs(dir.x) >= Mathf.Abs(dir.y))
                anim.SetBool("isHorizontal", true);
            else
                anim.SetBool("isHorizontal", false);
        }

        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
            currentWaypoint++;
    }
}