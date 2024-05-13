using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimientojugador : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private CharacterController characterController;
    private Camera playerCamera;

    private float verticalRotation = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        // Ocultar el cursor al inicio
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Registrar el evento de cambio de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        // Movimiento del jugador
        float forwardSpeed = Input.GetAxis("Vertical") * speed;
        float sideSpeed = Input.GetAxis("Horizontal") * speed;

        Vector3 speedVector = new Vector3(sideSpeed, 0, forwardSpeed);
        speedVector = transform.rotation * speedVector;

        characterController.SimpleMove(speedVector);

        // Rotación de la cámara
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation += mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Mostrar el cursor al cargar una nueva escena
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnDestroy()
    {
        // Asegúrate de eliminar el evento al destruir el objeto
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
