using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Check : MonoBehaviour {

    public GameObject good_panel;
    private AudioSource audiosource;
    public AudioClip[] clips;
    [SerializeField]
    private SpriteRenderer comparador;
    [SerializeField]
    private Sprite[] sprites;
    static int contador = 0;

	void Start () {
		if(good_panel.activeInHierarchy) {
            good_panel.SetActive(false);
            
        }
        
        audiosource = GetComponent<AudioSource>();
        
        contador++;
        audiosource.clip = clips[0];
        audiosource.Play();
        StartCoroutine(esperaAcabarPrimerAudio());
	}

    private void Update() {
        
    }

    private void OnMouseDown() {

        if (comparador.sprite.name.Equals("chubasquero") && gameObject.tag.Equals("Plastic")) {
            //Acierto
            Debug.Log("ACIERTO");
            
            StartCoroutine(cambioObjeto(sprites[1]));
            contador++;
        } else if(comparador.sprite.name.Equals("mesa") && gameObject.tag.Equals("Wood")) {
            //Acierto
            StartCoroutine(cambioObjeto(sprites[2]));
            contador++;
        } else if (comparador.sprite.name.Equals("vaso") && gameObject.tag.Equals("Glass")) {
            //Acierto
            audiosource.clip = clips[6];
            audiosource.Play();
            StartCoroutine(FinalJuego());
        } else {
            audiosource.clip = clips[7];
            audiosource.Play();
        }



    }

    IEnumerator FinalJuego() {
        yield return new WaitForSeconds(5f);

        audiosource.clip = clips[8];
        audiosource.Play();
    }

    IEnumerator esperaAcabarPrimerAudio() {

        yield return new WaitForSeconds(3f);

        audiosource.clip = clips[1];
        audiosource.Play();
    }

    IEnumerator cambioObjeto(Sprite s) {


        if (s.name.Equals("mesa")) {
            audiosource.clip = clips[4];
            audiosource.Play();
        }

        if (s.name.Equals("vaso")) {
            audiosource.clip = clips[5];
            audiosource.Play();
        }

        good_panel.SetActive(true);
        yield return new WaitForSeconds(4f);

        good_panel.SetActive(false);
        //cambio de sprite

        if (s.name.Equals("mesa")) {
            comparador.sprite = s;
            comparador.transform.localScale *= 2.5f;
            audiosource.clip = clips[2];
            audiosource.Play();
        }

        if (s.name.Equals("vaso")) {
            comparador.sprite = s;
            comparador.transform.localScale *= 0.5f;
            audiosource.clip = clips[3];
            audiosource.Play();
        }
    }
}
