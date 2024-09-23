using UnityEngine;
using System.Collections;

public class MoveObjectController : MonoBehaviour
{
    public float reachRange = 1.8f;
    public int objectNumber; // Número único para cada objeto (puerta) para diferenciar animaciones

    private Animator anim;
    private GameObject player;

    private const string animBoolPrefix = "isOpen_Obj_"; // Prefijo común para los parámetros booleanos

    private bool playerEntered;

    void Start()
    {
        // Inicializar el jugador y el componente Animator.
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        anim.enabled = false;  // Deshabilitar la animación por defecto.
    }

    // Método que se activa cuando el jugador entra en el collider.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) // Verifica si el objeto que entró es el jugador.
        {
            playerEntered = true;
            OpenDoor(); // Llamamos a la función para abrir la puerta.
        }
    }

    // Método que se activa cuando el jugador sale del collider.
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player) // Verifica si el objeto que salió es el jugador.
        {
            playerEntered = false;
        }
    }

    // Método para abrir la puerta.
    private void OpenDoor()
    {
        if (anim != null)
        {
            anim.enabled = true; // Activar el Animator.
            string animBoolName = animBoolPrefix + objectNumber.ToString(); // Formar el nombre de la animación
            anim.SetBool(animBoolName, true); // Activar la animación específica
        }
    }
}
