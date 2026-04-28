using UnityEngine;

public class MojitoScript : MonoBehaviour
{
    public int curacion = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
        {
        if(col.name == "Player")
            {
                GameManager.vidas += curacion;
                Destroy(this.gameObject);
            }
        }
}
