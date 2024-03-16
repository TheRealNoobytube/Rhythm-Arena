using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class PromptRecorder : MonoBehaviour
{
    List<string> lines = new List<string>();

    float timePassed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.J)) 
        {
            lines.Add("new Prompt { time = " + timePassed + "f, input = \"j\", rowNum = 0},");
            
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            lines.Add("new Prompt { time = " + timePassed + "f, input = \"k\", rowNum = 1},");
           ;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            lines.Add("new Prompt { time = " + timePassed + "f, input = \"l\", rowNum = 2},");
           
        }




        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            lines[lines.Count - 1] = lines[lines.Count - 1].Substring(0, lines[lines.Count - 1].Length - 1);
            SaveTextFile(lines.ToArray());
        }
    }

    

    void SaveTextFile(string[] lines)
    {
        
        // Set a variable to the Documents path.
        string docPath =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Write the string array to a new file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
        {
            foreach (string line in lines)
                outputFile.WriteLine(line);
        }
    }
}
