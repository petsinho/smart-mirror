using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour {

	void OnEnable(){
		EventManager.OnClicked += StartSnow;
	}

	void OnDisable(){
		EventManager.OnClicked -= StartSnow;
	}

	void StartSnow(){
		 print("sssno");
		 GameObject snow = GameObject.Find("/Effects/Snow");
		 snow.SetActive(true);
	}
}
