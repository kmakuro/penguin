using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameDev3.Project
{
    public class LevelLoader1 : MonoBehaviour
    {
        public Animator Transition;
        public string levelWin;
        public string levelLose;

        // Update is called once per frame
        /*void Update()
        {
            var player = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
            if (player.currentHealth <= 0)
            {
                TransitionIn(levelLose);
            }

            var World = GameObject.FindWithTag("MainCamera").GetComponent<WorldController>();
            if (World.Statue.Count <= 0)
            {
                TransitionIn(levelWin);
                FindObjectOfType<AudioManager>().Play("GameWin");
            }
            
        }*/

        void TransitionIn(string level)
        {
            
                Transition.SetBool("End", true);
                StartCoroutine(LoadSummaryScene(level));
            
        }

        public IEnumerator LoadSummaryScene(string levelname)
        {
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene(levelname);
        }
    }
}