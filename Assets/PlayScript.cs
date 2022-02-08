using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScript : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject Button;
    private bool active = false;
    public void ToggleGame()
    {
        active = !active;
        Canvas.SetActive(active);
        Button.SetActive(!active);
    }
    
}
