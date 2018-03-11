using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleObject : MonoBehaviour {

    public bool reached = false;
    public Text willPowerText;
    public int willPower = 100;

    void FixedUpdate ()
    {
        willPowerText.text = willPower.ToString();
    }

    public void takeDamage(int amount)
    {
        willPower -= amount;
        if(willPower <= 50)
        {
            willPowerText.color = Color.red;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            Debug.Log("Target reached!");
            reached = true;
        }
    }

}
