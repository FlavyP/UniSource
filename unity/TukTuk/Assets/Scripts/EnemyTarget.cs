using UnityEngine;
using System.Collections;

public class EnemyTarget : MonoBehaviour {
    // when collided with another gameObject
    void OnCollisionEnter(Collision newCollision)
    {
        // exit if there is a game manager and the game is over
        if (GameManager.gm)
        {
            if (GameManager.gm.gameIsOver)
                return;
        }

        if (newCollision.gameObject.tag == "Projectile")
        {
            // destroy self
            Destroy(gameObject);
        }
    }
}