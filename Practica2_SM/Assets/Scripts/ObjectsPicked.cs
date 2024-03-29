﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectsPicked : MonoBehaviour {

    public GameObject[] materiales;
    int contador = 0;
    private static bool[] matConseguido = new bool[3];
    private AudioSource audiosource;
    public AudioClip[] sonidos;

    private void Start() {
        
        for(int i=0; i<materiales.Length; i++) {
            if (matConseguido[i] == true) {
                materiales[i].SetActive(true);
            } else {
                materiales[i].SetActive(false);
            }
        }

        audiosource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void activarMaterial(GameObject material) {
        
        for(int i=0; i<materiales.Length; i++) {
            if (materiales[i].CompareTag(material.tag)) {
                materiales[i].SetActive(true);
                matConseguido[i] = true;
                if (materiales[i].CompareTag("Wood")) {
                    audiosource.clip = sonidos[1];
                    if (audiosource.isPlaying) {
                        audiosource.Stop();
                    }
                    audiosource.Play();
                    audiosource.volume = 0.3f;
                    StartCoroutine(esperarSonido(3));
                }
                if (materiales[i].CompareTag("Glass")) {
                    audiosource.clip = sonidos[0];
                    if (audiosource.isPlaying) {
                        audiosource.Stop();
                    }
                    audiosource.Play();
                    audiosource.volume = 0.3f;
                    StartCoroutine(esperarSonido(4));
                }
                if (materiales[i].CompareTag("Plastic")) {
                    audiosource.clip = sonidos[2];
                    if (audiosource.isPlaying) {
                        audiosource.Stop();
                    }
                    audiosource.volume = 0.3f;
                    audiosource.Play();
                    StartCoroutine(esperarSonido(5));
                }

                contador++;
            }
        }

        if (contador == materiales.Length) {
            StartCoroutine(todosLosObjetos());

        }
    }

    IEnumerator esperarSonido(int i) {

        yield return new WaitForSeconds(2f);

        audiosource.clip = sonidos[i];
        audiosource.volume = 1f;
        audiosource.Play();
    }

    IEnumerator todosLosObjetos() {

        //Texto de haber conseguido todo

        //Voz de haber conseguido todo

        yield return new WaitForSeconds(5f);

        //Pasar de pantalla
        pasaPantallaFinal();

    }

    public void pasaPantallaFinal() {

        SceneManager.LoadScene(1);

    }

   
}
