using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuMeneger : MonoBehaviour
{
    // Ссылка на класс состояний кнопки
    ButtonState buttonState;

    // Для того, чтобы активировать руки
    public GameObject realHandsObject;
    public GameObject lowHandsObject;

    // MainMenu and OptionsMenu
    public GameObject mmObject;
    public GameObject omObject;

    public bool isMusic;
    public bool isRealHands;
    public bool isLowHands;
    public bool isBack;


    public bool isPlay;
    public bool isOptions;
    public bool isQuit;

    public bool isInsectBack;
    public bool isInsectMusic;
    public bool isInsectRotate;
    public bool isInsectAnime;
    public bool isInsectNextScene;

    private void Start()
    {
        buttonState = GetComponent<ButtonState>();
    }

    private void Update()
    {
        // Главное меню ...............................
        if (isPlay == true)
        {
            SceneManager.LoadScene(1);
            isPlay = false;
        }
        if (isOptions == true)
        {
            Desactive(mmObject);
            Active(omObject);
            isOptions = false;
        }
        if (isQuit == true)
        {
            Debug.Log("Quit");
            isQuit = false;
        }

        //Меню настроек ...............................
        if (isBack == true)
        {
            Desactive(omObject);
            Active(mmObject);
            isBack = false;
        }
        if (isMusic == true)
        {
            ;
        }
        //Debug.Log("Music");
        //GetComponent<ButtonState>().ToggleButton();
        if (isRealHands == true)
        {
            ;
        }
        //Desactive(realHandsObject);
        if (isLowHands == true)
        {
            ;
        }
        //Desactive(lowHandsObject);

        // Ручное меню, сцена насекомых .................................
        if (isInsectAnime == true)
        {
            isInsectAnime = false;
        }

        if (isInsectRotate == true)
        {
            //isInsectRotate = false;
        }

        if (isInsectBack == true)
        {
            SceneManager.LoadScene(0);
            isInsectBack = false;
        }

        if(isInsectNextScene == true)
        {
            SceneManager.LoadScene(2);
            isInsectNextScene = false;
        }
    }



    // Активация и  дезактивация объектов
    public void Active(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public void Desactive(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
