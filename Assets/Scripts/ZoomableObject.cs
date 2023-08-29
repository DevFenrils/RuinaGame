using System.Collections;
using UnityEngine;


public class ZoomableObject : MonoBehaviour
{
    public Camera playerCamera;
    public float zoomFOV = 30f;
    public float zoomDuration = 3f;
    public float smoothRotationSpeed = 5f;
    public float activationDistance = 5f;
    public AudioClip zoomSound;
    public float soundDuration = 2f;

    private bool isZoomed = false;
    private Quaternion originalRotation;
    private Transform playerTransform;
    private AudioSource audioSource;

    private void Start()
    {
        playerTransform = playerCamera.transform;
        originalRotation = playerTransform.rotation;

        // Obtener o agregar el componente AudioSource.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        // Verificar la distancia entre el jugador y el objeto zoomable.
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer <= activationDistance && !isZoomed)
        {
            StartCoroutine(ZoomIn());
        }
    }

    private IEnumerator ZoomIn()
    {
        isZoomed = true;
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(playerTransform.position, transform.position);

        // Reproducir el sonido si está configurado.
        if (zoomSound != null)
        {
            audioSource.clip = zoomSound;
            audioSource.Play();
        }

        while (Time.time < startTime + zoomDuration)
        {
            // Lerp the rotation towards the object
            Vector3 lookDirection = (transform.position - playerTransform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, smoothRotationSpeed * Time.deltaTime);

            // Zoom the camera
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, zoomFOV, (Time.time - startTime) / zoomDuration);

            yield return null;
        }

        // Esperar la duración del sonido si se ha reproducido uno.
        if (audioSource.isPlaying)
        {
            yield return new WaitForSeconds(soundDuration - (Time.time - startTime));
        }

        // Restaurar FOV original y rotación del jugador.
        playerCamera.fieldOfView = playerCamera.GetComponent<FirstPersonController>().fov;
        playerTransform.rotation = originalRotation;
        isZoomed = false;
    }
}
