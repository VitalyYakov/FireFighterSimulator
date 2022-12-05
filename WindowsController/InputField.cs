using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    private float Maxsteer;
    private float Massa;
    private float Maxaccel;
    private float Maxbrake;
    private string NewMaxSteer;
    private string NewMass;
    private string NewMaxBrake;
    private string NewMaxAccel;
    public Rigidbody rigid;
    [SerializeField] private GameObject TextMass,TextCut,TextPot,TextGalm;
    [SerializeField] private GameObject InputmaxSteer;
    [SerializeField] private GameObject InputmaxAccel;
    [SerializeField] private GameObject InputmaxBrake;
    [SerializeField] private GameObject InputMass;
public void SetMaxSteer()
{
      NewMaxSteer=InputmaxSteer.GetComponent<Text>().text;
      TextCut.GetComponent<Text>().text = "Перевірка  градусу повороту " + NewMaxSteer ;
      float Maxsteer = float.Parse(NewMaxSteer);
      CarController.maxSteer = Maxsteer;
}
public void SetMass()
{
      NewMass=InputMass.GetComponent<Text>().text;
      TextMass.GetComponent<Text>().text = "Перевірка  маси автомобіля " + NewMass ;
      float Massa = float.Parse(NewMass);
      rigid.GetComponent<Rigidbody>().mass = Massa;


}
public void SetMaxAccel()
{
      NewMaxAccel=InputmaxAccel.GetComponent<Text>().text;
      TextPot.GetComponent<Text>().text = "Перевірка  потужності двигуна " + NewMaxAccel ;
      float Maxaccel = float.Parse(NewMaxAccel);
      CarController.maxAccel = Maxaccel;
}
public void SetMaxBrake()
{
      NewMaxBrake=InputmaxBrake.GetComponent<Text>().text;
      TextGalm.GetComponent<Text>().text = "Перевірка сили гальмів " + NewMaxBrake ;
      float Maxbrake = float.Parse(NewMaxBrake);
      CarController.maxBrake = Maxbrake;
}
}
