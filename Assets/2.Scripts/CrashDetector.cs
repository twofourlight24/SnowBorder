using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    public ParticleSystem CrashEffect;
    public float reloadDelay = 2f; // ����� ���� �ð�
    [SerializeField] private AudioClip crashSound; // �浹 ����


    private AudioSource audioSource;
    private PlayerController playerController;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            CrashEffect.Play();
            audioSource.PlayOneShot(crashSound); // �浹 ���� ���
            playerController.GameOver(); // ���� ���� ó��
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

