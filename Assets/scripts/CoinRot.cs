using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedCoinRot = 60f;

    void Update()
    {
        transform.Rotate(Vector3.up * speedCoinRot * Time.deltaTime);
    }
}
