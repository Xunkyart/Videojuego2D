using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class DobleSalto : MonoBehaviour
{
    GameObject Player;

    private bool estoyEnOrbe;

    public float tiempoRecarga = 3.0f;

    private bool recargando = false;

    Animator SaltoDobleAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");

        SaltoDobleAnimator = this.GetComponent<Animator>();
    }

//Se llama al método del script del Player que ejecuta el doble salto.
    private void DoubleJump()
    {
        Player.GetComponent<Movimiento>().DoubleJump();
    }
//Detecta si el Player está dentro del orbe para activar la posibilidad de ejecutar el doble salto.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            estoyEnOrbe = true;
        }
    }
//Detecta si el Player sale del orbe para desactivar la posibilidad de ejecutar el doble salto.
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            estoyEnOrbe = false;
        }
    }
//Si el player pulsa el botón de slato, está dentro de el orbe y el orbe no está recargando, ejectuta el método de salto
//Si se ejecuta el salto, se inicia la recarga del orbe
    private void Update()
    {
        if (InputSystem.actions["Jump"].WasPressedThisFrame() && estoyEnOrbe && !recargando)
        {
            DoubleJump();
            recargando = true;
            SaltoDobleAnimator.SetBool("Gastado",true);
            StartCoroutine(IniciarTemporizador());
        }
    }
//Corrutina, temporizador de la recarga del orbe tras usarlo
    private IEnumerator IniciarTemporizador(){
        yield return new WaitForSeconds(3.0f);
        recargando = false;
        SaltoDobleAnimator.SetBool("Gastado",false);
    }



   















    // Update is called once per frame
    /*private void Update()
    {
        heUsadoDobleSalto = Player.GetComponent<Movimiento>().heUsadoDobleSalto;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player" && recargando == false)
        {
            Debug.Log("Salto Doble Activado");
            permiteSaltoDoble = true;
            if (heUsadoDobleSalto)
            {
                heUsadoDobleSalto = false;
                SaltoDobleAnimator.SetBool("Gastado",true);
                recargando = true;
                StartCoroutine(IniciarTemporizador());
            }
        }
    }

    void OnTriggerExit2D()
    {
        Debug.Log("Salto Doble Desactivado");
        permiteSaltoDoble = false;
    }
    
    IEnumerator IniciarTemporizador(){
        yield return new WaitForSeconds(tiempoRecarga);
        recargando = false;
        SaltoDobleAnimator.SetBool("Gastado",false);
    }*/





    
}