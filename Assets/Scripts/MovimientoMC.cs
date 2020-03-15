using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMC : MonoBehaviour
{
    public float velocidad = 5f;
    private float movimiento;
    private Rigidbody2D rb;
    public Animator anim;

    public GameObject hoyo;
    public GameObject vida;
    public GameObject inicio;
    public Transform referencia;
    public Vector2 direccion = new Vector2(0, 0);
    public float rango = 2f;
    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("PowerUp", true);
           
        }
        else
        {
            anim.SetBool("PowerUp", false);
        }

        RaycastHit2D hit = Physics2D.Raycast(referencia.position,transform.TransformDirection(Vector3.left), rango);
        Debug.DrawLine(referencia.position, transform.TransformDirection(Vector3.forward) * rango, Color.green);
        if (hit == true)
        {
            if (hit.collider.CompareTag("Topo"))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(hit.collider.gameObject);
                }
              
            }
            

        }
    }

    private void FixedUpdate()
    {

        anim.SetFloat("Movimiento", Mathf.Abs(movimiento));
        movimiento = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movimiento * velocidad, rb.velocity.y);

        cambioLado();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Saltar();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            hoyo.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    void Saltar()
    {
        //si salta hacia arriba su velocidad es positiva y hacia abajo es negativa
        if (rb && Mathf.Abs(rb.velocity.y) < 0.10f)
        {
            //impulse hace que use toda la fuerza
            rb.AddForce(new Vector2(0f, 9f), ForceMode2D.Impulse);
        }
    }

    //se cambiara el lado del sprite cuando se oprime la flecha derecha o izquiera
    void cambioLado()
    {
       
        Vector3 escala = transform.localScale;
        
        if (Input.GetAxis("Horizontal") < 0)
        {
            escala.x = -0.2f;
            
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            escala.x = 0.2f;
            
        }

        transform.localScale = escala;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
           
                transform.position = inicio.transform.position;
                vida.GetComponent<Vida>().vida -= 1;
           
        }

        if (collision.CompareTag("Topo"))
        {
            
            
                transform.position = inicio.transform.position;
                vida.GetComponent<Vida>().vida -= 1;
        }

        if (collision.CompareTag("Corazon"))
        {
            Destroy(collision.gameObject);
            vida.GetComponent<Vida>().vida += 1;

        }

        
    }

   


}
