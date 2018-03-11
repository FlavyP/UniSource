using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{

    public float speed = 10.0f;
    public enum whichWayToRotate { AroundX, AroundY, AroundZ }
    public whichWayToRotate way = whichWayToRotate.AroundX;
    public AudioClip sound;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            switch (way)
            {
                case whichWayToRotate.AroundX:
                    transform.Rotate(Vector3.right * Time.deltaTime * speed);
                    break;
                case whichWayToRotate.AroundY:
                    transform.Rotate(Vector3.up * Time.deltaTime * speed);
                    break;
                case whichWayToRotate.AroundZ:
                    transform.Rotate(Vector3.forward * Time.deltaTime * speed);
                    break;
            }
        }

    }
}