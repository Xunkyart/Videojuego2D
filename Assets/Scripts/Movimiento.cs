using UnityEngine;
using UnityEngine.InputSystem;
public class Movimiento : MonoBehaviour
{
    float mov2D;
    public float velocidadCorrer =10f;

    public float impulsoSalto = 5f;

    public  bool estoySaltando = false;

    Rigidbody2D rb;

    Animator animatorController;

    GameObject respawn;

    public bool direccionFuegoDcha = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animatorController = this.GetComponent<Animator>();

        respawn = GameObject.Find("Respawn");

        Respawnear();
        
    }

    // Update is called once per frame
    void Update()
    {
        // MOV HORIZONTAL

        mov2D = InputSystem.actions["Move"].ReadValue<Vector2>().x;
        rb.linearVelocity = new Vector2 (mov2D*velocidadCorrer, rb.linearVelocity.y);

        //Derecha
        if (mov2D > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            this.GetComponent<CapsuleCollider2D>().offset = new Vector2 (-0.25f, -0.055f);
            animatorController.SetBool("activaRun", true);
            direccionFuegoDcha = true;
        }
        //Izquierda
        else if (mov2D < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            this.GetComponent<CapsuleCollider2D>().offset = new Vector2 (0.23f, -0.055f);
            animatorController.SetBool("activaRun", true);
            direccionFuegoDcha = false;
        }
        //Quieto
        else
        {
            animatorController.SetBool("activaRun", false);
        }
        
        // SALTO

        //Compruebo si puedo saltar
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.49f);


        if (hit && hit.collider.name == "Ground")
        {
            estoySaltando = false;
            animatorController.SetBool("activaSalto", false);
        }
        
        else
        {
            estoySaltando = true;
            animatorController.SetBool("activaSalto", true);
        }

        //Input de salto, activa y define el salto


        if (InputSystem.actions["Jump"].WasPressedThisFrame() && !estoySaltando)
        {
            Jump();
        }
       

        //RESPAWN TRAS CAIDA

        if(transform.position.y <= -20)
        {
            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.clipMuerte);
            Respawnear();
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2 (rb.linearVelocity.x, impulsoSalto);
    }

    public void DoubleJump()
    {
        rb.linearVelocity = new Vector2 (rb.linearVelocity.x, impulsoSalto);
    }

    //MÉTODO PARA RESPAWNEAR
    public void Respawnear(){
        transform.position = respawn.transform.position;
        
        GameManager.vidas = GameManager.vidas - 1;
    }

}
