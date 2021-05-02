using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{

    [Header("Head Settings")]
    //Control cambio de cabeza
    public GameObject[] Headtypes;
    public int headValue;

    [Header("Skin Settings")]
    //Control cambio de piel
    public Material[] skins;
    public GameObject[] skinParts;
    public int[] skinI;
    public int skinValue;
    Renderer renderer;
    private Material[] materials;

    [Header("Hair Settings")]
    //Control cambio color cabello
    public Material[] hairs;
    public GameObject[] hairParts;
    public int hairValue;
    Renderer rendererH;
    private Material[] hairMaterials;

    // Start is called before the first frame update
    void Start()
    {
        //Valores iniciales del avatar
        headValue = 0;
        skinValue = 0;

        //Funciones manejos materiales
        ControlPiel();
        ControlCabello();
    }

    // Update is called once per frame
    void Update()
    {

        //Funciones manejos materiales
        ControlPiel();
        ControlCabello();

    }

    //cambiar el color de piel
    public void CambiarPiel()
    {
        if (skinValue < skins.Length - 1)
        {
            skinValue = skinValue + 1;
        }
        else
        {
            skinValue = 0;
        }
    }

    //control material piel
    void ControlPiel()
    {
        for (int i = 0; i < skinParts.Length; i++)
        {
            if (i == 0)
            {
                renderer = Headtypes[headValue].GetComponent<Renderer>();
                materials = renderer.sharedMaterials;
                materials[0] = skins[skinValue];
                renderer.enabled = true;
                renderer.sharedMaterials = materials;
            }
            else
            {
                renderer = skinParts[i].GetComponent<Renderer>();
                materials = renderer.sharedMaterials;
                materials[skinI[i]] = skins[skinValue];
                renderer.enabled = true;
                renderer.sharedMaterials = materials;
            }
        }
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

    //Cambiar el color de cabello
    public void CambiarCabello()
    {
        if (hairValue < hairs.Length - 1)
        {
            hairValue = hairValue + 1;
        }
        else
        {
            hairValue = 0;
        }
    }

    //control material cabello
    void ControlCabello()
    {
        for (int i = 0; i < hairParts.Length; i++)
        {
            rendererH = hairParts[i].GetComponent<Renderer>();
            hairMaterials = rendererH.sharedMaterials;
            if (hairMaterials.Length == 2) //Cuando tiene 1 solo material de pelo
            {
                hairMaterials[1] = hairs[hairValue];
                rendererH.enabled = true;
                rendererH.sharedMaterials = hairMaterials;
            }
            else if (hairMaterials.Length == 3)
            { //Cuando tiene 2 materiales de pelo
                hairMaterials[1] = hairs[hairValue];
                hairMaterials[2] = hairs[hairValue];
                rendererH.enabled = true;
                rendererH.sharedMaterials = hairMaterials;
            }
        }
    }
}
