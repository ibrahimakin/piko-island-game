using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomProblem : MonoBehaviour
{
    public Text mevcutElma, mevcutMuz, mevcutDomates, mevcutMisir, mevcutPatlican, mevcutBiber;
    int mElma, mMuz, mDomates, mMisir, mPatlican, mBiber;

    public Text Problem, GameOver;
    int iElma, iMuz, iDomates, iMisir, iPatlican, iBiber;

    public Text alinanElma, alinanMuz, alinanDomates, alinanMisir, alinanPatlican, alinanBiber;
    public Button SepetiGotur;
    public GameObject Bitir;

    void Start()
    {
        Bitir.SetActive(false);
        do
        {
            mElma = UnityEngine.Random.Range(0, 36);
            mMuz = UnityEngine.Random.Range(0, 26);
            mDomates = UnityEngine.Random.Range(0, 46);
            mMisir = UnityEngine.Random.Range(0, 66);
            mPatlican = UnityEngine.Random.Range(0, 56);
            mBiber = UnityEngine.Random.Range(0, 29);

            iElma = UnityEngine.Random.Range(0, 15);
            iMuz = UnityEngine.Random.Range(0, 10);
            iDomates = UnityEngine.Random.Range(0, 20);
            iMisir = UnityEngine.Random.Range(0,8);
            iPatlican = UnityEngine.Random.Range(0, 13);
            iBiber = UnityEngine.Random.Range(0,17);

        } while (iElma>mElma || iMuz>mMuz || iDomates>mDomates || iMisir>mMisir || iPatlican>mPatlican || iBiber>mBiber);

        mevcutElma.text = mElma.ToString();
        mevcutMuz.text = mMuz.ToString();
        mevcutDomates.text = mDomates.ToString();
        mevcutMisir.text = mMisir.ToString();
        mevcutPatlican.text = mPatlican.ToString();
        mevcutBiber.text = mBiber.ToString();
        Problem.text += "\n" + iElma.ToString() + " Elma, " + iMuz.ToString() + " Muz\n" + iDomates.ToString() + " Domates, " + iMisir.ToString() + " Mısır\n" + iPatlican.ToString() + " Patlıcan, " + iBiber.ToString() + " Biber\n";
        SepetiGotur.onClick.AddListener(SepetKontrol);
    }
    void SepetKontrol()
    {
        int aElma, aMuz, aDomates, aMisir, aPatlican, aBiber;
        aElma = Convert.ToInt32(alinanElma.text);
        aMuz = Convert.ToInt32(alinanMuz.text);
        aDomates = Convert.ToInt32(alinanDomates.text);
        aMisir = Convert.ToInt32(alinanMisir.text);
        aPatlican = Convert.ToInt32(alinanPatlican.text);
        aBiber = Convert.ToInt32(alinanBiber.text);

        if (aElma==iElma && aMuz==iMuz && aDomates==iDomates && aMisir==iMisir && aPatlican==iPatlican && aBiber==iBiber)
        {
            GameOver.text = "DOĞRU !";
            Bitir.SetActive(true);

        }
        else{
            GameOver.text = "Yanlış. Tekrar Dene.";
        }
    }
    void Update()
    {
        
    }
}
