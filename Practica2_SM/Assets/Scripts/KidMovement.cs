using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KidMovement : MonoBehaviour {


    [SerializeField]
    private float speed;
    private Vector2 positionToMove; //Variable que guarda la posicion donde has tocado
    private ObjectsPicked objectsScript;
    private BackgroundController BackgroundControllerScript;
    private bool isMoving;
    private Animator animator;
    private bool animationPlaying;
    private Rigidbody2D rb;

    private void Start() {
        positionToMove = transform.position;
        objectsScript = GameObject.FindObjectOfType<ObjectsPicked>();
        BackgroundControllerScript = GameObject.FindObjectOfType<Canvas>().GetComponent<BackgroundController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        positionToMove = (Vector2)transform.position;
    }

    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            positionToMove = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
            animationPlaying = false;
        }
        
        if (positionToMove.y > transform.position.y && isMoving) {
            animator.SetTrigger("walk up");
            animationPlaying = true;
        } else if(positionToMove.y < transform.position.y && isMoving) {
            animator.SetTrigger("walk down");
            animationPlaying = true;
        }


        if(Vector2.Distance((Vector2) transform.position, positionToMove) <= 0.02f) { 
            isMoving = false;
            animationPlaying = false;
        }
        

        if (isMoving) {
            transform.position = Vector2.MoveTowards(transform.position, positionToMove, speed * Time.deltaTime);
        } else {
            animator.SetTrigger("idle");
            animationPlaying = false;
        }
         
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name.Equals("Top Collider")) {
            isMoving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Glass") || collision.gameObject.CompareTag("Plastic") || collision.gameObject.CompareTag("Wood")) {
            
            objectsScript.activarMaterial(collision.gameObject);

            if (collision.gameObject.CompareTag("Wood")) {
                StartCoroutine(esperaParaCambiarAtienda());
            }

            if (collision.gameObject.CompareTag("Glass")) {
                StartCoroutine(esperaParaCambiarAHabitacion());
            }

            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Puerta"))
        {
            isMoving = false;
            Debug.Log("ASD");
            BackgroundControllerScript.CambioEscenario1();
        }
       
    }

    IEnumerator esperaParaCambiarAtienda() {

        yield return new WaitForSeconds(10f);

        BackgroundControllerScript.CambioEscenario2();

    }


    IEnumerator esperaParaCambiarAHabitacion() {

        yield return new WaitForSeconds(10f);

        BackgroundControllerScript.CambioEscenario3();

    }

}




   

