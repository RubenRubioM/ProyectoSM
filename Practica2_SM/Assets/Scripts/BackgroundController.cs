using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    public SpriteRenderer sr;
    public Sprite sprite1;
    public GameObject[] toDisable;
    public GameObject Madera;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CambioEscenario1() {

        sr.sprite = sprite1;
        Madera.SetActive(true);
        foreach(GameObject go in toDisable) {
            go.SetActive(false);
        }
    }
}
