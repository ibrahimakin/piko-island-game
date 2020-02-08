using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piko_Controller : Character
{
    [Header("Walking")]
    public GameObject rayXnegative;
    public GameObject rayXpositive;
    public GameObject rayYnegative;
    public GameObject rayYpositive;
    [Header("Dialogs")]
    public GameObject DialogPanel;
    public GameObject VDialogPanel;
    public Text DialogText;
    public Text VDialogText;
    public List<string> VillageNpcDialogs;
    public List<string> NpcTags;
    public List<GameObject> NPCS;
    public List<GameObject> QuestIcon;
    public List<NpcQuest> NpcDialogs;
    public GameObject DialogAnswer1;
    public GameObject DialogAnswer2;
    [Header("NpcControllerRadius")]
    public float radius;
    public LayerMask mask;
    int index = 0;
    int NpcIndex = 0;
    bool IsDialogPanelOpen = false;
    bool IsVDialogPanelOpen = false;
    bool IsGameScreenOpen = false;
    bool QuestInfoPanel = false;
    private int NpcRandomDialogs;
    private int VillageRandomDialogs;

    void Start()
    {
        direction = Vector2.zero;

      
    }

    protected override void Update()
    {

        Getkey();
        base.Update();
    }

    public void Getkey()
    {
        if (IsDialogPanelOpen == false && IsVDialogPanelOpen==false && IsGameScreenOpen==false)
        {


            direction = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                if (Physics2D.Raycast(rayYpositive.transform.position, Vector2.up, 0.3f, mask).collider == null)
                {
                    direction += Vector2.up;
                }

            }
            if (Input.GetKey(KeyCode.A))
            {

                if (Physics2D.Raycast(rayXnegative.transform.position, Vector2.left, 0.3f, mask).collider == null)
                {
                    direction += Vector2.left;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (Physics2D.Raycast(rayYnegative.transform.position, Vector2.down, 0.3f, mask).collider == null)
                {
                    direction += Vector2.down;
                }


            }
            if (Input.GetKey(KeyCode.D))
            {
                if (Physics2D.Raycast(rayXpositive.transform.position, Vector2.right, 0.3f, mask).collider == null)
                {
                    direction += Vector2.right;
                }
            }



            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.transform.position = gameObject.transform.position;
                CheckNPC();
              
            }

        }


        if (IsDialogPanelOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {


                DialogPanel.SetActive(false);
                IsDialogPanelOpen = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                List<NpcQuest> Completed = NpcDialogs.FindAll(x => x.IsCompleted == false);

                DialogPanel.SetActive(false);
                IsDialogPanelOpen = false;
                Completed[index].GameCanvas.SetActive(true);
                IsGameScreenOpen = true;
            }

          
        }
        if (IsVDialogPanelOpen ==true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                IsVDialogPanelOpen = false;
                VDialogPanel.SetActive(false);
            }
        }

        if (QuestInfoPanel==true)
        {

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

               
                DialogPanel.SetActive(false);
                QuestInfoPanel = false;
                IsGameScreenOpen = false;

            }
        }
    }

   public void Kapat()
    {
        DialogPanel.SetActive(false);
        IsDialogPanelOpen = false;
        IsGameScreenOpen = false;
    }
  void CheckNPC()
    {
   
        List<NpcQuest> Completed = NpcDialogs.FindAll(x => x.IsCompleted == false);

 

       // NpcRandomDialogs = Random.Range(0, NpcDialogs.Count);
       VillageRandomDialogs = Random.Range(0, VillageNpcDialogs.Count);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);


        foreach (Collider2D col in colliders)
        {
            if (col.tag == NpcTags[NpcIndex])
            {
                DialogPanel.SetActive(true);
                IsDialogPanelOpen = true;
                DialogText.text =Completed[index].NpcDialogText;
                DialogAnswer2.SetActive(true);
                DialogAnswer1.SetActive(true);

            
            }
            if (col.tag=="NPC")
            {
                QuestInfoPanel = true;
                DialogAnswer2.SetActive(false);
                DialogPanel.SetActive(true);
                DialogText.text = "Piko bana yardým ettiðin için teþekkürler ama bence diðer görevlerine odaklanmalýsýn.";
            }



            if (col.tag == "NPCQ")
            {
                QuestInfoPanel = true;
                DialogAnswer2.SetActive(false);
                DialogPanel.SetActive(true);
                DialogText.text = "Beni ziyaret ettiðin için teþekkürler. Ama önce diðer görevlerini yapmalýsýn";
            }


            if (col.tag == "VillageNPC")
            {
                IsVDialogPanelOpen = true;
                VDialogPanel.SetActive(true);
                VDialogText.text = VillageNpcDialogs[VillageRandomDialogs];
             
            

            }
        }
    }

    public void QuestCompleted()
    {
    
        List<NpcQuest> Completed = NpcDialogs.FindAll(x => x.IsCompleted == false);

        if (index > Completed.Count)
        {
            index=0;
        }
        Completed[index].IsCompleted = true;

        //index++;


        switch (NpcIndex)
        {
            case 0:
                QuestInfoPanel = true;
                DialogAnswer2.SetActive(false);
                DialogPanel.SetActive(true);
                DialogText.text = "Piko bence artýk kendi yiyeceklerimizi yetiþtirme zamanýmýz geldi. Bu konuda Biyolojici mahmut sana yardýmcý olabilir bence onunla görüþmelisin. Sana yardýmcý olacaktýr.";
                NPCS[NpcIndex].tag = "NPC";
                NpcIndex++;
                break;
            case 1:
                QuestInfoPanel = true;
                DialogAnswer2.SetActive(false);
                DialogPanel.SetActive(true);
                DialogText.text = "Piko artýk kendi yiyeceklerimizi kendimiz yetiþtiriyoruz. Bu harika bir þey. Bence bu iþi ilerletip kendi unumuzuda üretmeliyiz. Bu konuda sana Fizikçi yardýmcý olabilir. Onunla birlikte bir Yel deðirmeni yapabilirsin. Onunla konuþmalýsýn";
                NPCS[NpcIndex].tag = "NPC";
                NpcIndex++;
                break;
            case 2:
                QuestInfoPanel = true;
                DialogAnswer2.SetActive(false);
                DialogPanel.SetActive(true);
                DialogText.text = "Bana yardým ettiðin çok teþekkür ederim. Mimar seni arýyordu bence ona gitmelisin. Senden bir þey isteyebilir .";
                NPCS[NpcIndex].tag = "NPC";
                NpcIndex++;
                break;
            case 3:
                QuestInfoPanel = true;
                DialogAnswer2.SetActive(false);
                DialogPanel.SetActive(true);
                DialogText.text = "Tebrikler piko artýk halkýn ve sen daha iyi ve teknolojik bi adada yaþýyorsun.";
                NPCS[NpcIndex].tag = "NPC";
           
                break;
            default:

            
                break;
        }

        
       
        NPCS[NpcIndex].tag = NpcTags[NpcIndex];
    }


}

[System.Serializable]
public class NpcQuest
{
    public GameObject GameCanvas;
    public string NpcDialogText;
    public bool IsCompleted;
}