using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eksi_Kod : MonoBehaviour
{
    public Text Say, Miktar;
    public Button Eksi;

    void Start()
    {
        Eksi.onClick.AddListener(Eksilt);
    }
    void Eksilt()
    {
        int x, max;
        x = Convert.ToInt32(Say.text);
        max = Convert.ToInt32(Miktar.text);
        if (x <= 0)
        {
            x = 0;
            return;
        }
        x--;
        Say.text = x.ToString();
    }
}