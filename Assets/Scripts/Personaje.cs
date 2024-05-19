using UnityEngine;


public class Personaje : MonoBehaviour
{
	[SerializeField] protected string nombre;


	public virtual void MostrarPresentacionEnConsola()
	{
		Debug.Log("Nombre del personaje: " + nombre + ".");
	}
}
