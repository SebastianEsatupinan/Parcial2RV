using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pruebadecolliders : MonoBehaviour
{
    public TMP_Text collisionText;  // Arrastra el TextMeshPro aqu� en el Inspector
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

    // Actualiza el texto cada frame, por si deseas realizar m�s acciones
    private void Update()
    {
        if (playerDetected)
        {
            collisionText.text = "Player est� dentro del �rea";
        }
        else
        {
            collisionText.text = "Player no detectado";
        }
    }
}
