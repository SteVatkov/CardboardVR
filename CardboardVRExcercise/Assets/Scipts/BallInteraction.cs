using UnityEngine;
using System.Collections;

public class BallInteraction : MonoBehaviour {

    public GameObject target;
    public GameObject ballParent;
    
    bool ballChild = true;

    // Use this for initialization
    void Start()
    {
        highlighted(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ballChild == false)
        {
            float smooth = 2F;
            Vector3 targetPosition = target.transform.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smooth * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    public void highlighted(bool hightlight)
    {
        if (hightlight == true) GetComponent<Renderer>().material.color = new Color32(255, 245, 205, 255);
        else GetComponent<Renderer>().material.color = new Color32(255, 224, 122, 255);
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
        if (ballChild == true)
        {
            this.gameObject.transform.parent = target.transform;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().useGravity = false;
            ballChild = false;
        }
        else
        {
            this.gameObject.transform.parent = ballParent.transform;
            GetComponent<Rigidbody>().useGravity = true;
            ballChild = true;
        }
    }
}
