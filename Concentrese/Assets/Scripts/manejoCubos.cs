using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manejoCubos : MonoBehaviour
{
    public bool mover = false;

    public void OnMouseDown()
    {
        mover = true;
        Invoke("hide", 4);
    }

    public void hide()
    {
        mover = false;
    }

    void Update()
    {
        if (mover)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.up * 180, Time.deltaTime));
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.zero, Time.deltaTime));
        }
    }
}
