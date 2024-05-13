using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizCounter : MonoBehaviour
{
    public GameObject victoryObject; // Objeto usable con el tag "victoria"

    private int totalQuizzes = 0;
    private int completedQuizzes = 0;

    private void Awake()
    {
        // Desactivar el objeto de victoria al inicio
        if (victoryObject != null)
        {
            victoryObject.SetActive(false);
        }

        // Llamada a un método que encuentra y cuenta los quizzes
        CountQuizzes();
    }

    private void CountQuizzes()
    {
        // Buscar todos los objetos con el tag "CanvasQuiz" en la escena
        GameObject[] quizzes = GameObject.FindGameObjectsWithTag("CanvasQuiz");
        totalQuizzes = quizzes.Length;

        Debug.Log("Total de quizzes: " + totalQuizzes);
    }

    public void QuizCompleted()
    {
        // Este método se llama cuando se completa un quiz
        completedQuizzes++;

        Debug.Log("Quizz completado. Completados: " + completedQuizzes);

        // Verificar si todos los quizzes han sido completados
        if (completedQuizzes >= totalQuizzes)
        {
            ActivateVictoryObject();
        }
    }

    private void ActivateVictoryObject()
    {
        // Activar el objeto de victoria
        if (victoryObject != null)
        {
            victoryObject.SetActive(true);
            Debug.Log("¡Objeto de victoria activado!");

            // Llamada a un método que verifica si no hay más quizzes en la escena
            CheckNoQuizzesLeft();
        }
    }

    private void CheckNoQuizzesLeft()
    {
        // Buscar de nuevo los quizzes
        CountQuizzes();

        // Verificar si no hay más quizzes en la escena
        if (totalQuizzes == 0)
        {
            // Cargar la escena "goodending"
            SceneManager.LoadScene("goodending");
        }
    }
}
