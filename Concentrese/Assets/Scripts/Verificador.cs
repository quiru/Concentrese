using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Verificador : MonoBehaviour
{

    GameObject verifUno;
    GameObject verifDos;
    List<GameObject> cubos;
    int cont = 0;
    public Text toques;
    public Text tiempo;
    int conToques;
    int tmpo = 0;
    bool juego = true;

    public Material[] arrMats = new Material[16];

    GameObject msnFinal;

    public static void Shuffle(Material[] mat)
    {
        int n = mat.Length;

        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Material cambiador = mat[k];
            mat[k] = mat[n];
            mat[n] = cambiador;
        }
    }

    int contCubos = 0;
    void Start()
    {
        Shuffle(arrMats);
        cubos = new List<GameObject>();
        foreach (manejoCubos cubs in FindObjectsOfType<manejoCubos>())
        {
            cubos.Add(cubs.gameObject);
            cubos[cont].GetComponent<Renderer>().material = arrMats[cont];
            cont += 1;
        }
        contCubos = cubos.Count;
        msnFinal = GameObject.Find("TextMeshPro");
        msnFinal.SetActive(false);
    }
    
    void Update()
    {
        if (juego == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit obj;
                if (Physics.Raycast(ray, out obj, Mathf.Infinity))
                {
                    if (verifUno == null)
                    {
                        verifUno = obj.transform.gameObject;
                    }
                    else if (verifUno != null && verifDos == null)
                    {
                        verifDos = obj.transform.gameObject;
                        if (verifUno != verifDos && verifUno.GetComponent<Renderer>().material.ToString() == verifDos.GetComponent<Renderer>().material.ToString())
                        {
                            Destroy(verifUno, 2);
                            Destroy(verifDos, 2);
                            contCubos -= 2;
                        }
                        else
                        {
                            verifUno = null;
                            verifDos = null;
                        }
                    }
                }
                conToques += 1;
            }

            if (contCubos == 0)
            {
                msnFinal.SetActive(true);
                juego = false;
            }
            toques.text = "toques: " + conToques;
            tiempo.text = "tiempo:\n" + tmpo;
            tmpo = (int)Time.timeSinceLevelLoad; 
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Volver()
    {
        SceneManager.LoadScene("Menu");
    }
}
