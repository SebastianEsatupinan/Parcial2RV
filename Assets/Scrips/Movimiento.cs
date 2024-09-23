using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidadMovimiento = 10.0f; // Velocidad a la que se moverá la cámara

    // Update se llama una vez por frame
    void Update()
    {
        // Obtener la entrada de las teclas WASD
        float movimientoHorizontal = Input.GetAxis("Horizontal"); // A y D o flechas
        float movimientoVertical = Input.GetAxis("Vertical"); // W y S o flechas

        // Calcular la dirección de movimiento en base a la orientación de la cámara
        Vector3 direccionMovimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);

        // Mover la cámara en la dirección calculada con respecto a la orientación de la cámara
        transform.Translate(direccionMovimiento * velocidadMovimiento * Time.deltaTime);
    }
}
