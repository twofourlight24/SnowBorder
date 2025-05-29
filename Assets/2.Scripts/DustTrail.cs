using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticleSystem; // ����Ʈ ��ƼŬ �ý���
    [SerializeField] private AudioClip snowSound; // �浹 ����

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
            audioSource.PlayOneShot(snowSound); // �浹 ���� ���
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
