using UnityEngine;
using System.Collections;

public class ButtonInteract : MonoBehaviour {

    public GameObject roof;
    bool open = false;

    Animator animator;

    // Use this for initialization
    void Start() {
        highlighted(false);
        animator = roof.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void highlighted(bool hightlight)
    {
        if (hightlight == true) GetComponent<Renderer>().material.color = Color.white;
        else GetComponent<Renderer>().material.color = new Color32(253,89,89,255);
    }

    public void highlightEnter()
    {
        highlighted(true);
    }

    public void highlightExit()
    {
        highlighted(false);
    }

    public void highlightClick()
    {
        if (open == true)
        {
            animator.SetBool("Open", false);
            open = false;
        }
        else
        {
            animator.SetBool("Open", true);
            open = true;
        }
    }
}
