using UnityEngine;


public class Enemigo : Personaje
{
	[SerializeField] Transform limiteIzquierdo = null;
	[SerializeField] Transform limiteDerecho = null;

	[SerializeField] float velocidad = 5.0f;


	void Awake()
	{
		MostrarPresentacionEnConsola();
	}

	void Update()
	{
		if (SiSePasoDelLimiteIzquierdo() == true)
		{
			EstablecerEnElLimiteIzquierdo();
			InvertirVelocidad();
		}
		else if (SiSePasoDelLimiteDerecho() == true)
		{
			EstablecerEnElLimiteDerecho();
			InvertirVelocidad();
		}

		AplicarVelocidad();
	}



	public override void MostrarPresentacionEnConsola()
	{
		Debug.Log("Nombre del enemigo: " + nombre + ".");
	}

	bool SiSePasoDelLimiteIzquierdo()
	{
		bool sePaso = false;

		if (transform.position.x < limiteIzquierdo.position.x)
		{
			sePaso = true;
		}

		return sePaso;
	}
	bool SiSePasoDelLimiteDerecho()
	{
		bool sePaso = false;

		if (transform.position.x > limiteDerecho.position.x)
		{
			sePaso = true;
		}

		return sePaso;
	}

	void EstablecerEnElLimiteIzquierdo()
	{
		transform.position = new Vector3(limiteIzquierdo.position.x, transform.position.y);
	}
	void EstablecerEnElLimiteDerecho()
	{
		transform.position = new Vector3(limiteDerecho.position.x, transform.position.y);
	}
	void InvertirVelocidad()
	{
		velocidad = -velocidad;
	}
	void AplicarVelocidad()
	{
		transform.position += new Vector3(velocidad, 0.0f) * Time.deltaTime;
	}
}
