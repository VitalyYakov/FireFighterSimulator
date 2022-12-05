using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleCarController : MonoBehaviour
{
    public WheelCollider[] WColForward;
	public WheelCollider[] WColBack;
	
	public Transform[] wheelsF; //Front wheels
	public Transform[] wheelsB; //Behind wheel
	
	public float wheelOffset = 0.1f; //The minimum error that will be taken into account in the calculations
	public float wheelRadius = 0.13f; //Wheel radius
	
	public static float maxSteer = 30; //The maximum turning angle of the wheels
	public static float maxAccel = 25; //The maximum acceleration that the engine will use
	public static float maxBrake = 50; //The maximum braking force that will affect the engine

	
	public Transform COM; //Center of mass of the body
	
	public class WheelData{ //Prefab for adjusting wheel geometry
		public Transform wheelTransform; //Wheel coordinates XYZ
		public WheelCollider col; //Installation of a solid body on a wheel
		public Vector3 wheelStartPos; //Starting position of the wheels
		public float rotation = 0.0f;  //Turning the wheels
	}
	
	protected WheelData[] wheels;
	
	// Use this for initialization
	
		//The wheels for which we previously set the settings are adjusted from the start
	void Start () {
		GetComponent<Rigidbody>().centerOfMass = COM.localPosition;
		
		wheels = new WheelData[WColForward.Length+WColBack.Length]; 
		
		for (int i = 0; i<WColForward.Length; i++){ 
			wheels[i] = SetupWheels(wheelsF[i],WColForward[i]); 
		}
		
		for (int i = 0; i<WColBack.Length; i++){ 
			wheels[i+WColForward.Length] = SetupWheels(wheelsB[i],WColBack[i]); 
		}
		
	}
	
	//Initialization in a method 
	private WheelData SetupWheels(Transform wheel, WheelCollider col){ 
		WheelData result = new WheelData(); 
		
		result.wheelTransform = wheel; 
		result.col = col; 
		result.wheelStartPos = wheel.transform.localPosition; 
		
		return result; 
		
	}
	// Activation and initialization in a method that will be updated every second
	void FixedUpdate () {
		
		float accel = 0;
		float steer = 0;
				
		accel = Input.GetAxis("Vertical");
		steer = Input.GetAxis("Horizontal");		
		
		CarMove(accel,steer);
		UpdateWheels(); 
	}
	
	
	private void UpdateWheels(){ 
		float delta = Time.fixedDeltaTime; 
		
		
		foreach (WheelData w in wheels){ 
			WheelHit hit; 
								
			Vector3 lp = w.wheelTransform.localPosition; 
			if(w.col.GetGroundHit(out hit)){ 
				lp.y -= Vector3.Dot(w.wheelTransform.position - hit.point, transform.up) - wheelRadius; 
			}else{ 
				
				lp.y = w.wheelStartPos.y - wheelOffset; 
			}
			w.wheelTransform.localPosition = lp; 
			
			
			w.rotation = Mathf.Repeat(w.rotation + delta * w.col.rpm * 360.0f / 60.0f, 360.0f); 
			w.wheelTransform.localRotation = Quaternion.Euler(w.rotation, w.col.steerAngle, 0f); 
		}	
		
	}
	// The method that sets the car in motion visualizes the rotation of the wheels and the turn
	private void CarMove(float accel,float steer){

		
		foreach(WheelCollider col in WColForward){
			col.steerAngle = steer*maxSteer;
		}
		
		if(accel == 0){
			foreach(WheelCollider col in WColBack){
				col.brakeTorque = maxBrake;
			}	
			
		}else{
								
			foreach(WheelCollider col in WColBack){
				col.brakeTorque = 0;
				col.motorTorque	= accel*maxAccel;
			}	
			
		}
		
				
		
	}
	
}