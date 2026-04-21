using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
public class ArmaScript : MonoBehaviour
{
    public GameObject fuego;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool disparoFuego = InputSystem.actions["Magic"].WasPressedThisFrame();

      if(disparoFuego)
      {
       Instantiate (fuego, transform.position, Quaternion.identity);
      }
    }
}
