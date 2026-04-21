using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Bala : MonoBehaviour
{
    GameObject Player;

    bool direccionPlayer;

    public GameObject fuegoPadre;

    public float velocidadFuego = 0.5f;

    float nacimiento;

    public float tiempoParaMorir = 1.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Player = GameObject.Find("Player");

        direccionPlayer = Player.GetComponent<Movimiento>().direccionBalaDcha;

        nacimiento = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        if(direccionPlayer)
        {
            fuegoPadre.transform.Translate(velocidadFuego*Time.deltaTime,0,0);
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            fuegoPadre.transform.Translate(-1*velocidadFuego*Time.deltaTime,0,0);
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Time.time >= nacimiento + tiempoParaMorir)
        {
            Destroy(fuegoPadre);
        }

    
        

    }
}
