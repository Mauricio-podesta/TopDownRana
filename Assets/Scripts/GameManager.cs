using UnityEngine;
using UnityEditor;


public class GameManager : MonoBehaviour
{
    public static void DesfenestrarJuego()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
