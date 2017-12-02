using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Check : MonoBehaviour {

    public GameObject good_panel;
    private AudioSource audiosource;
    public AudioClip[] audio;
    [SerializeField]
    private SpriteRenderer comparador;
    [SerializeField]
    private Sprite[] sprites;
    int contador = 0;

	void Start () {
		if(good_panel.activeInHierarchy) {
            good_panel.SetActive(false);
            
        }
        Debug.Log(comparador.sprite.name);
        audiosource = GetComponent<AudioSource>();
        comparador.sprite = sprites[contador];
        contador++;
       
	}

    private void OnMouseDown() {

        if (comparador.sprite.name.Equals(gameObject.tag)) {
            //Acierto
            
            StartCoroutine(cambioObjeto(sprites[contador]));
            contador++;
        } else {
            //Fallo
            audiosource.clip = audio[1];
            audiosource.Play();
        }       

    }

    IEnumerator cambioObjeto(Sprite s) {

        audiosource.clip = audio[0];
        audiosource.Play();

        yield return new WaitForSeconds(3f);

        //cambio de sprite
    }
}
