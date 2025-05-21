using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    void OnTriggerEnter2D(Collider2D other)
    {
        var shapeModule = ParticleSystem.shape;

        if (other.CompareTag("Player"))
        {
            ParticleSystem.Play();
            Debug.Log("완주했습니다");
            SceneManager.LoadScene(0);
        }
    }
}
