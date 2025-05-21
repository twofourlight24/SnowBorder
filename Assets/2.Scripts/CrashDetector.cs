using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("���̰� �� �밡�� ���󰡰ڳ�");
            SceneManager.LoadScene(0);
        }
    }
}
