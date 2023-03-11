using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameDev3.Project
{
    public class DifficultSelect : MonoBehaviour
    {
        public Animator Transition;

        void Start()
        {
            
        }

        public void TransitionIn()
        {
            Transition.SetBool("End", true);
        }

        public void SetPlayerThenMove()
        {
            TransitionIn();
            Invoke("LoadScene", 3f);
        }

        private void LoadScene()
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }

        public void LoadSceneMultiplayer()
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
    }
}