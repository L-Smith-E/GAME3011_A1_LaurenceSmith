using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeSwitch : MonoBehaviour
{
    private TextMeshProUGUI mode;
    public GameManager gms;
    [SerializeField]
    private GameObject Extract;
    [SerializeField]
    private GameObject Scan;

    private bool active;
    

    private void Start()
    {
        //mode = FindObjectOfType<TextMeshProUGUI>();
        //gms = GetComponent<GridManager>();
    }
    public void OnModeClick()
    {
        Debug.Log(gms.scanMode);
        // Scan --> Extract
        if (gms.scanMode == true)
        {
            gms.scanMode = true;
            Scan.SetActive(active = false);
            Extract.SetActive(active = true);
            //mode.text = ("Extract Mode");
            Debug.Log(mode);
        }
        // Extract --> Scan
        else
        {
            gms.scanMode = false;
            Extract.SetActive(active = false);
            Scan.SetActive(active = true);
            //mode.text = ("Scan Mode");
            Debug.Log(mode);
        }
    }
}
