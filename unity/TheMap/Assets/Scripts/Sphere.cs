using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(2.5f, 1.5f, -20);
        transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update () {
	if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * 4);
        }
	}
}
