using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticleSystem; // 더스트 파티클 시스템
    [SerializeField] private AudioClip snowSound; // 충돌 사운드

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            dustParticleSystem.Play();
            audioSource.PlayOneShot(snowSound); // 충돌 사운드 재생
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            dustParticleSystem.Stop();
        }
    }
}
