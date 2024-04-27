/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.DeveloperConsole
{

    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "NewConsoleCommand", menuName = "Scriptable Objects/ConsoleCommand")]
    public abstract class ConsoleCommand : ScriptableObject, IConsoleCommand
    {
        [field: SerializeField]
        private string commandWord = string.Empty;

        public string CommandWord => commandWord;

        public abstract bool Process(string[] args);
    }

}