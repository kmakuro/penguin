using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace GameDev3.Project
{
    public class GameAppFlowManager : MonoBehaviour
    {
        protected static bool IsSceneOptionsLoaded;

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        
        public void LoadSceneLevel1(Animator transition)
        {
            transition.SetBool("End", true);
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
        public void LoadSceneLevel2(Animator transition)
        {
            transition.SetBool("End", true);
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        public void LoadSceneLevel3(Animator transition)
        {
            transition.SetBool("End", true);
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }
        public void LoadSceneLevel4(Animator transition)
        {
            transition.SetBool("End", true);
            SceneManager.LoadScene("Level4", LoadSceneMode.Single);
        }

        public void LoadMainMenu(Animator transition)
        {
            transition.SetBool("End", true);
            Invoke("LoadSceneMenu", 3f);
        }

        public void LoadSceneStartGame(Animator transition)
        {
            SceneManager.LoadScene("LevelDifficultSelect", LoadSceneMode.Single);
        }

        public void BackToMenu(Animator transition)
        {
            transition.SetBool("End", true);
            Invoke("LoadSceneMenu", 2f);
        }

        private void LoadSceneStartDelay()
        {
            SceneManager.LoadScene(Score._LevelCurrent, LoadSceneMode.Single);
        }

        private void LoadSceneMenu()
        {
            PauseMenu.GameIsPaused = false;
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }

        public void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        public void UnloadPauseScene(string sceneName)
        {
            Time.timeScale = 1f;
            PauseMenu.GameIsPaused = false;
            SceneManager.UnloadSceneAsync(sceneName);
        }

        public void LoadSceneAdditive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        public void LoadOptionsScene(string optionSceneName)
        {
            if (!IsSceneOptionsLoaded)
            {
                SceneManager.LoadScene(optionSceneName, LoadSceneMode.Additive);
                IsSceneOptionsLoaded = true;
            }
        }

        public void UnloadOptionsScene(string optionSceneName)
        {
            if (IsSceneOptionsLoaded)
            {
                SceneManager.UnloadSceneAsync(optionSceneName);
                IsSceneOptionsLoaded = false;
            }
        }

        public void ExitGame()
        {
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }

        public void TryAgain()
        {
            Scene currentScene = SceneManager.GetActiveScene();

            string sceneName = currentScene.name;

            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }



        #region Scene Load and Unload Events Handler
        private void OnEnable()
        {
            SceneManager.sceneUnloaded += SceneUnloadEventHandler;
            SceneManager.sceneLoaded += SceneLoadedEventHandler;
        }

        private void OnDisable()
        {
            SceneManager.sceneUnloaded -= SceneUnloadEventHandler;
            SceneManager.sceneLoaded -= SceneLoadedEventHandler;
        }

        private void SceneUnloadEventHandler(Scene scene)
        {

        }
        private void SceneLoadedEventHandler(Scene scene, LoadSceneMode mode)
        {
            //If the loaded scene is not the SceneOptions, set flag IsOptionsLoaded to
            //false
            if (scene.name.CompareTo("Options") != 0)
            {
                IsSceneOptionsLoaded = false;
            }
        }
    }
    #endregion
}