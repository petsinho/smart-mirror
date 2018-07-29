using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class EventManager : MonoBehaviour
{

    public delegate void ClickAction();
    public static event ClickAction OnClicked;
    public Button playButton, photoButton;


    public void StartSnowEffect()
    {
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
        GameObject snow = GameObject.Find("/Effects/Snow");
        snow.SetActive(true);
    }

    void onClick()
    {

    }
    void TaskWithParameters(string message)
    {
        //Output this to console when the Button is clicked
        Debug.Log(message);
    }
}
