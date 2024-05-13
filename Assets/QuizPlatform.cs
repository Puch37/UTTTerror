using UnityEngine;

public class QuizPlatform : MonoBehaviour
{
    public Canvas quizCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemigo"))
        {
            // Pausar el juego o detener el tiempo si es necesario
            Time.timeScale = 0f;

            // Mostrar el cursor del mouse
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor

            // Activar el canvas de la encuesta
            quizCanvas.gameObject.SetActive(true);
        }
    }

    public void PlayerCompletedQuizSuccessfully()
    {
        // Este método se llama cuando el jugador completa el cuestionario exitosamente
        Debug.Log("¡Jugador completó el cuestionario exitosamente!");
        // Realiza acciones adicionales según sea necesario
    }
}
