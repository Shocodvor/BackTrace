using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoin : MonoBehaviour
{

    public GameObject coin;

    void Start()
    {

        StartCoroutine(Box1());



    }


    IEnumerator Box1()

    {

        yield return new WaitForSeconds(7.0f);


        coin.SetActive(false);


       

    }


}
