using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidadMovimiento = 10.0f; // Velocidad a la que se mover� la c�mara

    // Update se llama una vez por frame
    void Update()
    {
        // Obtener la entrada de las teclas WASD
        float movimientoHorizontal = Input.GetAxis("Horizontal"); // A y D o flechas
        float movimientoVertical = Input.GetAxis("Vertical"); // W y S o flechas

        // Calcular la direcci�n de movimiento en base a la orientaci�n de la c�mara
        Vector3 direccionMovimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);

        // Mover la c�mara en la direcci�n calculada con respecto a la orientaci�n de la c�mara
        transform.Translate(direccionMovimiento * velocidadMovimiento * Time.deltaTime);
    }
}
