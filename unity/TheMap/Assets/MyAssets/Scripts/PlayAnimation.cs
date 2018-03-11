using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {

    Animator anim;
    private int state = 0;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            state++;
            if (state == 3) state = 1;

            anim.SetInteger("DoorsState", state);
        }
    }
}
