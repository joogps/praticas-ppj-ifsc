using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controle : MonoBehaviour
{

    public int velocidade = 10;
    public int forcaDoPulo = 1250;
    public Transform terra;
    public LayerMask chao;
    public LayerMask plataforma;

    private float moveX;
    private bool direita = true;
    private bool noChao;
    private Animator animator;

    public GameObject bulletPrefab;
    public float bulletVelocity = 5f;
    public int bullets = 15;
    public Text bulletsDisplay;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveJogador();
    }

    private void LateUpdate()
    {
        viraJogador();
    }

    void moveJogador()
    {
        // CONTROLES
        moveX = Input.GetAxis("Horizontal");
        noChao = Physics2D.Linecast(transform.position, terra.position, chao) || Physics2D.Linecast(transform.position, terra.position, plataforma);
        if (Input.GetButtonDown("Fire1"))
        {
            ataca();
        }
        if (Input.GetButtonDown("Jump") && noChao)
        {
            pula();
        }

        // FÍSICA
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * velocidade,
                                                                      gameObject.GetComponent<Rigidbody2D>().velocity.y);

        Physics2D.IgnoreLayerCollision(this.gameObject.layer, LayerMask.NameToLayer("Platform"),
                                       (gameObject.GetComponent<Rigidbody2D>().velocity.y > 0.0f));

        // ANIMAÇAO
        animator.SetBool("NoChao", noChao);

        if (moveX != 0)
        {
            animator.SetBool("Correndo", true);
        }
        else
        {
            animator.SetBool("Correndo", false);
        }
    }

    void ataca(){
        if (Input.GetButtonDown("Fire1") && bullets > 0)
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 sourcePos = transform.position;

            sourcePos.y-= 0.5f;

            Vector2 direction = (Vector2)((worldMousePos - sourcePos));
            direction.Normalize();

            // Creates the bullet locally
            GameObject bullet = (GameObject)Instantiate(
                                    bulletPrefab,
                                    transform.position + (Vector3)(direction * 0.5f),
                                    Quaternion.identity);
            bullet.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);


            // Adds velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;

            bullets--;
            updateText();
        }
    }

    void updateText() {
        bulletsDisplay.text = "x" + bullets;
    }

    void pula(){
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaDoPulo);
        animator.SetTrigger("Pula");
    }

    void viraJogador()
    {
        if (moveX > 0){
            direita = true;
        }
        else if(moveX < 0){
            direita = false;
        }
        Vector2 escala = transform.localScale;
        if((escala.x > 0 && !direita) || (escala.x < 0 && direita)){
            escala.x = escala.x * -1;
            transform.localScale = escala;
        }
    }

    public void reload() {
        bullets = 15;
        updateText();
    }

	// Código da plataforma movel
	void OnCollisionEnter2D(Collision2D outro)
	{
        if(outro.gameObject.tag=="PlataformaMovel"){
            this.transform.parent = outro.transform;
        }
	}

	private void OnCollisionExit2D(Collision2D outro)
	{
        if (outro.gameObject.tag == "PlataformaMovel")
        {
            this.transform.parent = null;
        }
	}
}
