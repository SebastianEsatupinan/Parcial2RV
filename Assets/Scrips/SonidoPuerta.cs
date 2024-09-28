using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SonidoAmbiente1 : MonoBehaviour
{
    public AudioSource quienEmite;

    public AudioClip elArchivoQueBaje;

    public float volumen;


    private void OnTriggerEnter(Collider other)
    {
        quienEmite.PlayOneShot(elArchivoQueBaje, volumen);
    }


}