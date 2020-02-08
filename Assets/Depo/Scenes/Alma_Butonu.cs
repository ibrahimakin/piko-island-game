using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alma_Butonu : MonoBehaviour
{
    public Text Miktar, Secilen, Alinan;
    public Button AL;

    void Start()
    {
        AL.onClick.AddListener(Alma);
    }

    void Alma()
    {
        int x, max,alinan;
        max = Convert.ToInt32(Miktar.text);
        x = Convert.ToInt32(Secilen.text);
        max -= x;
        Miktar.text = max.ToString();
        alinan = Convert.ToInt32(Alinan.text);
        alinan += x;
        Alinan.text=alinan.ToString();
        Secilen.text = "0";
    }
}
