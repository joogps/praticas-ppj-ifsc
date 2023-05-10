using UnityEngine;
using System.Collections;

public class ComportamentoAlvo : MonoBehaviour
{

	// impacto do alvo no jogo
	public int pontuacao = 0;
	public float tempoExtra = 0.0f;

	// explode quando atingido?
	public GameObject prefabExplosao;

	private float destroyTime;

	// quando colidir com outro gameObject...
	void OnCollisionEnter (Collision newCollision)
	{
		// Se foi atingido por um projétil...
		if (newCollision.gameObject.tag == "Projetil") {
			if (prefabExplosao) {
				// Instancia a explosão na posição e rotação do alvo
				Instantiate (prefabExplosao, transform.position, transform.rotation);
			}

			Destroy (newCollision.gameObject);
			Destroy (gameObject);

			// se o game manager existir, altere o tempo e placar conforme o alvo
			if (GameManager.gm) {
				if (!GameManager.gm.gameIsOver)
					GameManager.gm.targetHit (pontuacao, tempoExtra);
			}
		}
	}
}
