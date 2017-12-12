using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    public SpriteRenderer sr;
    public Sprite[] sprites;
    public GameObject[] toDisable1, toDisable2, toDisable3;
    public GameObject Madera, Vidrio, Plastico;
    private AudioSource audiosource;
    public AudioClip[] clips;
	// Use this for initialization
	void Start () {
        audiosource = GetComponent<AudioSource>();

        audiosource.clip = clips[0];
        if (audiosource.isPlaying) {
            audiosource.Stop();
        }
        audiosource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CambioEscenario1() {

        audiosource.clip = clips[1];
        if (audiosource.isPlaying) {
            audiosource.Stop();
        }
        audiosource.Play();
        sr.sprite = sprites[0];
        Madera.SetActive(true);
        foreach(GameObject go in toDisable1) {
            go.SetActive(false);
        }
    }

    public void CambioEscenario2() {

        audiosource.clip = clips[2];
        if (audiosource.isPlaying) {
            audiosource.Stop();
        }
        audiosource.Play();
        sr.sprite = sprites[1];
        Vidrio.SetActive(true);
        foreach (GameObject go in toDisable2) {
            go.SetActive(false);
        }
    }

    public void CambioEscenario3(){

        audiosource.clip = clips[3];
        if (audiosource.isPlaying) {
            audiosource.Stop();
        }
        audiosource.Play();
        sr.sprite = sprites[2];
        Plastico.SetActive(true);
        foreach (GameObject go in toDisable3) {
            go.SetActive(false);
        }
    }
}
