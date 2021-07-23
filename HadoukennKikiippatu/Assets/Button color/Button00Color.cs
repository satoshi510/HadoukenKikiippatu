using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button00color : MonoBehaviour
{
    GameObject Button00;

    // Start is called before the first frame update
    void Start()
    {
        Button00 = GameObject.Find("Button00");
        Button00.GetComponent<Text>().color = Color.white;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
