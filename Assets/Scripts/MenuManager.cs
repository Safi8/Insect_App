using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(ButtonColor))] // подключение скрипта своего ButtonColor
public class MenuManager : MonoBehaviour
{
    public GameObject mmPanel;
    public GameObject optionsPanel;

    //private ButtonColor buttonColor;

    public bool _options;
    public bool _play;
    public bool _quit;

    public string tagName;
    void Start()
    {
        //buttonColor = GetComponent<ButtonColor>();
    }

    public void Update()
    {
        if (_play == true)
        {
            Debug.Log("play");
        }
        if (_options == true)
        {
            mmPanel.SetActive(false);
            optionsPanel.SetActive(true);
            _options = false;
        }
        if (_quit == true)
        {
            Debug.Log("play");
        }
    }
}
