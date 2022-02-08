using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Scan;
    [SerializeField] private GameObject extract;
    private bool active = false;

    private void Start()
    {
        Scan.SetActive(!active);
        extract.SetActive(active);
    }
    public void ToggleMode()
    {
        if (active)
        {
            active = !active;
        }
    }
}
