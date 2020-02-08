using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kopyala : MonoBehaviour
{

    public GameObject obje;
    public Button Bastan, Tamam, Temizle;
    public GameObject Domates, Misir, Patlican, Biber;
    public GameObject tDomates, tMisir, tPatlican, tBiber;
    public Text Problem, GameOver;
    public GameObject Bitir;
    Vector3 DstartPosition, MstartPosition, PstartPosition, BstartPosition;

    int grid_sayisi, iGrid;
    int iDomates, iPatlican, iMisir, iBiber;
    int gDomates, gPatlican, gMisir, gBiber;
    int tek_cift;
    void Start()
    {
        Bitir.SetActive(false);
        do
        {
            //tek_cift = Random.Range(1, 3);
            //if (tek_cift % 2 == 0)
            //{
            iDomates = GetRandom(0, 25, 5);
            iGrid += iDomates / 5;
            gDomates = iDomates / 5;
            //}
            //else
            //{
            //    iDomates = GetRandom(0, 35, 7);
            //    iGrid += iDomates / 7;
            //    gDomates = iDomates / 7;
            //}

            //tek_cift = Random.Range(1, 3);
            //if (tek_cift % 2 == 0)
            //{
            iPatlican = GetRandom(0, 15, 3);
            iGrid += iPatlican / 3;
            gPatlican = iPatlican / 3;
            //}
            //else
            //{
            //    iPatlican = GetRandom(0, 20, 4);
            //    iGrid += iPatlican / 4;
            //    gPatlican = iPatlican / 4;
            //}

            //tek_cift = Random.Range(1, 3);
            //if (tek_cift % 2 == 0)
            //{
            iMisir = GetRandom(0, 30, 6);
            iGrid += iMisir / 6;
            gMisir = iMisir / 6;
            //}
            //else
            //{
            //    iMisir = GetRandom(0, 40, 8);
            //    iGrid += iMisir / 8;
            //    gMisir = iMisir / 8;
            //}

            //tek_cift = Random.Range(1, 3);
            //if (tek_cift % 2 == 0)
            //{
            iBiber = GetRandom(0, 50, 10);
            iGrid += iBiber / 10;
            gBiber = iBiber / 10;
            //}
            //else
            //{
            //    iBiber = GetRandom(0, 75, 15);
            //    iGrid += iBiber / 15;
            //    gBiber = iBiber / 15;
            //}
        } while (iGrid > 12);

        grid_sayisi = iGrid;

        for (int i = 0; i < grid_sayisi - 1; i++)
        {
            Instantiate(obje.transform, new Vector3(0, 0, 0), Quaternion.identity, obje.transform.parent);
        }

        for (int i = 0; i < gDomates; i++)
        {
            Instantiate(Domates.transform, Domates.transform.parent);
        }
        for (int i = 0; i < gMisir; i++)
        {
            Instantiate(Misir.transform, Misir.transform.parent);
        }
        for (int i = 0; i < gPatlican; i++)
        {
            Instantiate(Patlican.transform, Patlican.transform.parent);
        }
        for (int i = 0; i < gBiber; i++)
        {
            Instantiate(Biber.transform, Biber.transform.parent);
        }
        Problem.text += " \n" + iDomates.ToString() + " Domates \n" + iMisir.ToString() + " Mısır \n" + iPatlican.ToString() + " Patlıcan \n" + iBiber.ToString() + " Biber";
        Temizle.onClick.AddListener(Clear);
        Bastan.onClick.AddListener(restart);
        Tamam.onClick.AddListener(Kontrol);
    }

    void Update()
    {

    }
    public void Clear()
    {
        GameObject[] ekiliDomatesler = GameObject.FindGameObjectsWithTag("Domates");
        for (int i = 0; i < ekiliDomatesler.Length; i++)
        {
            if (ekiliDomatesler[i].transform.parent.tag == "Grid")
            {
                ekiliDomatesler[i].transform.SetParent(tDomates.transform);
                ekiliDomatesler[i].transform.position = tDomates.transform.position;
            }
        }
        GameObject[] ekiliMisir = GameObject.FindGameObjectsWithTag("Misir");
        for (int i = 0; i < ekiliMisir.Length; i++)
        {
            if (ekiliMisir[i].transform.parent.tag == "Grid")
            {
                ekiliMisir[i].transform.SetParent(tMisir.transform);
                ekiliMisir[i].transform.position = tMisir.transform.position;
            }
        }

        GameObject[] ekiliPatlican = GameObject.FindGameObjectsWithTag("Patlican");
        for (int i = 0; i < ekiliPatlican.Length; i++)
        {
            if (ekiliPatlican[i].transform.parent.tag == "Grid")
            {
                ekiliPatlican[i].transform.SetParent(tPatlican.transform);
                ekiliPatlican[i].transform.position = tPatlican.transform.position;
            }
        }

        GameObject[] ekiliBiber = GameObject.FindGameObjectsWithTag("Biber");
        for (int i = 0; i < ekiliBiber.Length; i++)
        {
            if (ekiliBiber[i].transform.parent.tag == "Grid")
            {
                ekiliBiber[i].transform.SetParent(tBiber.transform);
                ekiliBiber[i].transform.position = tBiber.transform.position;
            }
        }
    }

    public void Kontrol()
    {
        int domates = 0, misir = 0, patlican = 0, biber = 0;

        GameObject[] ekiliDomatesler = GameObject.FindGameObjectsWithTag("Domates");
        for (int i = 0; i < ekiliDomatesler.Length; i++)
        {
            if (ekiliDomatesler[i].transform.parent.tag == "Grid")
            {
                domates = domates + 1;
            }
        }

        GameObject[] ekiliMisir = GameObject.FindGameObjectsWithTag("Misir");
        for (int i = 0; i < ekiliMisir.Length; i++)
        {
            if (ekiliMisir[i].transform.parent.tag == "Grid")
            {
                misir = misir + 1;
            }
        }

        GameObject[] ekiliPatlican = GameObject.FindGameObjectsWithTag("Patlican");
        for (int i = 0; i < ekiliPatlican.Length; i++)
        {
            if (ekiliPatlican[i].transform.parent.tag == "Grid")
            {
                patlican = patlican + 1;
            }
        }

        GameObject[] ekiliBiber = GameObject.FindGameObjectsWithTag("Biber");
        for (int i = 0; i < ekiliBiber.Length; i++)
        {
            if (ekiliBiber[i].transform.parent.tag == "Grid")
            {
                biber = biber + 1;
            }
        }

        if (domates == gDomates && biber == gBiber && misir == gMisir && patlican == gPatlican)
        {
            GameOver.text = "DOĞRU !";
            Bitir.SetActive(true);
        }
        else
        {
            GameOver.text = "Yanlış.\nTekrar Dene.";
        }
    }
    int GetRandom(int min, int max, int increment)
    {
        int random = Random.Range(min, max);
        int numSteps = (int)Mathf.Floor(random / increment);
        int result = numSteps * increment;

        return result;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    void restart()
    {
        Clear();
        iDomates = 0; iBiber = 0; iMisir = 0; iPatlican = 0;
        gDomates = 0; gBiber = 0; gMisir = 0; gPatlican = 0;
        iGrid = 0; grid_sayisi = 0;

        GameObject[] grids = GameObject.FindGameObjectsWithTag("Grid");

        if (grids.Length > 1)
        {
            for (int i = grids.Length - 1; i > 0; i--)
            {
                Destroy(grids[i].gameObject);
            }
        }
        GameObject[] dPatlican = GameObject.FindGameObjectsWithTag("Patlican");
        if (dPatlican.Length > 1)
        {
            for (int i = dPatlican.Length - 1; i > 0; i--)
            {
                Destroy(dPatlican[i]);
            }
        }
        GameObject[] dDomates = GameObject.FindGameObjectsWithTag("Domates");
        if (dDomates.Length > 1)
        {
            for (int i = dDomates.Length - 1; i > 0; i--)
            {
                Destroy(dDomates[i]);
            }
        }
        GameObject[] dBiber = GameObject.FindGameObjectsWithTag("Biber");
        if (dBiber.Length > 1)
        {
            for (int i = dBiber.Length - 1; i > 0; i--)
            {
                Destroy(dBiber[i]);
            }
        }
        GameObject[] dMisir = GameObject.FindGameObjectsWithTag("Misir");
        if (dMisir.Length > 1)
        {
            for (int i = dMisir.Length - 1; i > 0; i--)
            {
                Destroy(dMisir[i]);
            }
        }

        do
        {
            //tek_cift = Random.Range(1, 3);
            //if (tek_cift % 2 == 0)
            //{
            iDomates = GetRandom(0, 25, 5);
            iGrid += iDomates / 5;
            gDomates = iDomates / 5;
            //}
            //else
            //{
            //    iDomates = GetRandom(0, 35, 7);
            //    iGrid += iDomates / 7;
            //    gDomates = iDomates / 7;
            //}

            //tek_cift = Random.Range(1, 3);
            //if (tek_cift % 2 == 0)
            //{
            iPatlican = GetRandom(0, 15, 3);
            iGrid += iPatlican / 3;
            gPatlican = iPatlican / 3;
            //}
            //else
            //{
            //    iPatlican = GetRandom(0, 20, 4);
            //    iGrid += iPatlican / 4;
            //    gPatlican = iPatlican / 4;
            //}

            //tek_cift = Random.Range(1, 3);
            //if (tek_cift % 2 == 0)
            //{
            iMisir = GetRandom(0, 30, 6);
            iGrid += iMisir / 6;
            gMisir = iMisir / 6;
            //}
            //else
            //{
            //    iMisir = GetRandom(0, 40, 8);
            //    iGrid += iMisir / 8;
            //    gMisir = iMisir / 8;
            //}

            //tek_cift = Random.Range(1, 3);
            //if (tek_cift % 2 == 0)
            //{
            iBiber = GetRandom(0, 50, 10);
            iGrid += iBiber / 10;
            gBiber = iBiber / 10;
            //}
            //else
            //{
            //    iBiber = GetRandom(0, 75, 15);
            //    iGrid += iBiber / 15;
            //    gBiber = iBiber / 15;
            //}
        } while (iGrid > 12);

        grid_sayisi = iGrid;

        for (int i = 0; i < grid_sayisi - 1; i++)
        {
            Instantiate(grids[0].transform, new Vector3(0, 0, 0), Quaternion.identity, grids[0].transform.parent);
        }

        for (int i = 0; i < gDomates; i++)
        {
            Instantiate(Domates.transform, Domates.transform.parent);
        }
        for (int i = 0; i < gMisir; i++)
        {
            Instantiate(Misir.transform, Misir.transform.parent);
        }
        for (int i = 0; i < gPatlican; i++)
        {
            Instantiate(Patlican.transform, Patlican.transform.parent);
        }
        for (int i = 0; i < gBiber; i++)
        {
            Instantiate(Biber.transform, Biber.transform.parent);
        }
        Problem.text = " İhtiyacımız \n" + iDomates.ToString() + " Domates \n" + iMisir.ToString() + " Mısır \n" + iPatlican.ToString() + " Patlıcan \n" + iBiber.ToString() + " Biber";
        GameOver.text = "";
    }
}
