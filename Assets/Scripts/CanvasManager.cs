using UnityEngine;

using TMPro;


public class CanvasManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI componenteTextoVida = null;
    [SerializeField] TextMeshProUGUI componenteTextoPuntaje = null;



	public void ActualizarVida(int vida)
	{
		componenteTextoVida.text = "Vida: " + vida;
	}
    public void ActualizarPuntaje(int puntaje)
	{
		componenteTextoPuntaje.text = "Puntaje: " + puntaje.ToString("0000");
	}
}
