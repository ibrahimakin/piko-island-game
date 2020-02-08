using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepoKod : MonoBehaviour
{
    public Text elmaSay, mevcutElma;

    public Text muzSay, mevcutMuz;

    public Text domatesSay, mevcutDomates;

    public Text misirSay, mevcutMisir;

    // Start is called before the first frame update
    void Start()
    {
        elmaSay.text ="0";
        muzSay.text = "0";
        domatesSay.text = "0";
        misirSay.text = "0";

    }


    // Update is called once per frame
    void Update()
    {

    }
}
