using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTime : MonoBehaviour {

    public float speed=1;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
	}   
	
	// Update is called once per frame
	void Update () {
        if( animator ) animator.speed = speed;
	}
}
