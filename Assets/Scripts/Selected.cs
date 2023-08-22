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
    public CanvasGroup TextClue;
    GameObject ultimoReconocido = null;
    public GameObject TextObj;
    public GameObject TextTalk;
    public GameObject TextE;
    public float factor = 0.5f;
    public AudioClip newClue;

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
}

