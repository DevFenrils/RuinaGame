using UnityEngine;

public class BookController : MonoBehaviour
{
    public Book bookScript;
    public Canvas bookCanvas;
    // public Camera firstPersonCamera; // Deja esta variable en blanco en el Inspector

    private bool bookActivated = false;
    // private Camera bookCamera; // La cámara del libro

    private void Start()
    {
        // Asegúrate de que el Canvas del libro esté desactivado al inicio.
        bookCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.Locked; // Al inicio, bloquea el cursor
        Cursor.visible = false; // Al inicio, oculta el cursor
    }

    private void Update()
    {
        // Si se pulsa la tecla 'q' y el libro no está activado, activar el control del libro, habilitar el Canvas, desactivar la cámara de primera persona y crear la cámara del libro.
        if (Input.GetKeyDown(KeyCode.Q) && !bookActivated)
        {
            bookActivated = true;
            bookScript.interactable = true;
            bookCanvas.enabled = true;
            // firstPersonCamera.enabled = false;
            Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
            Cursor.visible = true; // Muestra el cursor
            
            // Crear y activar la cámara del libro
            // CreateBookCamera();
       
        }
        // Si se pulsa la tecla 'q' y el libro ya está activado, desactivar el control del libro, deshabilitar el Canvas, activar la cámara de primera persona y destruir la cámara del libro.
        else if (Input.GetKeyDown(KeyCode.Q) && bookActivated)
        {
            bookActivated = false;
            bookScript.interactable = false;
            bookCanvas.enabled = false;
            // firstPersonCamera.enabled = true;
            Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
            Cursor.visible = false; // Oculta el cursor
        
            
            // Destruir la cámara del libro
            // DestroyBookCamera();
        }

        // Si se pulsa la tecla 'esc', desactivar el control del libro, deshabilitar el Canvas, activar la cámara de primera persona y destruir la cámara del libro.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bookActivated = false;
            bookScript.interactable = false;
            bookCanvas.enabled = false;
            // firstPersonCamera.enabled = true;
            Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
            Cursor.visible = false; // Oculta el cursor
            
            // Destruir la cámara del libro
            // DestroyBookCamera();
        }
    }

    // Método para crear la cámara del libro
    // private void CreateBookCamera()
    // {
    //     GameObject cameraObject = new GameObject("BookCamera");
    //     bookCamera = cameraObject.AddComponent<Camera>();
        // Configurar los ajustes de la cámara del libro según tus necesidades
        // Por ejemplo: bookCamera.fieldOfView = 60f;
        // También puedes ajustar la posición y rotación de la cámara si es necesario
    // }

    // Método para destruir la cámara del libro
    // private void DestroyBookCamera()
    // {
    //     if (bookCamera != null)
    //     {
    //         Destroy(bookCamera.gameObject);
    //         bookCamera = null;
    //     }
    // }
}









