using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KidMovement : MonoBehaviour {


    [SerializeField]
    private float speed;
    private Vector2 positionToMove; //Variable que guarda la posicion donde has tocado
    private ObjectsPicked objectsScript;

    private void Start() {
        positionToMove = transform.position;
        objectsScript = GameObject.FindObjectOfType<ObjectsPicked>();
    }

    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            positionToMove = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

        transform.position = Vector2.MoveTowards(transform.position, positionToMove, speed * Time.deltaTime);
      
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Raincoat")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.CompareTag("Glass")) {
            Debug.Log("ASD");
            objectsScript.activarMaterial(collision.gameObject);
            Destroy(collision.gameObject);
        }
       
    }

 
}




   

