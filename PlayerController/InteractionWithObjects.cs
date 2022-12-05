using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class InteractionWithObjects : MonoBehaviour
{
    // The class is responsible for the firefighter's interaction with various objects and their functions
    
    // Initialization of game objects
    public GameObject FireTruck;
    public GameObject FireTruckCamera;
    public GameObject Rescuer;
    public GameObject Speedometers;
    public GameObject[] AreaOfInteraction;
    public GameObject[] Instruction;
    public GameObject Compartment;
    public GameObject OpenCompartment;
    public GameObject Tips;

    public bool openCompartment= false;
    public bool inPump = false;
    private bool inExit = true;
    public static bool inTruck = false;
    public static bool inCompartment = false;

    public static float steer = 30;
    public static float engine = 0;
    public static float startengine = 6000;
    public CheckBar chb;
    
    void Start()
    {
        Speedometers.SetActive(false);
    }

        
    
    void Update()
    {
        if(Input.GetKey("o"))
        {
            chb.AdjustCurrentValue(-100);
        }
        // When pressing the f key, the fireman will get into the car
        if(!inExit && Input.GetKey("f"))
        {

            AreaOfInteraction[0].SetActive(false); 
            AreaOfInteraction[1].SetActive(false);
            AreaOfInteraction[2].SetActive(false); 
            Rescuer.SetActive(false);
            FireTruckCamera.SetActive(true);
            Speedometers.SetActive(true);
            inTruck=true;
            Debug.Log("inTruck=true");
            CarController.maxAccel = startengine;
            CarController.maxSteer = steer;
        }
        // When you press the e key, the fireman gets out of the car
        if (inTruck && Input.GetKey("e"))
        {
            // AreaOfInteraction[0].SetActive(true); 
            // AreaOfInteraction[1].SetActive(true);
            // AreaOfInteraction[2].SetActive(true); 
            Rescuer.SetActive(true);
            FireTruckCamera.SetActive(false);
            Speedometers.SetActive(false);
            inTruck=false;
            Debug.Log("inTruck=false");
            CarController.maxAccel = 0;
            CarController.maxSteer = 0;

            
        }
        // When the p key is pressed, the fireman opens the compartments
        if (openCompartment & inCompartment & Input.GetKey("p"))
        {
            Compartment.SetActive(true);
        }
        
        if (!inCompartment)
        {
            Compartment.SetActive(false);
        }


        if(inCompartment || inPump)
        {
            if (Input.GetKey("q"))
            {
                OpenCompartment.SetActive(false);
                openCompartment = true;

            }
        }

        if (openCompartment)
        {
            if(Input.GetKey("z"))
            {
            OpenCompartment.SetActive(true);
            openCompartment=false;
            }
        }



        // Activation and deactivation of instructions
        if(inExit && inCompartment)
        {
            Instruction[2].SetActive(true);
            Instruction[0].SetActive(false);
            Instruction[3].SetActive(false);
        }else{
            Instruction[2].SetActive(false);
            Instruction[3].SetActive(false);
        }
        if(!inExit)
        {
            Instruction[1].SetActive(true);
            Instruction[0].SetActive(false);
            Instruction[3].SetActive(false);
        }else{
            Instruction[1].SetActive(false);
            Instruction[3].SetActive(false);
            
        }
        if(inTruck && !inExit)
        {
            Instruction[0].SetActive(false);
            Instruction[1].SetActive(false);
            Instruction[2].SetActive(false);
            Instruction[3].SetActive(true);
        }

        if (inCompartment && !openCompartment && Input.GetKey("p"))
        {
            Tips.SetActive(true);
        }

        
    }


    // Methods responsible for triggers (Contact with the object)

    private void OnTriggerEnter(Collider other)
        {
        FireTruck.GetComponent<CarController>();
            if(other.tag == "OpenDoor")
        {
            Debug.Log("inExit = false;");
            inExit = false;
        }
        if (other.tag == "OpenCompartment")
        {
            inCompartment= true;

            Debug.Log("inCompartment= true");
        }
        if (other.tag =="AllOpenCompartment")
        {
            inPump = true;
        }


        }

        private void OnTriggerExit(Collider other)
        {
            if(other.tag == "OpenDoor")
        {

            Debug.Log("inExit = true");
            inExit = true;
        }
        if (other.tag == "OpenCompartment")
        {
            inCompartment= false;
            Debug.Log("inCompartment= false");
        }
        if (other.tag =="AllOpenCompartment")
        {
            inPump = false;
        }
        }
}
