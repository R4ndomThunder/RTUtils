/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;

namespace RTDK.DeveloperConsole
{
    public interface IConsoleCommand
    {
        string CommandWord { get; }
        bool Process(string[] args);
    }

}