using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KidMovement : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Vector2  positionToMove; //Variable que guarda la posicion donde has tocado

   	void Start () {
		
	}


    void Update () {
        
        
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            foreach (Touch touch in Input.touches) {

                positionToMove = Camera.main.ScreenToWorldPoint(touch.position);
                Debug.Log("Posicion donde has tocado: " + positionToMove);
                Debug.Log("Posicion del personaje:" + transform.position);

            }
            Vector2 distance = positionToMove - (Vector2)transform.position;
            transform.position = positionToMove;
        }
        
        
        

    }

    /*
    private void MoveTo(Vector2 distance) {
       

        Debug.Log(distance);

        while ((Vector2) transform.position!=positionToMove) {

            distance = positionToMove - (Vector2)transform.position;
            transform.Translate(speed,speed,0);

        }
        
    }
    */

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Raincoat")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
