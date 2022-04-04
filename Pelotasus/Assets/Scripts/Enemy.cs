using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad;
    public float velocidadDeReversa;
    public float distanciaDelJugador;
    public float rangoDeVision;
    public float rangoDeRevarsa;
    public float rangoDeDisparo;
    public Transform player;
    public Rigidbody2D rb2D;
       
    // Update is called once per frame
    void Update()
    {
        distanciaDelJugador = Vector2.Distance(player.position, rb2D.position);
        if(distanciaDelJugador < rangoDeVision && distanciaDelJugador > rangoDeRevarsa && distanciaDelJugador > rangoDeDisparo)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos = Vector2.MoveTowards(rb2D.position, objetivo, velocidad * Time.deltaTime);
            rb2D.MovePosition(nuevaPos);
        }
        else if(distanciaDelJugador < rangoDeVision && distanciaDelJugador > rangoDeRevarsa && distanciaDelJugador <= rangoDeDisparo)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos = Vector2.MoveTowards(rb2D.position, objetivo, 0 * Time.deltaTime);
            rb2D.MovePosition(nuevaPos);
        }
        else if (distanciaDelJugador < rangoDeDisparo)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos = Vector2.MoveTowards(rb2D.position, objetivo, velocidadDeReversa * Time.deltaTime);
            rb2D.MovePosition(nuevaPos);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, rangoDeDisparo);
        Gizmos.DrawWireSphere(transform.position, rangoDeVision);
        Gizmos.DrawWireSphere(transform.position, rangoDeRevarsa);
    }
}
