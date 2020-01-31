using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controlaCadena : MonoBehaviour
{
    public float time;
    private float velocityMultiplier;
    public Letra letra1, letra2, letra3;

    public int vidas;

    private int numeroSecuencias;

    private void Start()
    {
        pasarObjeto();
        vidas = 3;
        numeroSecuencias = 0;
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    //rehacer, que hay cambios de diseño

    private void Update()
    {
        //si el tiempo llega a 0 o si completamos la secuencia
        if (time <= 0 || numeroSecuencias == 0)
        {
            //si se ha acabado el tiempo y no hemos conseguido acabar la secuencia, se pierde una vida
            if(letra1.escrita == false || letra2.escrita == false || letra3.escrita == false) vidas--;

            //para asignar las nuevas letras
            pasarObjeto();

            //asigna el nuevo tiempo
            time = 100 * velocityMultiplier;

            //asignar el nuevo numero de secuencias a hacer
            numeroSecuencias = 1 * 1;

        }

        //si completamos la actual secuencia
        if(SecuenciaCompletada() == true)
        {
            numeroSecuencias++;
        }

        LetraEscrita();
    }

    private void pasarObjeto()
    {
        
        //asigna las nuevas letras
        letra1.AsignarLetra();
        letra2.AsignarLetra();
        letra3.AsignarLetra();
    }

    private bool SecuenciaCompletada()
    {
        //detecta si todas estan escritas o no
        if(letra1.escrita == true && letra2.escrita == true && letra3.escrita == true) return true;
        else return false;
    }


    
    private void LetraEscrita()
    {
        //para detectar la letra escrita (si la hay)
        string letraEscrita;
        if (Input.anyKeyDown)
        {
            letraEscrita = Input.inputString;

            //compara la letra escrita con la letra actual. Si la uno no se ha escrito la compara, sino compara la segunda, sino la tercera
            if(letra1.escrita == false)
            {
                if ((letraEscrita[0]) == letra1.letra)
                {
                    letra1.escrita = true;
                }
                //si fallas, pierdes vida y se resetea la secuencia actual
                else
                {
                    vidas--;
                }
            }
            else if(letra2.escrita == false)
            {
                if ((letraEscrita[0]) == letra2.letra)
                {
                    letra2.escrita = true;
                }
                else
                {
                    vidas--;
                    letra1.escrita = false;
                }
            }
            else
            {
                if ((letraEscrita[0]) == letra3.letra)
                {
                    letra3.escrita = true;
                }
                else
                {
                    vidas--;
                    letra1.escrita = false;
                    letra2.escrita = false;
                }
            }
        }
        
    }
}
