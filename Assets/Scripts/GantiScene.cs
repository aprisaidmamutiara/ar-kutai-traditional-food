using UnityEngine;
using UnityEngine.SceneManagement;

public class GantiScene : MonoBehaviour
{
    public void PindahScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }
}
