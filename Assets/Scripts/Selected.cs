using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selected : MonoBehaviour
{
    public ArrayModificationSystem modificationSystem;
    LayerMask mask;
    public float distancia = 2f;
    public Texture2D puntero;
    public GameObject TextDetected;
    GameObject ultimoReconocido = null;
    public GameObject TextObj;
    public GameObject TextTalk;
    public GameObject TextE;
    public float factor = 0.5f;

    void Start()
    {
        mask = LayerMask.GetMask("RayCastDetect");
        Screen.SetResolution(
            Mathf.CeilToInt(Screen.currentResolution.width * factor),
            Mathf.CeilToInt(Screen.currentResolution.height * factor),
            true
        );

    }

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green, distancia);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia))
        {
            if (hit.collider.tag == "InteractPista1")
            {

                TextE.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) || Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                {

                    int indexToIncrement = 1;
                    modificationSystem.IncrementCounter(indexToIncrement);
                    hit.collider.tag = "Untagged";
                }

            }
            else
            {
                TextE.SetActive(false);
            }
        }
        else
        {
            TextE.SetActive(false);
        }
    }
}

