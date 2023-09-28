using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayAgain()
    {
        gameObject.GetComponent<GameManager>().SetPlayerHealthToDefault();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PlayButton(){
        SceneManager.LoadScene("Level_1");
    }
}
