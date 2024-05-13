using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneActivationCounter : MonoBehaviour
{
    private int interactionCount = 0;
    public int targetInteractionCount = 8; // El número total de objetos que necesitas interactuar
    public string targetTag = "quiz"; // El tag que deben tener los objetos que incrementarán el contador

    void InteractWithObject()
    {
        // Verifica si el objeto tiene el tag deseado antes de incrementar el contador
        if (gameObject.CompareTag(targetTag))
        {
            interactionCount++;

            if (interactionCount >= targetInteractionCount)
            {
                Debug.Log("¡Has interactuado con todos los objetos! Cargando la escena final.");
                SceneManager.LoadScene("goodending"); // Reemplaza con el nombre de tu escena final
            }
        }
    }
}
