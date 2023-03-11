using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameDev3.Project
{
    public class LevelLoader2 : MonoBehaviour
    {
        public Animator Transition;
        public int IndexSceneID;

        // Update is called once per frame
        void Update()
        {
            TransitionIn();
        }

        void TransitionIn()
        {
            
                Transition.SetBool("End", true);
                StartCoroutine(LoadSummaryScene());
            
        }

        public IEnumerator LoadSummaryScene()
        {
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene(IndexSceneID);
        }
    }
}