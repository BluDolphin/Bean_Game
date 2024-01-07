using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public class Cell 
    {
        public bool visited = false; //bool to determin if the algorithm has "been" to that room 
        public bool[] status = new bool[4]; //created an array called status which can hold 4 boolean values 
    }

    public Vector2 MazeSize;   //creates a variable called MazeSize which holds the coordinates of 2 axis 
    [SerializeField] public int StartPos = 0;  //creates an integer variable StartPos
    public GameObject room; //the game object which will be generated 
    public Vector2 offset; //how far apart the object should be generated

    List<Cell> board;

    // Start is called before the first frame update
    void Start()
    {
        MazeGenerator(); //calls MazeGenerator
    }

    void GenerateDungeon()
    {
        for (int i = 0; i < MazeSize.x; i++)
        {
            for (int j = 0; j < MazeSize.y; j++)
            {
                var newRoom = Instantiate(room, new Vector3(i*offset.x,0,-j*offset.y), Quaternion.identity, transform).GetComponent<RoomFunctions>(); //create a new game object at the location with a certian offset 
                newRoom.RoomUpdate(board[Mathf.FloorToInt(i+j*MazeSize.x)].status); //changes the value in the list board to identify that it is occupied 

                newRoom.name += " " +i+ "-" +j; //names each room their x and y axi
            }
        }
    }

    void MazeGenerator()
    {
        board = new List<Cell>(); //the board is the entire dungeon, it contains a list of "Cells" which will be the rooms

        for (int i = 0; i < MazeSize.x; i++)
        {
            for (int j = 0; j < MazeSize.y; j++)
            {
                board.Add(new Cell()); //create a new cell at every location in the list board
            }
        }

        int CurrentCell = StartPos; 

        Stack<int> path = new Stack<int>();

        int k = 0; // variable to track what loop this is 

        while(k < 1000)
        {
            k++;

            board[CurrentCell].visited = true; //set this Cell as visited

            //Check Cells neighbors
            List<int> neighbors = CheckNeighbors(CurrentCell); //check the neighbours if they are visited

            if (neighbors.Count == 0 )
            {
                if (path.Count == 0)
                {
                    break; //if there are no neighbors then break
                }
                else
                {
                    CurrentCell = path.Pop(); //otherwise pop off of stack
                }

            }    
            else 
            {
                path.Push(CurrentCell); //put the current cell onto the stack

                int newCell = neighbors[Random.Range(0,neighbors.Count)]; //get a random number between 0 and how ever many neighbors there are

                if (newCell > CurrentCell) // if the number of neighbors is less than the current cell 
                {
                    //down or right 
                    if (newCell - 1 == CurrentCell)
                    {
                        board[CurrentCell].status[2] = true; //Cell right
                        CurrentCell = newCell;
                        board[CurrentCell].status[3] = true; //cell left
                    }
                    else
                    {
                        board[CurrentCell].status[1] = true; //Cell down
                        CurrentCell = newCell;
                        board[CurrentCell].status[0] = true; //cell up
                    }
                }
                else
                {
                    //up or left
                   if (newCell + 1 == CurrentCell)
                    {
                        board[CurrentCell].status[3] = true; //Cell left
                        CurrentCell = newCell;
                        board[CurrentCell].status[2] = true; //Cell right
                    }
                    else
                    {
                        board[CurrentCell].status[0] = true; //Cell up
                        CurrentCell = newCell;
                        board[CurrentCell].status[1] = true; //Cell down
                    } 
                }
            }

        }
        GenerateDungeon(); //call generate dungeon
    }

    List<int> CheckNeighbors(int Cell)
    {
        List<int> neighbors = new List<int>(); //creates a new integer list called neighbors

        //check up neighbor
        if (Cell - MazeSize.x >= 0 && !board[Mathf.FloorToInt(Cell-MazeSize.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(Cell - MazeSize.x));
        }

        //check down neighbor
        if (Cell + MazeSize.x < board.Count && !board[Mathf.FloorToInt(Cell + MazeSize.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(Cell + MazeSize.x));
        }

        //check right neighbor
        if ((Cell+1) % MazeSize.x != 0 && !board[Mathf.FloorToInt(Cell +1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(Cell +1));
        }

        //check left neighbor
        if (Cell % MazeSize.x != 0 && !board[Mathf.FloorToInt(Cell - 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(Cell -1));
        }

        return neighbors;
        
    }

}