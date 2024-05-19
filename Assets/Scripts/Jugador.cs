using UnityEngine;


public class Jugador : Personaje
{
    [SerializeField] int vidaMaxima = 100;
    [SerializeField] int vida = 100;

    [SerializeField] int puntaje = 0;

    [SerializeField] float velocidadX = 0.0f;
    [SerializeField] float fuerzaDeSalto = 0.0f;

    [SerializeField] CanvasManager referenciaAlCanvas = null;


    Rigidbody2D rigidbody = null;

    bool estaEnElPiso = true;



	void Awake()
	{
        rigidbody = GetComponent<Rigidbody2D>();

        MostrarPresentacionEnConsola();
        RestablecerVida();
        RestablecerPuntos();
    }

	void Update()
    {
        if (SePresionoElBotonParaSaltar())
		{
            // Salta.
            if (estaEnElPiso == true)
			{
                estaEnElPiso = false;

                Saltar();
            }
		}

        MoverHorizontalmente();
        FuncionParaProbarRapidamente();

        if (SiSeQuedoSinVida())
		{
            gameObject.SetActive(false);
		}
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Piso")
        {
            estaEnElPiso = true;
        }

        if (collision.gameObject.tag == "Enemigo")
		{
            // Le saca vida.
            RestarVida(20);
		}

        if (collision.gameObject.tag == "Moneda")
		{
            SumarPuntos(10);
		}
    }

	void OnCollisionExit2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Piso")
        {
            estaEnElPiso = false;
        }
    }



	public override void MostrarPresentacionEnConsola()
	{
        Debug.Log("Nombre del jugador: " + nombre + ".");
	}

    bool SePresionoElBotonParaSaltar()
	{
        bool sePresiono = false;

        if (Input.GetButtonDown("Jump"))
		{
            sePresiono = true;
		}

        return sePresiono;
	}
    bool SiSeQuedoSinVida()
	{
        bool sinVida = false;

        if (vida <= 0)
		{
            sinVida = true;
		}

        return sinVida;
	}

    void MoverHorizontalmente()
	{
        // Obtiene unvalor con float.
        float inputHorizontal = Input.GetAxis("Horizontal");


        transform.position += new Vector3(inputHorizontal * velocidadX * Time.deltaTime, 0.0f);
    }
    void Saltar()
	{
        rigidbody.AddForce(transform.up * fuerzaDeSalto);
    }


	void RestarVida(int danio)
	{
        // Si la vida es mayor al daño que recibe...
        if (vida > danio)
		{
            vida -= danio; // Recibe el dano
		}
        else // Caso contrario...
		{
            vida = 0; // Se establece a 0 (para que no se convierta en un valor negativo).
		}

        referenciaAlCanvas.ActualizarVida(vida);
	}
    void SumarVida(int vidaExtra)
	{
        // Si tras sumar la vida supera el límite máximo...
        if (vida + vidaExtra > vidaMaxima)
		{
            vida = vidaMaxima; // Se establece el límite máximo.
		}
        else // Caso contrario...
		{
            vida += vidaExtra; // Se incrementa directamente.
		}

        referenciaAlCanvas.ActualizarVida(vida);
    }

    void RestablecerVida()
	{
        vida = vidaMaxima;

        referenciaAlCanvas.ActualizarVida(vida);
    }

    void SumarPuntos(int puntos)
	{
        puntaje += puntos;

        if (puntaje > 9999)
		{
            puntaje = 9999;
		}

        referenciaAlCanvas.ActualizarPuntaje(puntaje);
	}
    void RestablecerPuntos()
	{
        puntaje = 0;

        referenciaAlCanvas.ActualizarPuntaje(puntaje);
    }


    void FuncionParaProbarRapidamente()
	{
        if (Input.GetKeyDown(KeyCode.A))
        {
            SumarVida(15);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            RestarVida(15);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestablecerVida();
        }
    }
}
