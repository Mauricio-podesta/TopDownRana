using UnityEngine;


public class Moneda : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Jugador")
		{
			Destroy(gameObject);
		}
	}
}
