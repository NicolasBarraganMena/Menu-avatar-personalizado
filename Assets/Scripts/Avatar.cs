using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{

    [Header("Head Settings")]
    //Control cambio de cabeza
    public GameObject[] Headtypes;
    public int headValue;


    // Start is called before the first frame update
    void Start()
    {
        //Valores iniciales del avatar
        headValue = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //cambiar las cabezas  de los avatares
    public void CambiarCabeza()
    {
        if (headValue < Headtypes.Length - 1)
        {
            headValue++;
        }
        else
        {
            headValue = 0;
        }

        for (int j = 0; j < Headtypes.Length; j++)
        {
            if (headValue != j)
            {
                Headtypes[j].SetActive(false);
            }
            else
            {
                Headtypes[j].SetActive(true);
            }
        }
    }
}
