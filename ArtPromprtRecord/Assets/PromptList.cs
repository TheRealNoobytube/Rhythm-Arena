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
        new Prompt { time = 1.487912f, input = "j", rowNum = 0},
new Prompt { time = 3.572102f, input = "k", rowNum = 1},
new Prompt { time = 4.747612f, input = "l", rowNum = 2},
new Prompt { time = 6.979583f, input = "l", rowNum = 2},
new Prompt { time = 6.987212f, input = "j", rowNum = 0},
new Prompt { time = 7.955223f, input = "k", rowNum = 1},
new Prompt { time = 8.859633f, input = "j", rowNum = 0},
new Prompt { time = 8.875508f, input = "l", rowNum = 2},
new Prompt { time = 9.323305f, input = "k", rowNum = 1},
new Prompt { time = 10.14731f, input = "j", rowNum = 0},
new Prompt { time = 11.25101f, input = "k", rowNum = 1},
new Prompt { time = 12.15486f, input = "l", rowNum = 2},
new Prompt { time = 13.42008f, input = "j", rowNum = 0},
new Prompt { time = 13.42008f, input = "l", rowNum = 2},
new Prompt { time = 14.25873f, input = "k", rowNum = 1},
new Prompt { time = 15.0438f, input = "j", rowNum = 0},
new Prompt { time = 15.05128f, input = "l", rowNum = 2},
new Prompt { time = 15.81115f, input = "k", rowNum = 1},
new Prompt { time = 16.68351f, input = "j", rowNum = 0},
new Prompt { time = 17.01914f, input = "k", rowNum = 1},
new Prompt { time = 17.40401f, input = "l", rowNum = 2},
new Prompt { time = 17.80335f, input = "k", rowNum = 1},
new Prompt { time = 18.21972f, input = "j", rowNum = 0},
new Prompt { time = 18.63564f, input = "k", rowNum = 1},
new Prompt { time = 19.08311f, input = "l", rowNum = 2},
new Prompt { time = 19.98755f, input = "j", rowNum = 0},
new Prompt { time = 19.99498f, input = "l", rowNum = 2},
new Prompt { time = 20.8512f, input = "k", rowNum = 1},
new Prompt { time = 21.63496f, input = "j", rowNum = 0},
new Prompt { time = 21.64379f, input = "l", rowNum = 2},
new Prompt { time = 22.41913f, input = "k", rowNum = 1},
new Prompt { time = 23.25155f, input = "j", rowNum = 0},
new Prompt { time = 23.26705f, input = "l", rowNum = 2},
new Prompt { time = 24.02743f, input = "k", rowNum = 1},
new Prompt { time = 24.89153f, input = "j", rowNum = 0},
new Prompt { time = 25.09075f, input = "k", rowNum = 1},
new Prompt { time = 25.30704f, input = "l", rowNum = 2},
new Prompt { time = 25.49874f, input = "k", rowNum = 1},
new Prompt { time = 25.73076f, input = "j", rowNum = 0},
new Prompt { time = 26.57118f, input = "j", rowNum = 0},
new Prompt { time = 26.58755f, input = "k", rowNum = 1},
new Prompt { time = 26.59468f, input = "l", rowNum = 2},
new Prompt { time = 27.4117f, input = "j", rowNum = 0},
new Prompt { time = 27.43632f, input = "k", rowNum = 1},
new Prompt { time = 27.43632f, input = "l", rowNum = 2},
new Prompt { time = 28.28305f, input = "j", rowNum = 0},
new Prompt { time = 28.29111f, input = "k", rowNum = 1},
new Prompt { time = 28.29111f, input = "l", rowNum = 2},
new Prompt { time = 29.94764f, input = "j", rowNum = 0},
new Prompt { time = 29.95462f, input = "k", rowNum = 1},
new Prompt { time = 29.96348f, input = "l", rowNum = 2},
new Prompt { time = 30.72326f, input = "j", rowNum = 0},
new Prompt { time = 30.73915f, input = "k", rowNum = 1},
new Prompt { time = 30.73915f, input = "l", rowNum = 2},
new Prompt { time = 31.50761f, input = "k", rowNum = 1},
new Prompt { time = 33.2588f, input = "j", rowNum = 0},
new Prompt { time = 33.26667f, input = "k", rowNum = 1},
new Prompt { time = 33.27579f, input = "l", rowNum = 2},
new Prompt { time = 34.0836f, input = "j", rowNum = 0},
new Prompt { time = 34.09151f, input = "k", rowNum = 1},
new Prompt { time = 34.09883f, input = "l", rowNum = 2},
new Prompt { time = 34.88346f, input = "j", rowNum = 0},
new Prompt { time = 34.89127f, input = "k", rowNum = 1},
new Prompt { time = 34.89127f, input = "l", rowNum = 2},
new Prompt { time = 35.69876f, input = "j", rowNum = 0},
new Prompt { time = 35.88367f, input = "k", rowNum = 1},
new Prompt { time = 36.11557f, input = "l", rowNum = 2},
new Prompt { time = 36.57899f, input = "l", rowNum = 2},
new Prompt { time = 36.76291f, input = "k", rowNum = 1},
new Prompt { time = 36.94752f, input = "j", rowNum = 0},
new Prompt { time = 37.29881f, input = "l", rowNum = 2},
new Prompt { time = 37.42783f, input = "k", rowNum = 1},
new Prompt { time = 37.54724f, input = "j", rowNum = 0},
new Prompt { time = 37.97905f, input = "l", rowNum = 2},
new Prompt { time = 38.0699f, input = "k", rowNum = 1},
new Prompt { time = 38.18803f, input = "j", rowNum = 0},
new Prompt { time = 39.67491f, input = "j", rowNum = 0},
new Prompt { time = 39.67491f, input = "k", rowNum = 1},
new Prompt { time = 39.67491f, input = "l", rowNum = 2},
new Prompt { time = 41.36349f, input = "k", rowNum = 1},
new Prompt { time = 41.37133f, input = "l", rowNum = 2},
new Prompt { time = 43.08432f, input = "j", rowNum = 0},
new Prompt { time = 44.69078f, input = "k", rowNum = 1},
new Prompt { time = 46.24409f, input = "l", rowNum = 2},
new Prompt { time = 47.96295f, input = "j", rowNum = 0},
new Prompt { time = 49.56339f, input = "j", rowNum = 0},
new Prompt { time = 49.56339f, input = "k", rowNum = 1},
new Prompt { time = 49.57199f, input = "l", rowNum = 2},
new Prompt { time = 51.17213f, input = "k", rowNum = 1},
new Prompt { time = 51.17213f, input = "l", rowNum = 2},
new Prompt { time = 52.84363f, input = "j", rowNum = 0},
new Prompt { time = 52.85139f, input = "k", rowNum = 1},
new Prompt { time = 54.52266f, input = "k", rowNum = 1},
new Prompt { time = 55.69086f, input = "j", rowNum = 0},
new Prompt { time = 55.83525f, input = "k", rowNum = 1},
new Prompt { time = 55.98746f, input = "l", rowNum = 2},
new Prompt { time = 56.19534f, input = "j", rowNum = 0},
new Prompt { time = 56.20346f, input = "k", rowNum = 1},
new Prompt { time = 56.20346f, input = "l", rowNum = 2},
new Prompt { time = 57.83588f, input = "j", rowNum = 0},
new Prompt { time = 57.83588f, input = "k", rowNum = 1},
new Prompt { time = 57.83588f, input = "l", rowNum = 2},
new Prompt { time = 59.49944f, input = "j", rowNum = 0},
new Prompt { time = 59.50727f, input = "k", rowNum = 1},
new Prompt { time = 61.09945f, input = "k", rowNum = 1},
new Prompt { time = 61.10762f, input = "j", rowNum = 0}





        /*
        new Prompt { time = 3.5f, input = "j", rowNum = 0},

        new Prompt { time = 4, input = "j", rowNum = 0},
        new Prompt { time = 4, input = "k", rowNum = 1},
        new Prompt { time = 4, input = "l", rowNum = 2},

        new Prompt { time = 4.4f, input = "j", rowNum = 0},
        new Prompt { time = 4.6f, input = "k", rowNum = 1},
        new Prompt { time = 4.8f, input = "l", rowNum = 2},
        new Prompt { time = 5.2f, input = "j", rowNum = 0},
        new Prompt { time = 5.2f, input = "k", rowNum = 1},
        new Prompt { time = 5.6f, input = "l", rowNum = 2},
        new Prompt { time = 5.8f, input = "j", rowNum = 0},
        new Prompt { time = 5.8f, input = "j", rowNum = 0},

        new Prompt { time = 6, input = "j", rowNum = 0},
        new Prompt { time = 6, input = "k", rowNum = 1},
        new Prompt { time = 6, input = "l", rowNum = 2},
        new Prompt { time = 5.8f, input = "j", rowNum = 0},
        new Prompt { time = 5.8f, input = "j", rowNum = 0},


        new Prompt { time = 10, input = "k", rowNum = 0},
        new Prompt { time = 18, input = "j", rowNum = 0},
        new Prompt { time = 20, input = "k", rowNum = 0}
        */
    };

}
