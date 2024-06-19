using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDoor : MonoBehaviour
{
    Animator myAnim;
    bool isInZone;

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isInZone && Input.GetKeyDown(KeyCode.E))
        {
            bool isOpen = myAnim.GetBool("isOpen");
            myAnim.SetBool("isOpen", !isOpen);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
        isInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInZone = false;
        }
    }

}
