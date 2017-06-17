using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadLevel(string Level)
    {
        SceneManager.LoadScene(Level);
    }
}
