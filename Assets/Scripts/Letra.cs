using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;

public class Letra : MonoBehaviour
{
    public char letra;
    public bool escrita;

    private string st = "wasd";

    public void AsignarLetra()
    {
        letra = st[Random.Range(0, st.Length)];
        this.GetComponent<TMP_Text>().text = letra.ToString();
        escrita = false;
    }

    public void Actual()
    {
        //cambiar imagen
    }
    public void Pulsada()
    {
        //cambiar imagen
        escrita = true;
    }
    public void Despulsar()
    {
        //cambiar imagen
        escrita = false;

    }
}
