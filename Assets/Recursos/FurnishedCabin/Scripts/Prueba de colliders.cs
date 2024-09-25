using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pruebadecolliders : MonoBehaviour
{
    public TMP_Text collisionText;  // Arrastra el TextMeshPro aquí en el Inspector
    private bool playerDetected = false;

    // Se llama cuando otro collider entra en el trigger de este objeto
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entra tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
            collisionText.text = "Player detectado!";
        }
    }

    // Se llama cuando otro collider sale del trigger de este objeto
    private void OnTriggerExit(Collider other)
    {
        // Si el objeto que sale tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
            collisionText.text = "Player no detectado";
        }
    }

    // Actualiza el texto cada frame, por si deseas realizar más acciones
    private void Update()
    {
        if (playerDetected)
        {
            collisionText.text = "Player está dentro del área";
        }
        else
        {
            collisionText.text = "Player no detectado";
        }
    }
}
