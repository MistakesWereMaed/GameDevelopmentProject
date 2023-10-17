using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool isGrounded;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Environment")){
            isGrounded = true;
        }
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Environment")){
            isGrounded = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Environment")){
            isGrounded = false;
        }
    }

    public bool GetGroundedState(){
        return isGrounded;
    }
}
