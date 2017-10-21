using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour {

    public GameObject good_panel,bad_panel;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
        if (gameObject.CompareTag("Plastic")) {
            if (bad_panel.activeInHierarchy) {
                good_panel.SetActive(true);
            } else {
                bad_panel.SetActive(false);
                good_panel.SetActive(true);
            }
            
        } else {
            bad_panel.SetActive(true);
        }
    }
}
