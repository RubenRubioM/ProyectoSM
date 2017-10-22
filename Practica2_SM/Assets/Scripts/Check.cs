using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Check : MonoBehaviour {

    public GameObject good_panel,bad_panel;

	void Start () {
		if(good_panel.activeInHierarchy || bad_panel.activeInHierarchy) {
            good_panel.SetActive(false);
            bad_panel.SetActive(false);
        }
	}

    private void OnMouseDown() {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name.Equals("Raincoat")) {
            if (gameObject.CompareTag("Plastic")) {
                bad_panel.SetActive(false);
                good_panel.SetActive(true);
            } else {
                good_panel.SetActive(false);
                bad_panel.SetActive(true);
            }
        }
        

    }
}
