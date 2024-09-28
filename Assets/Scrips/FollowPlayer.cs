using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Transform del jugador
    public float followSpeed = 5f; // Velocidad de seguimiento
    public float stopDistance = 2f; // Distancia mínima al jugador
    public float angleDegrees = 65f; // Ángulo deseado al frente derecho
    public float fixedHeight = 2f; // Altura fija para el robot
    public float distanceFromPlayer = 3f; // Distancia diagonal desde el jugador
    public float rotationOffset = 15f; // Grados para rotar a la izquierda

    void Update()
    {
        // Calcula la distancia al jugador en el plano XZ (ignora la altura)
        Vector3 flatPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 playerFlatPosition = new Vector3(player.position.x, 0, player.position.z);
        float distance = Vector3.Distance(flatPosition, playerFlatPosition);

        // Si la distancia es mayor que la distancia de parada, sigue al jugador en XZ manteniendo la altura fija
        if (distance > stopDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0; // Ignorar el cambio en Y para que la altura no varíe
            transform.position += direction * followSpeed * Time.deltaTime;
        }

        // Calcula la posición diagonalmente frente a la derecha del jugador a 65 grados
        Vector3 offsetDirection = Quaternion.Euler(0, angleDegrees, 0) * player.forward; // Rotamos el vector forward en 65 grados
        Vector3 targetPosition = player.position + offsetDirection.normalized * distanceFromPlayer;
        targetPosition.y = fixedHeight; // Bloquea la altura en un valor fijo

        // Mover el robot hacia la posición calculada
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Haz que el robot mire siempre al jugador manteniendo la altura
        Vector3 lookPosition = new Vector3(player.position.x, player.position.y, player.position.z); // Asegúrate de mirar correctamente al jugador
        transform.LookAt(lookPosition);

        // Ahora rotamos ligeramente el objeto para hacer que mire ligeramente a la izquierda
        transform.Rotate(0, -rotationOffset, 0);
    }
}



