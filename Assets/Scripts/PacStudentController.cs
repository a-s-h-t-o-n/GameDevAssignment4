using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    // Start is called before the first frame update

    private KeyCode lastInput;
    private KeyCode currentInput;
    [SerializeField] Tweener playerTweener;
    private int[,] levelLayout = {{1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1}, 
                                {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
                                {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2}, 
                                {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
                                {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2}, 
                                {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
                                {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2}, 
                                {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
                                {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2}, 
                                {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1}, 
                                {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0}, 
                                {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
                                {0,0,0,0,0,2,5,4,4,0,3,4,4,4,4,4,4,3,0,4,4,5,2,0,0,0,0,0}, 
                                {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
                                {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0}, 
                                {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
                                {0,0,0,0,0,2,5,4,4,0,3,4,4,4,4,4,4,3,0,4,4,5,2,0,0,0,0,0},
                                {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
                                {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
                                {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
                                {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
                                {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
                                {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
                                {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
                                {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
                                {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
                                {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
                                {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
                                {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1}, };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            lastInput = Input.GetAxisRaw("Horizontal") == 1 ? KeyCode.D : KeyCode.A;
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            lastInput = Input.GetAxisRaw("Vertical") == 1 ? KeyCode.W : KeyCode.S;
        }
        //CheckValidPosition((int)gameObject.transform.localPosition.x, -((int)gameObject.transform.localPosition.y));
    }

    void CheckValidPosition(int posX, int posY)
    {
        if (!playerTweener.TweenExists(gameObject.transform))
        {
            //Debug.Log(posX + " " + posY);
            //switch (lastInput)
            //{
                
            //    case KeyCode.A:
            //        if (levelLayout[posY, posX-1] == 0 || levelLayout[posY, posX-1] == 5 || levelLayout[posY, posX-1] == 6)
            //        {
            //            StartCoroutine(MovePlayer(new Vector3(posX - 9, posY + 4, 0.0f), new Vector3(posX - 10, posY + 4, 0.0f)));
            //            currentInput = lastInput;
            //        }
            //        break;
            //    case KeyCode.D:
            //        if (levelLayout[posY, posX+1] == 0 || levelLayout[posY, posX+1] == 5 || levelLayout[posY, posX+1] == 6)
            //        {
            //            StartCoroutine(MovePlayer(new Vector3(posX - 9, posY + 4, 0.0f), new Vector3(posX-8, posY + 4, 0.0f)));
            //            currentInput = lastInput;
            //        }
            //        break;
            //    case KeyCode.W:
            //        if (levelLayout[posY-1, posX] == 0 || levelLayout[posY-1, posX] == 5 || levelLayout[posY-1, posX] == 6)
            //        {
            //            StartCoroutine(MovePlayer(new Vector3(posX - 9, posY + 4, 0.0f), new Vector3(posX - 9, posY + 5, 0.0f)));
            //            currentInput = lastInput;
            //        }
            //        break;
            //    case KeyCode.S:
            //        if (levelLayout[posY+1, posX] ==5 || levelLayout[posY+1, posX] == 6 || levelLayout[posY+1, posX] == 0)
            //        {
            //            StartCoroutine(MovePlayer(new Vector3(posX - 9, posY + 4, 0.0f), new Vector3(posX - 9, posY + 3, 0.0f)));
            //            currentInput = lastInput;
            //        }
            //        break;
            //    default: break;
            //}
        }
    }

    //IEnumerator MovePlayer(Vector3 start, Vector3 end)
    //{
    //    playerTweener.AddTween(gameObject.transform, start, end, 0.25f);
    //    yield return new WaitForSeconds(0.25f);
    //}


}
