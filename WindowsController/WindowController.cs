using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowController : MonoBehaviour
{

    // class is responsible for opening and closing popups


    [SerializeField] private GameObject WindowSettingCar;
    [SerializeField] private GameObject Car;
    [SerializeField] private GameObject PanelMenu;
    [SerializeField] private GameObject BlackBackground;
    void Start()
    {

        WindowSettingCar.SetActive(false);
        Car.SetActive(true);
        PanelMenu.SetActive(true);
        
        Time.timeScale = 1f;
    }
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     Cursor.lockState =CursorLockMode.None;
        //     Cursor.visible =true;
         

        // }

    }
    public void WindowSettingOpen()
    {
        WindowSettingCar.SetActive(true);
        Car.SetActive(true);
        PanelMenu.SetActive(false);
        
        Time.timeScale = 0f;
    }
    public void WindowSettingClosed()
    {
        WindowSettingCar.SetActive(false);
        Car.SetActive(true);
        PanelMenu.SetActive(true);
       
        Time.timeScale = 1.0f;
        
    }
    public void Respawn()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ComeBackMenu()
    {
        SceneManager.LoadScene(0);
    }

}
