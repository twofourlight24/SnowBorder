using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    public ParticleSystem CrashEffect;
    public float reloadDelay = 2f; // 재시작 지연 시간
    [SerializeField] private AudioClip crashSound; // 충돌 사운드


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
            audioSource.PlayOneShot(crashSound); // 충돌 사운드 재생
            playerController.GameOver(); // 게임 오버 처리
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

