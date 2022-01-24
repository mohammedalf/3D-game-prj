using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjToDes : MonoBehaviour
{
    // Start is called before the first frame update
    
    GameObject Filter1, Filter2, Filter3, Filter4;

    [SerializeField] GameObject PlacedCanvas;
    private int flagVector = 0;

    private float time = 0.0f;
    private bool show = true;

    private int score = 0;

    private PickUp pu;

    void Start()
    {
        pu = new PickUp();
        Filter1 = GameObject.FindGameObjectWithTag("Filter1");
        Filter2 = GameObject.FindGameObjectWithTag("Filter2");
        Filter3 = GameObject.FindGameObjectWithTag("Filter3");
        Filter4 = GameObject.FindGameObjectWithTag("Filter4");
    }

    void Placed(int newflagVector)
    {
        if (show)
        {
            PlacedCanvas.SetActive(true);

            if (time > 3)
            {
                PlacedCanvas.SetActive(false);
                time = 0.0f;
                show = false;
                flagVector = newflagVector;
            }
            time += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,Filter1.transform.position) < 0.7)
        {
            if (flagVector != 1)
            {
                Placed(1);
            }
            
        }

        if (Vector3.Distance(transform.position, Filter2.transform.position) < 0.7)
        {
            if (flagVector != 2)
            {
                Placed(2);
            }
        }

        if (Vector3.Distance(transform.position, Filter3.transform.position) < 0.7)
        {
            if (flagVector != 3)
            {
                Placed(3);
            }
        }

        if (Vector3.Distance(transform.position, Filter4.transform.position) < 0.7)
        {
            if (flagVector != 4)
            {
                Placed(4);
            }
        }
    }
}
