using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    public Button Temizle;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Temizle.onClick.AddListener(Clear);
    }
    void Clear()
    {
        animator.SetBool("Ekildi", false);
    }
    public void Ibrahim()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (transform.parent.tag == "Grid")
        {
            animator.SetBool("Ekildi", true);
        }
    }
}
