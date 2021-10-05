using UnityEngine;
using UnityEngine.SceneManagement;

namespace DungeonKIT
{
    public class GameEndManager : MonoBehaviour
    {
        private void Start()
        {
            GameEndScene(); //Call load scene method when GameEndScene is loaded

        }


        //GameEnd scene method
        void GameEndScene()
        {
            SceneManager.LoadScene(ScenesManager.Instance.sceneToLoad); //Get scene name from SceneManager.sceneToLoad

        }
    }
}