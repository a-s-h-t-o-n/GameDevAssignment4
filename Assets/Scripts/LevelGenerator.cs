using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject quadrant;
    [SerializeField] private Sprite[] sprites = new Sprite[7];
    int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
    };
    void Start()
    {
        //destroy pre-placed parent
        quadrant = new GameObject();
        quadrant.transform.parent = transform;
        quadrant.name = "Quadrant" + 1;
        float yCoordinate = 0.0f;
        for (int j = 0; j < 14; j++)
        {
            float xCoordinate = 0.0f;
            for (int k = 0; k < 14; k++)
            {
                
                if (levelMap[j,k] != 0)
                {
                    GameObject tile = new GameObject();
                    tile.name = "tile_" + j + "_" + k;
                    tile.transform.parent = quadrant.transform;
                    tile.transform.position = new Vector3(xCoordinate, yCoordinate, 0.0f);
                    tile.AddComponent<SpriteRenderer>();
                    tile.GetComponent<SpriteRenderer>().sprite = sprites[levelMap[j, k] - 1];
                }
                //instaniate tile from array using [j][k] and make it a child of quadrant

                //attach sprite renderer to object
                //set sprite component to correct tile based on value of array[j][k]
                xCoordinate += 1.0f;
            }

            yCoordinate -= 1.0f;
        }
        
        for (int i = 1; i < 4; i++)
        {
            GameObject newQuadrant = null;
            switch (i)
            {
                case 1:
                    newQuadrant = Instantiate(quadrant, new Vector3(28.0f, 0.0f, 0.0f), Quaternion.Euler(0.0f, 180.0f, 0.0f));
                    break;
                case 2:
                    newQuadrant = Instantiate(quadrant, new Vector3(0.0f, -27.0f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 180.0f));
                    break;
                case 3:
                    newQuadrant = Instantiate(quadrant, new Vector3(28.0f, -27.0f, 0.0f), Quaternion.Euler(0.0f, 180.0f, 180.0f));
                    break;
                default:
                    break;
            }
            
            newQuadrant.transform.parent = transform;
            newQuadrant.name = "Quadrant" + (i + 1);
            
        }
        //instantiate the additional row of tiles for quadrant one and two like here {0,0,0,0,0,0,5,0,0,0,4,0,0,0},

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
