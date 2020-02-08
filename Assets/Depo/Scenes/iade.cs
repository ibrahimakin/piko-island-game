using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iade : MonoBehaviour
{
    public Text alinan, mevcut;
    public Button Eksi;

    int sayi,m;
    void Start()
    {
        Eksi.onClick.AddListener(geri);
    }

    void Update()
    {
        
    }
    void geri()
    {
        sayi = Convert.ToInt32(alinan.text);
        if (sayi<=0)
        {
            sayi = 0;
            return;
        }
        sayi--;
        alinan.text = sayi.ToString();
        m = Convert.ToInt32(mevcut.text);
        m++;
        mevcut.text = m.ToString();
    }
}