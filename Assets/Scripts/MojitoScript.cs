using UnityEngine;

public class MojitoScript : MonoBehaviour
{
    public int curacion = 2;
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
                AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.clipMojito);
                GameManager.vidas += curacion;
                Destroy(this.gameObject);
            }
        }
}
