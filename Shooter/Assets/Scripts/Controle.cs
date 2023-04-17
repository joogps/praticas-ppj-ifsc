using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    public float velocidade = 3.0f;
    public float gravidade = 200.0f;
    private CharacterController controle;

    // Start is called before the first frame update
    void Start()
    {
        controle = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimentoZ = Input.GetAxis("Vertical") * Vector3.forward * velocidade;
        Vector3 movimentoX = Input.GetAxis("Horizontal") * Vector3.right * velocidade;
        Vector3 movimento = transform.TransformDirection(movimentoZ+movimentoX);

        movimento.y -= gravidade * Time.deltaTime;

        controle.Move(movimento * Time.deltaTime);
    }
}
