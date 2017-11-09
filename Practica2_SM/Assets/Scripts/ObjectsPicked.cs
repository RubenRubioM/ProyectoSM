using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPicked : MonoBehaviour {

    public GameObject[] materiales;

    void Start () {
		for(int i = 0; i < materiales.Length; i++) {
            materiales[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void activarMaterial(GameObject material) {
        Debug.Log("activa material");
        for(int i=0; i<materiales.Length; i++) {
            if (materiales[i].CompareTag(material.tag)) {
                materiales[i].SetActive(true);
            }
        }
    }
}
