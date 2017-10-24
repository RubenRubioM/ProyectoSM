using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KidMovement : MonoBehaviour {

    [SerializeField]
    private float speed;
    private bool moving;
    private Vector2  positionToMove; //Variable que guarda la posicion donde has tocado
    private Vector2 distance;

   	void Start () {
		
	}


    void Update () {

        if (Input.GetMouseButtonDown(0)) {
            positionToMove = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(positionToMove);

            distance = new Vector2(positionToMove.x - transform.position.x, positionToMove.y - transform.position.y);
            moving = true;

        }

        if (distance.x < 0) {
            if (distance.y < 0) {
                transform.Translate(-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
            }
            if (distance.y > 0) {
                transform.Translate(-speed * Time.deltaTime, speed * Time.deltaTime, 0);
            }
            if (distance.y == 0) {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }

        if (distance.x > 0) {
            if (distance.y < 0) {
                transform.Translate(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
            }
            if (distance.y > 0) {
                transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0);
            }
            if (distance.y == 0) {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
        distance = new Vector2(positionToMove.x - transform.position.x, positionToMove.y - transform.position.y);


    }


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Raincoat")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
