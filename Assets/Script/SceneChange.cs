using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement; 

public class SceneChange : MonoBehaviour
{
     public void LevelUi() {  
        SceneManager.LoadScene("LevelUi");  
    }  
    public void Level1() {  
        SceneManager.LoadScene("Level1");  
    }
    public void Level2() {  
        SceneManager.LoadScene("Level2");  
    }  
    public void Level3() {  
        SceneManager.LoadScene("Level3");  
    } 
    
}
