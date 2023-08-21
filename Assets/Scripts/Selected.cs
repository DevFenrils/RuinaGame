using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selected : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 2f;
    public Texture2D puntero;
    public GameObject TextDetected;
    GameObject ultimoReconocido = null;
    public GameObject TextObj;
    public GameObject TextTalk;
    public GameObject TextE;
    public float factor = 0.5f;

    // Start is called before the first frame update

    void Start()
    {
        mask = LayerMask.GetMask("RayCastDetect");
        Screen.SetResolution(
            Mathf.CeilToInt(Screen.currentResolution.width * factor),
            Mathf.CeilToInt(Screen.currentResolution.height * factor),
            true
        );

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green, distancia);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia)) {
                Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "InteractNote") {

                    TextE.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) ||  Input.touchCount == 1  && Input.GetTouch(0).phase == TouchPhase.Began) {
                }

           /* } else if (hit.collider.tag == "talk") {

                if (hit.collider.transform.GetComponent<MovementPeasants>().speed > 0) {
                    TextTalk.SetActive(true);

                } else {
                    TextTalk.SetActive(false);

                }

                if (Input.GetKeyDown(KeyCode.E) ||  Input.touchCount == 1  && Input.GetTouch(0).phase == TouchPhase.Began) {
                    hit.collider.transform.GetComponent<MovementPeasants>().Talk();
                }   */
                        
            } else {
                TextE.SetActive(false);
            }
        } else {
                TextE.SetActive(false);
        }
    }
}

    