using UnityEngine;
using UnityEngine.UI;

public class Canvas3DQuiz : MonoBehaviour
{
    [System.Serializable]
    public struct QuizQuestion
    {
        public string questionText;
        public bool isTrue;
    }

    public QuizQuestion[] questions;
    public Text questionTextObject; // Objeto de texto para mostrar preguntas
    public Button trueButton; // Botón para respuesta verdadera
    public Button falseButton; // Botón para respuesta falsa
    public Image correctImage; // Imagen para respuesta correcta
    public Image wrongImage;   // Imagen para respuesta incorrecta

    private int currentQuestionIndex = 0;
    private int wrongAnswersCount = 0;
    private float imageDisplayDuration = 0.5f; // Duración en segundos para mostrar las imágenes

    private void Start()
    {
        DisplayQuestion();
        // Asignar funciones a los botones
        trueButton.onClick.AddListener(() => AnswerQuestion(true));
        falseButton.onClick.AddListener(() => AnswerQuestion(false));
    }

    private void DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            // Mostrar la pregunta en el objeto de texto
            questionTextObject.text = "Pregunta: " + questions[currentQuestionIndex].questionText;

            // Activar ambas imágenes
            correctImage.gameObject.SetActive(true);
            wrongImage.gameObject.SetActive(true);

            // Ocultar wrongImage después de la duración especificada
            Invoke("HideWrongImage", imageDisplayDuration);
        }
        else
        {
            // El quiz ha sido completado exitosamente
            QuizCompletedSuccessfully();
        }
    }

    public void AnswerQuestion(bool playerAnswer)
    {
        // Verificar si currentQuestionIndex está dentro de los límites del array
        if (currentQuestionIndex < questions.Length)
        {
            bool correctAnswer = questions[currentQuestionIndex].isTrue;

            if (playerAnswer == correctAnswer)
            {
                // Respuesta correcta
                Debug.Log("Respuesta correcta");
                // Ocultar wrongImage después de la duración especificada
                Invoke("HideWrongImage", imageDisplayDuration);
            }
            else
            {
                // Respuesta incorrecta
                Debug.Log("Respuesta incorrecta");
                // Ocultar correctImage después de la duración especificada
                Invoke("HideCorrectImage", imageDisplayDuration);
                wrongAnswersCount++;

                if (wrongAnswersCount >= 3)
                {
                    // El jugador ha fallado 3 preguntas, reiniciar el quiz
                    RestartQuiz();
                    return;
                }
            }

            // Mostrar la siguiente pregunta
            currentQuestionIndex++;
            DisplayQuestion();
        }
    }

    private void HideCorrectImage()
    {
        // Ocultar correctImage
        correctImage.gameObject.SetActive(false);
    }

    private void HideWrongImage()
    {
        // Ocultar wrongImage
        wrongImage.gameObject.SetActive(false);
    }

    private void QuizCompletedSuccessfully()
    {
        // El jugador ha completado el quiz exitosamente
        Debug.Log("¡Quiz completado exitosamente!");

        // Desactivar el canvas
        gameObject.SetActive(false);
        Debug.Log("Canvas desactivado");

        // Mostrar el cursor del mouse
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor

        // Reanudar el tiempo
        Time.timeScale = 1f;

        // Desactivar el objeto QuizPlatform
        QuizPlatform quizPlatform = FindObjectOfType<QuizPlatform>();
        if (quizPlatform != null)
        {
            quizPlatform.gameObject.SetActive(false);
            Debug.Log("QuizPlatform desactivado");
        }

        // Ocultar el cursor del mouse después de un breve retraso (ajusta según sea necesario)
        Invoke("HideMouseCursor", 0.1f);
    }

    private void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro de la pantalla
    }

    private void RestartQuiz()
    {
        // Reiniciar el quiz
        Debug.Log("Reiniciar quiz");
        currentQuestionIndex = 0;
        wrongAnswersCount = 0;
        DisplayQuestion();
    }
}
