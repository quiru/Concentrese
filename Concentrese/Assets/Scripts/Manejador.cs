using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manejador : MonoBehaviour
{
    public void Inicio()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
