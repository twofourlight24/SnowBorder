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
            Debug.Log("�����߽��ϴ�");
            SceneManager.LoadScene(0);
        }
    }
}
