using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBehaviour : MonoBehaviour {

    public static GameObject main;

	void Awake () {
        main = this.gameObject;
	}
}
