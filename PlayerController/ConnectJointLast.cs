using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectJointLast : MonoBehaviour
{
   private InteractionWithObjects iteraction;
    public bool examinationTag;
    bool hasJoint;
   //  public GameObject LastConnectJoint;
    public GameObject FirstConnectJoint;

    private void Update() {

        if (examinationTag && FirstConnectJoint.GetComponent<FixedJoint>() != null && Input.GetKeyUp("f"))
     {
        FirstConnectJoint.GetComponent<FixedJoint>().connectedBody = GameObject.Find("ConectedJointFirst").GetComponent<Rigidbody>();
        // hasJoint= false;
     }else if(examinationTag && FirstConnectJoint.GetComponent<FixedJoint>() == null)
     {
        FirstConnectJoint.AddComponent<FixedJoint>();
     }
    }

    
    void OnCollisionEnter (Collision collision)
 {
     if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint) 
     {
         gameObject.AddComponent<FixedJoint> ();  
         gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
         hasJoint = true;
     }
 }
 private void OnTriggerEnter(Collider other)
        {
           if (other.gameObject.tag=="Rescuer")
         {
            examinationTag=true;
         } 
        }

        private void OnTriggerExit(Collider other)
        {
             if (other.gameObject.tag=="Rescuer")
               {
                examinationTag=false;
               }
        }
}
