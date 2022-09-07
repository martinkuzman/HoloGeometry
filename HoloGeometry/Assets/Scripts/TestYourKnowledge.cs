using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace UI 
{
    public class TestYourKnowledge : MonoBehaviour
    {

        private bool click = false;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void play()
        {
            Quiz.questionId = 0;
            Quiz.correct_count = 0;
            Quiz.wrong_count = 0;

            System.Random random = new System.Random();
            var numbers = Enumerable.Range(0, Quiz.number_of_questions);
            Quiz.shuffle = numbers.OrderBy(a => random.NextDouble()).ToArray();
        }
    }

}
