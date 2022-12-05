using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour 
{
    public WheelCollider[] WColForward;
	public WheelCollider[] WColBack;
	public Transform[] wheelsF; //1
	public Transform[] wheelsB; //1
	
	public float wheelOffset = 0.1f; //2
	public float wheelRadius = 0.13f; //2
	
	public static float maxSteer = 0;
	public static float maxAccel = 0;
	public static float maxBrake = 12000;
	
	public Transform COM;
	
	public class WheelData{ //3
		public Transform wheelTransform; //4
		public WheelCollider col; //5
		public Vector3 wheelStartPos; //6 
		public float rotation = 0.0f;  //7
	}
	
	protected WheelData[] wheels; //8
	
	// Use this for initialization
	
		
	void Start () {
		
		GetComponent<Rigidbody>().centerOfMass = COM.localPosition;
		
		wheels = new WheelData[WColForward.Length+WColBack.Length]; //8
		
		for (int i = 0; i<WColForward.Length; i++){ //9
			wheels[i] = SetupWheels(wheelsF[i],WColForward[i]); //9
		}
		
		for (int i = 0; i<WColBack.Length; i++){ //9
			wheels[i+WColForward.Length] = SetupWheels(wheelsB[i],WColBack[i]); //9
		}
		
	}
	
	
	private WheelData SetupWheels(Transform wheel, WheelCollider col){ //10
		WheelData result = new WheelData(); 
		
		result.wheelTransform = wheel; //10
		result.col = col; //10
		result.wheelStartPos = wheel.transform.localPosition; //10
		
		return result; //10
		
	}
	
	void FixedUpdate () {
		
		float accel = 0;
		float steer = 0;
				
		accel = Input.GetAxis("Vertical");
		steer = Input.GetAxis("Horizontal");		
		
		CarMove(accel,steer);
		UpdateWheels(); //11
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

