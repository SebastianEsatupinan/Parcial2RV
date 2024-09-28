using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InformationController : MonoBehaviour
{
    public TextMeshProUGUI infoText; // TMP donde se mostrará el mensaje
    public GameObject buttonCanvas; // El canvas donde aparecerán los botones
    public Button buttonPrefab; // Prefab del botón que instanciarás
    public AudioSource audioSource; // Fuente de audio
    public AudioClip notificationSound; // Sonido de notificación

    private Dictionary<string, string[]> placeOptions = new Dictionary<string, string[]>();

    private void Start()
    {
        // Configurar opciones para diferentes lugares
        placeOptions.Add("Entrada", new string[] { "Bienvenido" });
        placeOptions.Add("Sala", new string[] { "¿Cuántos m2 tiene la sala?", "¿Cuántas luces tiene?", "¿De qué material es el piso?" });
        placeOptions.Add("Comedor", new string[] { "¿Cuántas sillas tiene?", "¿Qué tipo de mesa tiene?", "¿De que tipo es la Cocina?" });
        placeOptions.Add("Habitacion", new string[] { "¿De qué tamaño es la cama?", "¿Tiene escritorio?", "¿Cuántos armarios tiene?" });
        placeOptions.Add("Baño", new string[] { "¿El baño tiene ducha o bañera?", "¿Cuántos lavamanos hay?", "¿De qué color son las baldosas?" });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Place"))
        {
            string placeName = other.gameObject.name;
            if (placeOptions.ContainsKey(placeName))
            {
                // Actualizar el texto principal
                infoText.text = "Estás en: " + placeName;
                // Limpiar botones anteriores
                ClearButtons();
                // Generar nuevos botones según el lugar
                CreateButtonsForPlace(placeName);
            }
        }
    }

    private void CreateButtonsForPlace(string placeName)
    {
        string[] options = placeOptions[placeName];

        foreach (string option in options)
        {
            Button newButton = Instantiate(buttonPrefab, buttonCanvas.transform);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = option;
            newButton.onClick.AddListener(() => OnOptionSelected(option));
        }
    }

    private void OnOptionSelected(string option)
    {
        // Reproducir sonido de notificación al interactuar con un botón
        PlayNotificationSound();

        switch (option)
        {
            case "¿Cuántos m2 tiene la sala?":
                infoText.text = "La sala tiene 40m2.";
                break;
            case "¿Cuántas luces tiene?":
                infoText.text = "La sala tiene 9 luces.";
                break;
            case "¿De qué material es el piso?":
                infoText.text = "El piso es de madera.";
                break;
            case "¿Cuántas sillas tiene?":
                infoText.text = "El comedor tiene 4 sillas.";
                break;
            case "¿Qué tipo de mesa tiene?":
                infoText.text = "La mesa del comedor es de Madera.";
                break;
            case "De que tipo es la Cocina?":
                infoText.text = "La cocina es Pegada al suelo con acabado de Cerámica.";
                break;
            case "¿De qué tamaño es la cama?":
                infoText.text = "La cama es de tamaño queen.";
                break;
            case "¿Tiene escritorio?":
                infoText.text = "NO, la habitación NO tiene un escritorio.";
                break;
            case "¿Cuántos armarios tiene?":
                infoText.text = "La habitación tiene 1 armario.";
                break;
            case "¿El baño tiene ducha o bañera?":
                infoText.text = "El baño tiene una ducha.";
                break;
            case "¿Cuántos lavamanos hay?":
                infoText.text = "El baño tiene 1 lavamanos.";
                break;
            case "¿De qué color son las baldosas?":
                infoText.text = "Las baldosas son de color blanco y negro estilo tabla de ajedrez.";
                break;
            case "Bienvenido":
                infoText.text = "Bienvenido a la casa.";
                break;
            // Añadir más respuestas según las opciones
            default:
                infoText.text = "Opción no reconocida.";
                break;
        }
    }

    private void PlayNotificationSound()
    {
        if (audioSource != null && notificationSound != null)
        {
            audioSource.PlayOneShot(notificationSound); // Reproducir el sonido una vez
        }
    }

    private void ClearButtons()
    {
        foreach (Transform child in buttonCanvas.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
