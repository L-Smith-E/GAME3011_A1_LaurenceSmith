using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int numScans = 6;
    public int extracts = 3;
    public int deposits = 5;
    public bool scanMode = false;

    GridManager grid;
    // Start is called before the first frame update
    private void Start()
    {
        grid = new GridManager(32, 32);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
