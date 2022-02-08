using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;

public class GridManager : MonoBehaviour
{
    //private System.Random rand = new System.Random();
    [SerializeField]
    private TileScript m_Tile;
    [SerializeField]
    public int rows = 32;
    public int cols = 32;
    int count = 12;
    int maxCount;

    private int[,] gridArray;
    
    public float tileSize = 1.15f;

    private Dictionary<Vector2, TileScript> tiles;
    private Dictionary<int,int> maxTiles;
    public List<KeyValuePair<int, int>> maxList;
    private List<KeyValuePair<int, int>> fullList;
    private List<List<KeyValuePair<int, int>>> NestList;
    private List<Tuple<int, int, Vector2>> maxTuple;
    TileScript spawnedTile;

    public GridManager(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;

        gridArray = new int[rows, cols];
        //Debug.Log(rows + " " + cols);
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        //GridManager grid = new GridManager(rows, cols);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
     void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, TileScript>();
        //maxTiles = new Dictionary<int, int>();
        NestList = new List<List<KeyValuePair<int, int>>>();
        fullList = new List<KeyValuePair<int, int>>();
        //int count;
        maxList = new List<KeyValuePair<int, int>>();
        maxTuple = new List<Tuple<int, int, Vector2>>();
        int[] yVal = new int[cols];
        for (int x = 0; x < cols; x++)
        {

            for (int y = 0; y < rows; y++)
            {
                
                var spawnedTile = Instantiate(m_Tile, new Vector3(x + tileSize, y + tileSize), Quaternion.identity);
                spawnedTile.deposit = Random.Range(0, 1024);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.SetGridIndices(x, y);
                float posX = x * tileSize;
                float posY = y * -tileSize;
                spawnedTile.transform.position = new Vector2(posX, posY);
                fullList.Add(new KeyValuePair<int, int>(x, y));

                    if (spawnedTile.deposit < 11)
                    {
                        spawnedTile.maxD = true;
                        //Debug.Log("Making MaxD: " + spawnedTile.maxD);
                        maxList.Add(new KeyValuePair<int, int>(x, y));
                        maxTuple.Add(new Tuple<int, int, Vector2>(x - 1, x + 1, new Vector2(x, y)));
                        maxCount++;
                    }
                    if (maxCount == 12)
                    {
                        NestList.Add(maxList);
                    }
                //var trailBlock = spawnedTile;
                //if (this.count > 0)
                //{
                
                // trailBlock = Instantiate(m_Tile, new Vector3(x + tileSize, y + tileSize), Quaternion.identity);
                // trailBlock.transform.position = new Vector2(posX, posY);
                // trailBlock.name = $"Trail {x} {y}";
                // tiles[new Vector2(x, y)] = trailBlock;
                //}
                //this.count++;

                
                CalcHalf(spawnedTile);
            }
            if (x == ((rows * cols) + 1))
            {
                NestList.Add(fullList);
            }
            //foreach (var index in fullList)
            //{
            
        }
                //Add Spawned Tile to Dictionary
                
                    //spawnedTile.halfD = false;
                    //spawnedTile.quartD = false;
                    //var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                    //spawnedTile.Init(isOffset);  
    }


    public  void CalcHalf(TileScript spawn)
    {
        spawnedTile = spawn;
        foreach (var index in maxTuple)
        {
            var prev = index.Item1;
            var next = index.Item2;
            var vec = index.Item3;

            if (((spawnedTile.colValue() - vec.y) == 0))
            {
                //Debug.Log("spawncopy.rowValue() == (vec.x + 1): " + (spawncopy.rowValue() == (vec.x + 1)));
                //Debug.Log("spawncopy.rowValue() == (vec.x - 1): " + (spawncopy.rowValue() - 1 == (vec.x - 1)) + ": " + spawncopy.rowValue() + ", " + (vec.x - 1));

                //Right Side
                if ((spawnedTile.rowValue() == (vec.x))) //&& ((spawncopy.colValue() - vec.y) == 0)) && (spawncopy.colValue() - vec.y  == 0)
                {
                    spawnedTile.halfD = true;
                    //Debug.Log("Right Block HalfD: " + );
                }
                //Left Side
                if (spawnedTile.rowValue() - 1 == (vec.x)) // && (spawncopy.colValue() - (vec.y) == 0)) //((spawncopy.rowValue() == (vec.x - 1)) && ((spawncopy.colValue() - vec.y) == 0))
                {
                    spawnedTile.halfD = true;
                    //Debug.Log("Left Block HalfD: " + item);
                }
            }
        }
            
                
            
            //    Debug.Log(spawncopy);
            //    //Debug.Log("maxList Pair " + ": " + item.Key + ", " + item.Value);




            //    //else if (spawncopy.colValue() == item.Value - 1)
            //    //{
            //    //    spawncopy.halfD = true;
            //    //}
            //    //else if (spawncopy.colValue() == item.Value + 1)
            //    //{
            //    //    spawncopy.halfD = true;
            //    //}
            //    //else if (spawncopy.rowValue() == item.Key + 1 && spawncopy.colValue() == item.Value - 1)
            //    //{
            //    //    spawncopy.halfD = true;
            //    //}
            //    //else if (spawncopy.rowValue() == item.Key + 1 && spawncopy.colValue() == item.Value + 1)
            //    //{
            //    //    spawncopy.halfD = true;
            //    //}
            //    //else if (spawncopy.rowValue() == item.Key - 1 && spawncopy.colValue() == item.Value + 1)
            //    //{
            //    //    spawncopy.halfD = true;
            //    //}
            //    //else if (spawncopy.rowValue() == item.Key - 1 && spawncopy.colValue() == item.Value - 1)
            //    //{
            //    //    spawncopy.halfD = true;
            //    //}
        //}
        //}


    }

    public TileScript GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
    
}
