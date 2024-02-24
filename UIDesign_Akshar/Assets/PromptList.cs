using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptList : MonoBehaviour
{
    public struct Prompt
    {
        public float time;
        public string input;
        public int rowNum;

    }

    public static Prompt[] prompts =
    {
        new Prompt { time = 4, input = "j", rowNum = 0},
        new Prompt { time = 4, input = "k", rowNum = 1},
        new Prompt { time = 4, input = "l", rowNum = 2},


        new Prompt { time = 10, input = "k", rowNum = 0},
        new Prompt { time = 18, input = "j", rowNum = 0},
        new Prompt { time = 20, input = "k", rowNum = 0},
    };

}
