using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Selected : MonoBehaviour
{
    public ArrayModificationSystem modificationSystem;
    LayerMask mask;
    public float distancia = 2f;
    public Texture2D puntero;
    public CanvasGroup TextClue;
    GameObject ultimoReconocido = null;
    public GameObject TextObj;
    public GameObject TextTalk;
    public GameObject TextE;
    public GameObject Letter;
    public float factor = 0.5f;
    public AudioClip newClue;
    public AudioClip doorSound;

    public Transform playerTransform;
    public Transform teleportTarget;
    public Transform teleportTargetOutDes;

    public GameObject blackoutPanel;
    public GameObject returnPanel;


    void Start()
    {
        TextClue.alpha = 0f;
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
                    //TextClue.SetActive(true);
                    StartCoroutine(FadeInAndOut());
                    AudioSource.PlayClipAtPoint(newClue, transform.position, 1);


                }

            }
            else if (hit.collider.tag == "DoorDespacho")
            {

                TextE.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) || Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                {

                    playerTransform.position = teleportTarget.position;

                    AudioSource.PlayClipAtPoint(doorSound, transform.position, 1);

                    StartCoroutine(TransitionEffect());

                }
                
            }
            else if (hit.collider.tag == "DoorOutDespacho")
            {

                TextE.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) || Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                {

                    playerTransform.position = teleportTargetOutDes.position;

                    AudioSource.PlayClipAtPoint(doorSound, transform.position, 1);

                    StartCoroutine(TransitionEffect());

                }

            }
            else if (hit.collider.tag == "LetterDespacho")
            {

                TextE.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) || Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                   Letter.SetActive(true);
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
        
        if(Input.GetKeyDown(KeyCode.Escape) && Letter.activeSelf){
            Letter.SetActive(false);
        }
    }

    IEnumerator FadeInAndOut()
    {
        float duration = 1.0f;
        yield return StartCoroutine(FadeIn(duration));
        yield return new WaitForSeconds(duration);
        yield return StartCoroutine(FadeOut(duration));

    }

    IEnumerator FadeIn(float duration)
    {
        float salpha = 0f;
        float ealpha = 1f;
        Debug.Log("fadeIN");
        float init = 0f;
        while (init < duration)
        {
            TextClue.alpha = Mathf.Lerp(salpha, ealpha, init / duration);
            init += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeOut(float duration)
    {
        float salpha = 1f;
        float ealpha = 0f;
        Debug.Log("fadeOUT");

        float init = 0f;
        while (init < duration)
        {
            TextClue.alpha = Mathf.Lerp(salpha, ealpha, init / duration);
            init += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator TransitionEffect()
    {
        blackoutPanel.SetActive(true);

        float duration = 1.5f;
        float startAlpha = 1f;
        float endAlpha = 0f;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            Color color = blackoutPanel.GetComponent<Image>().color;
            color.a = alpha;
            blackoutPanel.GetComponent<Image>().color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        blackoutPanel.SetActive(false);

        /*returnPanel.SetActive(true);

        duration = 1.5f;
        startAlpha = 0f;
        endAlpha = 1f;

        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            Color color = returnPanel.GetComponent<Image>().color;
            color.a = alpha;
            returnPanel.GetComponent<Image>().color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        returnPanel.SetActive(false);*/

    }
}

