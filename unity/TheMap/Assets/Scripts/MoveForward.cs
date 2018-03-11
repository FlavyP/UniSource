using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveForward : MonoBehaviour
{
    private float speed = 3;
    private bool showText = false;
    private int rotation = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SphereCollider>() == null)
            rotation *= -1;
        else {
            Destroy(collision.gameObject);
            showText = true;
            speed = 0;
        }
    }

    void OnGUI()
    {
        if (showText)
            GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75, 300, 250), ShowGUI, "YOU ARE DEAD");
            }

    void ShowGUI(int windowID)
    {
        GUI.Label(new Rect(65, 40, 200, 30), "Click OK to resurrect");

        if (GUI.Button(new Rect(50, 150, 75, 30), "OK"))
        {
            showText = false;
            SceneManager.LoadScene(0);
        }
    }
}
