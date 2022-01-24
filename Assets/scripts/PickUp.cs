using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class PickUp : MonoBehaviour
{


    // Start is called before the first frame update

    public int counter = 0;


    public Transform Dest;
    

    public GameObject txt;


    private int flags = 0;

    internal int parsedScore;
    internal int GlobalScore = 2;

    internal string strWithoutDollar ="";

    private bool flagMouseDown = false;
    Text ScoreboardScore;


    public GameObject MessageCanvas;

    public float time = 0.0f;

    public bool buyflag = false;



    private void Start()
    {
        ScoreboardScore = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<Text>();


    }

    private void Update()
    {

        for (int i = 0; i < ScoreboardScore.text.Length - 1; i++)
        {
            strWithoutDollar += ScoreboardScore.text[i];
        }
        string strWithoutDollarF = strWithoutDollar;
        strWithoutDollar = "";
        parsedScore = int.Parse(strWithoutDollarF);

        if (flagMouseDown)
        {

            if (parsedScore > 30)
            { 
                if (flags != 1)
                {

                    parsedScore -= 30;
                    GlobalScore = parsedScore;
                    ScoreboardScore.text = parsedScore + "$";
                    flags = 1;
                }
                
            
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = Dest.position;
            this.transform.parent = GameObject.Find("dest").transform; 
            }

            if (parsedScore < 30)
            {
                MessageCanvas.SetActive(true);


                buyflag = true;
             
            }
        }

        if (buyflag)
        {
            if (time > 3)
            {
                MessageCanvas.SetActive(false);
                buyflag = false;
                time = 0.0f;
            }

            time += Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.A))
        {
            flagMouseDown = false;
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }
        flagMouseDown = false;

    }


    private void OnMouseDown()
    {

        flagMouseDown = true;

    }



}
