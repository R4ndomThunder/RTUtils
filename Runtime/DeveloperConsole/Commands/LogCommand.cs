/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.DeveloperConsole
{
    [CreateAssetMenu(fileName = "New Log Command", menuName = "Scriptable Objects/Command/LogCommand")]
    public class LogCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            string logText = string.Join(" ", args);
            Debug.Log(logText);

            return true;
        }
    }

}