using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButton : MonoBehaviour {


    [SerializeField]
    private float speed;

    public GameObject kid;
	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseOver() {
        
        if(gameObject.CompareTag("Left Arrow")) {
            kid.transform.Translate(-speed * Time.deltaTime, 0, 0);
            print(kid);
        }

        if (gameObject.CompareTag("Right Arrow")) {
            kid.transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (gameObject.CompareTag("Up Arrow")) {
            kid.transform.Translate(0,speed * Time.deltaTime, 0);
        }

        if (gameObject.CompareTag("Down Arrow")) {
            kid.transform.Translate(0, -speed * Time.deltaTime, 0);
        }

    }


    // Update is called once per frame
    void Update () {
		
	}
}
