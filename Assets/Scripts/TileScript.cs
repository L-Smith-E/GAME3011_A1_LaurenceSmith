using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class TileScript : MonoBehaviour, IPointerClickHandler
{

    private int row, col;
    [SerializeField]
    public GameManager gms;
    [SerializeField]
    public GridManager grid;
    //private GameObject _maxChild;
    //private GameObject _halfChild;
    //private GameObject _quarterChild;
    
    [SerializeField] 
    public SpriteRenderer SR;
    [SerializeField]
    private SpriteRenderer SR_max;
    [SerializeField]
    private SpriteRenderer SR_half;
    [SerializeField]
    private SpriteRenderer SR_quart;

    Vector2 vec2Var;

    //Deposits
    public bool maxD;
    public bool halfD;
    public bool quartD;
    //private bool active;
    public int deposit;

    //Scan
    public bool scanned = false;

    private List<KeyValuePair<int, int>> m_maxList;

    // Start is called before the first frame update
    void Start()
    {
        //m_maxList = grid.maxList;
        //[MenuItem("Tile")]
        //static void Ping()
        // {
        //     if (!Selection.activeObject)
        //     {
        //         Debug.Log("Select an object to ping");
        //         return;
        //     }

        //     EditorGUIUtility.PingObject(Selection.activeObject);
        // }
        //gms = transform.parent.GetComponent<GridManager>();
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = true;
        //_maxChild = this.gameObject.transform.GetChild(0).gameObject;
        SR_max = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();

        //_halfChild = this.gameObject.transform.GetChild(1).gameObject;
        SR_half = this.gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();

        //_quarterChild = this.gameObject.transform.GetChild(2).gameObject;
        SR_quart = this.gameObject.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>();

        SR_max.enabled = false;
        SR_half.enabled = false;
        SR_quart.enabled = false;

        //Debug.Log("Start MaxD" + maxD);
        gms.scanMode = false;
        CalHalf();
    }
    public void OnMouseEnter()
    {
        //Debug.Log("Row: " + row + "Cols: " + col);
        //Debug.Log("Hover");
    }
    public void SetGridIndices(int r, int c)
    {
        row = r;
        col = c;
        vec2Var = new Vector2 (r,c);
    }

    public int rowValue()
    {
        return row;
    }
    public int colValue()
    {
        return col;
    }

    public Vector2 returnVec2()
    {
        return vec2Var;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
    public void OnMouseDown()
    {
        //if (gms.numScans > 0)
        // {
        //     gms.numScans -= 1;
        // }
        Debug.Log("Click");
        if (gms.scanMode == false)
        {
            gms.scanMode = true;
        }
        else
         gms.scanMode = false;
    }

    public void CalHalf()
    {
       //m_maxList = new List<KeyValuePair<int, int>>();
        //m_maxList = grid.maxList;
        //Debug.Log("this.rowValue() is: " + this.rowValue());
        //foreach (var item in m_maxList)
        //{
        //    Debug.Log(item.Key);
        //    //Right Side
        //    //if ((this.rowValue() == (item.Key + 1))) //&& ((spawncopy.colValue() - item.Value) == 0)) && (spawncopy.colValue() - item.Value  == 0)
        //    //{
        //    //    this.halfD = true;
        //    //    Debug.Log("Right Block HalfD: " + item);
        //    //}
        //    //Left Side
        //    //if (this.rowValue() - 1 == (item.Key - 1)) // && (spawncopy.colValue() - (item.Value) == 0)) //((spawncopy.rowValue() == (item.Key - 1)) && ((spawncopy.colValue() - item.Value) == 0))
        //    //{
        //    //    this.halfD = true;
        //    //    Debug.Log("Left Block HalfD: " + item);
        //    //}
        //}
    }
    // Update is called once per frame
    void Update()
    {


        if (gms.scanMode == true)
        {
            // Tile Colour Deposit --- Sprite Renderers
            if ((this.maxD || this.halfD || this.quartD) == true)
            {
                //Debug.Log("maxD || halfD || quartD: " + (this.maxD || this.halfD || this.quartD));
                //Debug.Log("maxD is " + this.maxD);
                //Debug.Log("halfD is " + this.halfD);
                //Debug.Log("QuartD is " + this.quartD);
                //Blank Tile Off
                SR.enabled = false;
                //Debug.Log("Blank Tile = " + SR.enabled);

                //Max Tile On
                if (this.maxD == true)
                {
                    SR_max.enabled = true;
                    SR_half.enabled = false;
                    SR_quart.enabled = false;
                }
                //Half Tile On
                else if (this.halfD == true)
                {
                    SR_max.enabled = false;
                    SR_half.enabled = true;
                    SR_quart.enabled = false;
                    //Debug.Log(this.name);
                }
                //Quarter Tile On
                else if (this.quartD == true)
                {
                    SR_max.enabled = false;
                    SR_half.enabled = false;
                    SR_quart.enabled = true;
                }
            }
            else if ((this.maxD && this.halfD && this.quartD) == false)
            {
                //Blank Tile On
                SR.enabled = true;
                SR_max.enabled = false;
                SR_half.enabled = false;
                SR_quart.enabled = false;
            }
        }
        else SR.enabled = true;
           
        }
    }

