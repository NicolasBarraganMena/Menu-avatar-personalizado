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

    [Header("Shirt Settings")]
    //Control cambio color camisa
    public Material[] shirtColors;
    public GameObject torsoPart;
    public int shirtI;
    public int colorValue;
    Renderer rend;
    private Material[] shirtMaterials;

    [Header("Pants Settings")]
    //Control cambio de pantalon
    public Material[] pantsColors;
    public GameObject pantsPart;
    public int[] pantsI;
    public int pantsValue;
    Renderer r;
    private Material[] pantsMaterials;

    // Start is called before the first frame update
    void Start()
    {
        //Valores iniciales del avatar
        headValue = 0;
        skinValue = 0;
        colorValue = 0;

        //Funciones manejos materiales
        ControlPiel();
        ControlCabello();
        ControlCamisa();
        ControlPantalon();
    }

    // Update is called once per frame
    void Update()
    {

        //Funciones manejos materiales
        ControlPiel();
        ControlCabello();
        ControlCamisa();
        ControlPantalon();
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

    //cambiar color camisa
    public void CambiarCamisa()
    {
        if (colorValue < shirtColors.Length - 1)
        {
            colorValue = colorValue + 1;
        }
        else
        {
            colorValue = 0;
        }
    }

    //control color camisa
    void ControlCamisa()
    {
        rend = torsoPart.GetComponent<Renderer>();
        shirtMaterials = rend.sharedMaterials;
        shirtMaterials[shirtI] = shirtColors[colorValue];
        rend.enabled = true;
        rend.sharedMaterials = shirtMaterials;
    }

    //Cambiar el color de los pantalones
    public void CambiarPantalon()
    {
        if (pantsValue < pantsColors.Length - 1)
        {
            pantsValue = pantsValue + 1;
        }
        else
        {
            pantsValue = 0;
        }
    }

    void ControlPantalon()
    {
        r = pantsPart.GetComponent<Renderer>();
        pantsMaterials = r.sharedMaterials;
        if (pantsMaterials.Length == 2)
        {
            pantsMaterials[pantsI[0]] = pantsColors[pantsValue];
            r.enabled = true;
            r.sharedMaterials = pantsMaterials;
        }
        else if (pantsMaterials.Length == 3)
        {
            pantsMaterials[pantsI[0]] = pantsColors[pantsValue];
            pantsMaterials[pantsI[1]] = pantsColors[pantsValue];
            r.enabled = true;
            r.sharedMaterials = pantsMaterials;
        }
    }
}
