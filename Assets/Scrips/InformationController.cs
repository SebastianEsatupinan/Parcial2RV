using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InformationController : MonoBehaviour
{
    public TextMeshProUGUI infoText; // TMP donde se mostrar� el mensaje
    public GameObject buttonCanvas; // El canvas donde aparecer�n los botones
    public Button buttonPrefab; // Prefab del bot�n que instanciar�s
    public AudioSource audioSource; // Fuente de audio
    public AudioClip notificationSound; // Sonido de notificaci�n

    private Dictionary<string, string[]> placeOptions = new Dictionary<string, string[]>();

    private void Start()
    {
        // Configurar opciones para diferentes lugares
        placeOptions.Add("Entrada", new string[] { "Bienvenido" });
        placeOptions.Add("Sala", new string[] { "�Cu�ntos m2 tiene la sala?", "�Cu�ntas luces tiene?", "�De qu� material es el piso?" });
        placeOptions.Add("Comedor", new string[] { "�Cu�ntas sillas tiene?", "�Qu� tipo de mesa tiene?", "�De que tipo es la Cocina?" });
        placeOptions.Add("Habitacion", new string[] { "�De qu� tama�o es la cama?", "�Tiene escritorio?", "�Cu�ntos armarios tiene?" });
        placeOptions.Add("Ba�o", new string[] { "�El ba�o tiene ducha o ba�era?", "�Cu�ntos lavamanos hay?", "�De qu� color son las baldosas?" });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Place"))
        {
            string placeName = other.gameObject.name;
            if (placeOptions.ContainsKey(placeName))
            {
                // Actualizar el texto principal
                infoText.text = "Est�s en: " + placeName;
                // Limpiar botones anteriores
                ClearButtons();
                // Generar nuevos botones seg�n el lugar
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
        // Reproducir sonido de notificaci�n al interactuar con un bot�n
        PlayNotificationSound();

        switch (option)
        {
            case "�Cu�ntos m2 tiene la sala?":
                infoText.text = "La sala tiene 40m2.";
                break;
            case "�Cu�ntas luces tiene?":
                infoText.text = "La sala tiene 9 luces.";
                break;
            case "�De qu� material es el piso?":
                infoText.text = "El piso es de madera.";
                break;
            case "�Cu�ntas sillas tiene?":
                infoText.text = "El comedor tiene 4 sillas.";
                break;
            case "�Qu� tipo de mesa tiene?":
                infoText.text = "La mesa del comedor es de Madera.";
                break;
            case "De que tipo es la Cocina?":
                infoText.text = "La cocina es Pegada al suelo con acabado de Cer�mica.";
                break;
            case "�De qu� tama�o es la cama?":
                infoText.text = "La cama es de tama�o queen.";
                break;
            case "�Tiene escritorio?":
                infoText.text = "NO, la habitaci�n NO tiene un escritorio.";
                break;
            case "�Cu�ntos armarios tiene?":
                infoText.text = "La habitaci�n tiene 1 armario.";
                break;
            case "�El ba�o tiene ducha o ba�era?":
                infoText.text = "El ba�o tiene una ducha.";
                break;
            case "�Cu�ntos lavamanos hay?":
                infoText.text = "El ba�o tiene 1 lavamanos.";
                break;
            case "�De qu� color son las baldosas?":
                infoText.text = "Las baldosas son de color blanco y negro estilo tabla de ajedrez.";
                break;
            case "Bienvenido":
                infoText.text = "Bienvenido a la casa.";
                break;
            // A�adir m�s respuestas seg�n las opciones
            default:
                infoText.text = "Opci�n no reconocida.";
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
