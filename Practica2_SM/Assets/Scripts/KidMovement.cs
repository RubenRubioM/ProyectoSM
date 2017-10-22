using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KidMovement : MonoBehaviour {

    [SerializeField]
    private float speed;
    private bool moving;
    private Vector2  positionToMove; //Variable que guarda la posicion donde has tocado

   	void Start () {
		
	}


    void Update () {

        if (Input.GetMouseButtonDown(0)) {
            positionToMove = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(positionToMove);
            transform.position = positionToMove;
            moving = true;
        }

        /*
        if (moving == true) {
            transform.Translate(new Vector2(speed, speed));
            if (Vector2.Distance(transform.position,positionToMove ) < 0.1f) {
                moving = false;
            }
        }
        */
    }


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Raincoat")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
