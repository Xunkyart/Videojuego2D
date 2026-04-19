using UnityEngine;
using UnityEngine.InputSystem;
public class Movimiento : MonoBehaviour
{
    float mov2D;
    public float velocidad =10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mov2D = InputSystem.actions["Move"].ReadValue<Vector2>().x;
        
        //DeltaTime hace que el movimiento sea consistente aunque tengamos variaciones en los FPS
        transform.Translate(mov2D*velocidad*Time.deltaTime, 0, 0);
    }
}
