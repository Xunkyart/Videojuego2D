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


    private void DoubleJump()
    {
        Player.GetComponent<Movimiento>().DoubleJump();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            estoyEnOrbe = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            estoyEnOrbe = false;
        }
    }

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