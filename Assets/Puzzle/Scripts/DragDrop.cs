using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragDrop : MonoBehaviour
{
    public List<GameObject> original; // Yapboz Parçalarını Tutmak için bir liste oluşturuldu.
    public List<GameObject> originalsPlace; // Parçaların yapboz içerisindeki konumlarını belirtmek için liste oluşturuldu.
    public List<Vector2> initialPosition; // Parçaların herhangi bir konumda bırakıldığında gidecekleri yeri ( başlangıç pozisyonu) belirtmek için liste oluşturuldu.
    public GameObject WinPanel; // Kazandınız Paneli için bir gameObject tanımlandı.
    bool isWin = false; // Kazanılıp kazanılmadığını öğrenmek için bool bir değişken atandı.
    int k = 0; // Parçaların sadece en baştan başlanıp yapboz içerisine konulması için bir değişken atandı.
    public GameObject Bitir;
    public GameObject Engel1, Engel2;
    public int selectedObjectIndex;

    void Awake() // Yapboz parçalarının ilk pozisyonlarını  Initialposition listesine alındı.
    {
        for (int i = 0; i < original.Count; i++)
        {
            initialPosition.Add(original[i].transform.position);
        }

    }
    void Start()
    {
        WinPanel.SetActive(false);
        Bitir.SetActive(false);
        Engel1.SetActive(true);
        Engel2.SetActive(true);
    }
    
    public void Selected(int index) // Tıklanan parçanın index numarası alındı.
    {
        selectedObjectIndex = index;

    }

    void IsWinner() // Yerleştirilen parça sayısı orjinal parça sayısına eşitse yada büyükse kazandığımızı belirtmek için Winpanel aktif edildi.
    {
        if (k >= original.Count)
        {
            WinPanel.SetActive(true);
            Bitir.SetActive(true);
       
        }
    }
    
    public void Remake() // Eğer Oyuncu oyunu kazandıysa Yapboz parçalarının ilk pozisyonlarına dönmesi sağlandı. ve Kazanıldı değişkeni false olarak belirlendi.
    {
        for (int i = 0; i < original.Count; i++)
        {
            original[i].transform.position = initialPosition[i];
            isWin = false;


            originalsPlace[i].SetActive(true);
            

        }
        
    }

    public void DragNumber1() // Eğer kullanıcı oyunu daha kazanmadıysa yapbozun ilk parçasının mause ile sürüklenmesi sağlandı.
    {
        if (isWin == false)
        {

            original[selectedObjectIndex].transform.position = Input.mousePosition;

        }
    }

    public void DropNumber1() // Eğer kullanıcı oyunu kazanmadıysa ve sürüklenen parça yapboz içerisinde doğru yere bırakıldıysa yapboz parçası yapboz içerisinde yerini alır.
    {
        if (isWin == false)
        {


            float Distance = Vector3.Distance(original[selectedObjectIndex].transform.position, originalsPlace[selectedObjectIndex].transform.position);// Sürüklenen parçanın konumu ile yapboz içerisindeki yerinin farkı alındı.
            if (Distance < 100)
            {
                original[selectedObjectIndex].transform.position = originalsPlace[selectedObjectIndex].transform.position;// // Eğer fark 50'den küçük ise yapboz parçası yapboz içerisindeki yerini alır.

                Destroy(original[selectedObjectIndex].GetComponent<EventTrigger>()); // Yapboz Parçası yerine yerleştirildiğinde tekrar hareket ettirilmesini engellemek için eventtrigger companenti kaldırıldı.

                originalsPlace[selectedObjectIndex].SetActive(false);// yapboz içerisindeki konum bildiren parçanın görünürlülüğü kapatıldı.
                k++;
                IsWinner(); // placement fonksiyonu çağırıldı.
            }
            else
            {
                original[selectedObjectIndex].transform.position = initialPosition[selectedObjectIndex]; // Eğer Fark 50'den büyük ise yapboz parçası ilk konumuna geri gönderildi.

            }
        }
    }
}
