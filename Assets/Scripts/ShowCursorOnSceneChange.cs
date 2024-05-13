using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursorOnSceneChange : MonoBehaviour
{
    void Start()
    {
        // Mostrar u ocultar el cursor según la escena actual
        ShowOrHideCursor();
    }

    void ShowOrHideCursor()
    {
        // Verificar si el objeto con el script está presente en la escena actual
        GameObject cursorVisibleObject = GameObject.Find("CursorVisibleObject");

        if (cursorVisibleObject != null)
        {
            // Mostrar el cursor si el objeto está presente
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Ocultar el cursor si el objeto no está presente
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}