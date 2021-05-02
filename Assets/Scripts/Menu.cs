using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Avatar Settings")]
    //Referencia a los objetos
    public GameObject[] avatars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Rotar avatar
    public void Rotar(int direccion)
    {
        for (int i = 0; i < avatars.Length; i++)
        {
            avatars[i].transform.Rotate(0, direccion * 30, 0, Space.World);
        }
    }

    //Cambiar de sexo
    public void CambiarSexo(int sexoActual)
    {
        for (int i = 0; i < avatars.Length; i++)
        {
            if (sexoActual != i)
            {
                avatars[i].SetActive(false);
            }
            else
            {
                avatars[i].SetActive(true);
            }
        }
    }
}
