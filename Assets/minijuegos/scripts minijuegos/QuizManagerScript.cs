using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[System.Serializable]
public class Question
{
    public string questionText;
    public bool isTrue;
}

public class QuizManagerScript : MonoBehaviour
{
    public Text questionText;
    public Button trueButton;
    public Button falseButton;
    public Image correctImage;
    public Image incorrectImage;

    public List<Question> questionsList;

    private int currentQuestionIndex = 0;
    private int correctAnswersCount = 0;
    private int incorrectAnswersCount = 0;

    private void Start()
    {
        if (questionsList.Count > 0)
        {
            ShowQuestion();
        }
        else
        {
            Debug.LogError("No hay preguntas en la lista. Añade preguntas desde el Inspector.");
        }
    }

    public void AnswerButtonClick(bool isTrue)
    {
        if ((isTrue && questionsList[currentQuestionIndex].isTrue) || (!isTrue && !questionsList[currentQuestionIndex].isTrue))
        {
            Debug.Log("Respuesta correcta");
            correctAnswersCount++;
            ShowFeedbackImage(true);
        }
        else
        {
            Debug.Log("Respuesta incorrecta");
            incorrectAnswersCount++;
            ShowFeedbackImage(false);
        }

        Invoke("NextQuestion", 1f);
    }

    private void NextQuestion()
    {
        currentQuestionIndex++;

        if (currentQuestionIndex < questionsList.Count)
        {
            ShowQuestion();
        }
        else
        {
            // Comprobar si el jugador ha obtenido al menos 3 respuestas correctas.
            if (correctAnswersCount >= 3)
            {
                SceneManager.LoadScene("juego"); // Cargar la escena de resultados.
            }
            else
            {
                // Comprobar si el jugador ha obtenido menos de 3 respuestas incorrectas.
                if (incorrectAnswersCount < 3)
                {
                    // Implementa aquí la lógica para manejar el caso de menos de 3 respuestas incorrectas.
                    Debug.Log("El jugador ha fallado menos de 3 preguntas.");
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recargar la escena actual.
                }
            }
        }

        HideFeedbackImages();
    }

    private void ShowQuestion()
    {
        questionText.text = questionsList[currentQuestionIndex].questionText;
    }

    private void HideFeedbackImages()
    {
        correctImage.gameObject.SetActive(false);
        incorrectImage.gameObject.SetActive(false);
    }

    private void ShowFeedbackImage(bool isCorrect)
    {
        if (isCorrect)
        {
            correctImage.gameObject.SetActive(true);
        }
        else
        {
            incorrectImage.gameObject.SetActive(true);
        }
    }
}