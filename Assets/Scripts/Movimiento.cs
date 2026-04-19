using UnityEngine;
using UnityEngine.InputSystem;
public class Movimiento : MonoBehaviour
{
    float mov2D;
    public float velocidadCorrer =10f;

    public float impulsoSalto = 5f;

    bool estoySaltando = false;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        // MOV HORIZONTAL

        mov2D = InputSystem.actions["Move"].ReadValue<Vector2>().x;
        rb.linearVelocity = new Vector2 (mov2D*velocidadCorrer, rb.linearVelocity.y);

        if (mov2D > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (mov2D < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        
        // SALTO
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.49f);

        if (hit)
        {
            estoySaltando = false;
        }
        else
        {
            estoySaltando = true;
        }



        if (InputSystem.actions["Jump"].ReadValue<float>() == 1.0f && estoySaltando == false)
        {
           rb.linearVelocity = new Vector2 (rb.linearVelocity.x, impulsoSalto);
        }
        


        //AddForceY(float force, ForceMode2D mode = ForceMode2D.Impulse);



    }
}
