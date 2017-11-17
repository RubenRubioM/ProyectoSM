using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectsPicked : MonoBehaviour {

    public GameObject[] materiales;
    int contador = 0;
    private static bool[] matConseguido = new bool[3];
    private AudioSource audiosource;

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
                audiosource.Play();
                contador++;
            }
        }

        if (contador == materiales.Length) {
            StartCoroutine(todosLosObjetos());

        }
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
