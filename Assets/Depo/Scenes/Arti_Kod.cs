using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arti_Kod : MonoBehaviour
{
    public Text Say, Miktar;
    public Button Arti;

    void Start()
    {
        Arti.onClick.AddListener(Arttir);
    }
    void Arttir()
    {
        int x, max;
        x = Convert.ToInt32(Say.text);
        max = Convert.ToInt32(Miktar.text);
        if (x >= max)
        {
            x = max;
            return;
        }
        x++;
        Say.text =x.ToString();
    }
}
