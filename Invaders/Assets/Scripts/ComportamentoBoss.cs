using UnityEngine;
using System.Collections;

public class ComportamentoBoss : MonoBehaviour
{

	public int lives = 3;

	// explode quando atingido?
	public GameObject prefabExplosao;

	private float destroyTime;

	// quando colidir com outro gameObject...
	void OnCollisionEnter (Collision newCollision)
	{
		// Se foi atingido por um projétil...
		if (newCollision.gameObject.tag == "Projetil") {
			Destroy (newCollision.gameObject);

			if (lives > 0) {
				lives -= 1;
				gameObject.transform.localScale -= new Vector3(0.15f, 0.15f, 0.1f);
			} else {
				Destroy (newCollision.gameObject);
				Destroy (gameObject);

				if (prefabExplosao) {
					// Instancia a explosão na posição e rotação do alvo
					Instantiate (prefabExplosao, transform.position, transform.rotation);
				}
				
				GameManager.gm.gameIsOver = true;
				GameManager.gm.BeatLevel();
			}
		}
	}

	public void AlertObservers(string message)
    {
        if (message.Equals("AnimationEnded"))
        {
			Destroy (gameObject);
        }
    }
}
