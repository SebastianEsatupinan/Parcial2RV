using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Asigna el transform del jugador en el inspector
    public float followSpeed = 5f; // Velocidad de seguimiento
    public float stopDistance = 2f; // Distancia a mantener cuando el jugador se detiene
    public Vector3 offset = new Vector3(1f, 0f, 1f); // Offset diagonal

    void Update()
    {
        // Calcula la distancia al jugador
        float distance = Vector3.Distance(transform.position, player.position);

        // Si la distancia es mayor que la distancia de parada, sigue al jugador
        if (distance > stopDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;
        }
        else
        {
            // Mantén la posición diagonalmente frente al jugador
            Vector3 targetPosition = player.position + player.forward * stopDistance + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }

        // Asegúrate de que el robot siempre mire al jugador
        transform.LookAt(player);
    }
}


