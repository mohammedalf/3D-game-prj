using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class disappear : MonoBehaviour
{
    GameObject coin;
    
    Text ScoreboardScore;

    
    private string strWithoutDollar = "";
    // Start is called before the first frame update

    void Start()
    {
        ScoreboardScore = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<Text>();
        ScoreboardScore.text = "0$";

        for (int i = 0; i < ScoreboardScore.text.Length - 1; i++)
        {
            strWithoutDollar += ScoreboardScore.text[i];
        }

        coin = GameObject.FindGameObjectWithTag("coin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            

            ScoreboardScore.text = (int.Parse(strWithoutDollar) + 200).ToString();
            ScoreboardScore.text += "$";



            coin.GetComponent<AudioSource>().enabled = true;
            coin.GetComponent<Light>().enabled = true;


            Destroy(gameObject, 0.7f);

        }

    }

}
