using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class soundsetter2 : MonoBehaviour {
    private Slider s1;
    // Use this for initialization
    void Start()
    {
        s1 = GetComponent<Slider>();
        PlayerPrefs.SetFloat("fx", s1.value);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("fx", s1.value);
    }
}
