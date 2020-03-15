using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopoPatrol : MonoBehaviour
{
   
    public Transform referencia;
    public Vector2 direccion = new Vector2(1f, 0);
    public float rango = 2f;
    public float velocidad = 1f;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(referencia.position, direccion, rango);
        Debug.DrawLine(referencia.position, direccion * rango, Color.green);
        if (hit == true)
        {
            if (hit.collider.CompareTag("Limite"))
            {
                Vector3 escala = transform.localScale;
                escala.x *= -1f;
                transform.localScale = escala;

                velocidad *= -1f;
                direccion *= -1f;
            }
            if (hit.collider.CompareTag("MC"))
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                Vector3 escala = transform.localScale;

                if (escala.x >= 0f)
                {
                    this.GetComponent<TopoPatrol>().velocidad = 3.5f;
                }
                else if (escala.x <= 0f)
                {
                    this.GetComponent<TopoPatrol>().velocidad = -3.5f;
                }
            }

            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.white;
                Vector3 escala = transform.localScale;
                if (escala.x >= 0f)
                {
                    this.GetComponent<TopoPatrol>().velocidad = 1f;
                }
                else if (escala.x <= 0f)
                {
                    this.GetComponent<TopoPatrol>().velocidad = -1f;
                }
            }

        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(velocidad, rb2d.velocity.y);
    }
}


