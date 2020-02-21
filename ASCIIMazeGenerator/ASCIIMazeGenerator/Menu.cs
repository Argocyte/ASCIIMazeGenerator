using System;
using System.IO;
using Sharprompt;
using Newtonsoft.Json;

namespace ASCIIMazeGenerator
{
    class Menu
    {
        public Menu()
        {
            bool _continue = true;
            while (_continue)
            {
                switch (Prompt.Select(MenuPrompt.SELECT_OPTION,
                    new[] {
                        MenuOption.GENERATE_DEFAULT,
                        MenuOption.GENERATE_CUSTOM,
                        MenuOption.OPEN_FROM_FILE,
                        MenuOption.EXIT_PROGRAM
                    }))
                {
                    case MenuOption.GENERATE_DEFAULT:
                        Generate(Default.MAZE_WIDTH,
                            Default.MAZE_HEIGHT);
                        break;
                    case MenuOption.GENERATE_CUSTOM:
                        Generate(Prompt.Input<int>(MenuPrompt.INPUT_MAZE_WIDTH),
                            Prompt.Input<int>(MenuPrompt.INPUT_MAZE_HEIGHT));
                        break;
                    case MenuOption.OPEN_FROM_FILE:
                        Open();
                        break;
                    case MenuOption.EXIT_PROGRAM:
                        _continue = false;
                        break;
                }
            }
        }
        /// <summary>
        /// Generates the maze, then sends that maze to Loaded()
        /// </summary>
        /// <param name="width">width of the maze</param>
        /// <param name="height">height of the maze</param>
        private void Generate(int width, int height)
        {
            Console.WriteLine(Progress.GENERATE, 
                width, height);
            try
            {
                Maze maze = new Maze(width, height);
                Console.WriteLine(Progress.SUCCESS_GENERATE, 
                    width, height);
                Loaded(maze);
            }
            catch (Exception)
            {
                Console.WriteLine(Error.MAZE_TOO_BIG + Environment.NewLine);
            }
        }
        /// <summary>
        /// opens a maze json file, then sends that maze to Loaded()
        /// </summary>
        private void Open()
        {
            if (Directory.GetFiles(Default.MZE_FILE_FOLDER, 
                Default.WILDCARD + Default.MZE_FILE_EXTENSION).Length>0)
            {
                var fileName = Prompt.Select(MenuPrompt.SELECT_OPTION,
                    Directory.GetFiles(Default.MZE_FILE_FOLDER, 
                    Default.WILDCARD + Default.MZE_FILE_EXTENSION));
                using StreamReader file = File.OpenText(fileName);
                JsonSerializer serializer = new JsonSerializer();
                Maze maze = (Maze)serializer.Deserialize(file, typeof(Maze));
                file.Close();
                Console.WriteLine(Progress.SUCCESS_OPEN + Environment.NewLine, 
                    Default.MZE_FILE_FOLDER + fileName + Default.MZE_FILE_EXTENSION);
                Loaded(maze);
            }
            else
            {
                Console.WriteLine(Error.NO_MAZES_SAVED + Environment.NewLine);
                switch (Prompt.Select(MenuPrompt.SELECT_OPTION,
                    new[] {
                        MenuOption.RETURN
                    }))
                {
                    case MenuOption.RETURN:
                        break;
                }
            }
        }
        /// <summary>
        /// Displays the maze, then asks what the user wants to do next
        /// </summary>
        /// <param name="maze">A ready made maze</param>
        private void Loaded(Maze maze)
        {
            Console.WriteLine(Environment.NewLine + maze.Display() + Environment.NewLine);
            switch (
                Prompt.Select(MenuPrompt.SELECT_OPTION,
                new[] {
                    MenuOption.SAVE_TO_FILE,
                    MenuOption.OUTPUT_TO_TXT,
                    MenuOption.GENERATE_NEW,
                    MenuOption.RETURN
                }))
            {
                case MenuOption.SAVE_TO_FILE:
                    SaveToFile(maze);
                    Loaded(maze);
                    break;
                case MenuOption.OUTPUT_TO_TXT:
                    OutputToFile(maze);
                    Loaded(maze);
                    break;
                case MenuOption.GENERATE_NEW:
                    Generate(maze.Width, maze.Height);
                    break;
                case MenuOption.RETURN:
                    break;
            }
        }
        /// <summary>
        /// Saves the maze to a json file
        /// </summary>
        /// <param name="maze">A ready made maze</param>
        private void SaveToFile(Maze maze)
        {
            var inputFileName = Prompt.Input<string>(MenuPrompt.SAVE_INPUT_FILE_NAME);
            if (inputFileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                Console.WriteLine(Error.INVALID_FILE_NAME + Environment.NewLine, 
                    inputFileName);
                if (!Prompt.Confirm(MenuConfirm.ENTER_AGAIN))
                {
                    OutputToFile(maze);
                    return;
                }
                else return;
            }
            if (!inputFileName.Contains(Default.MZE_FILE_EXTENSION))//Add the .mze eztension if not present.
            {
                inputFileName += Default.MZE_FILE_EXTENSION;
            }
            if (File.Exists(Default.MZE_FILE_FOLDER + inputFileName))//Checks if file already exists.
            {
                Console.WriteLine(Error.SAVE_FILE_EXISTS + Environment.NewLine, 
                    inputFileName);
                if (!Prompt.Confirm(MenuConfirm.OVERWRITE))
                {
                    SaveToFile(maze);
                    return;
                }
                File.Delete(Default.MZE_FILE_FOLDER + inputFileName);
            }
            Console.WriteLine(Progress.SAVE,
                Default.MZE_FILE_FOLDER + inputFileName);
            using StreamWriter file = File.CreateText(Default.MZE_FILE_FOLDER + inputFileName);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, maze);
            Console.WriteLine(Progress.SUCCESS_SAVE + Environment.NewLine,
                Default.MZE_FILE_FOLDER + inputFileName);
            file.Close();
        }
        /// <summary>
        /// Outputs the maze to a text file
        /// </summary>
        /// <param name="maze">A ready made maze</param>
        private void OutputToFile(Maze maze)
        {
            var inputFileName = Prompt.Input<string>(MenuPrompt.SAVE_INPUT_FILE_NAME);
            if (inputFileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                Console.WriteLine(Error.INVALID_FILE_NAME + Environment.NewLine, 
                    inputFileName);
                if (!Prompt.Confirm(MenuConfirm.ENTER_AGAIN))
                {
                    OutputToFile(maze);
                    return;
                }
                else return;
            }
            if (!inputFileName.Contains(Default.TXT_FILE_EXTENSION))//Add the .mze eztension if not present.
            {
                inputFileName += Default.TXT_FILE_EXTENSION;
            }
            string fileNameLocation = Default.TXT_FILE_FOLDER + inputFileName;//puts the file in the default folder
            if (File.Exists(fileNameLocation))//Checks if file already exists.
            {
                Console.WriteLine(Error.SAVE_FILE_EXISTS + Environment.NewLine,
                    Default.TXT_FILE_FOLDER + inputFileName);
                if (!Prompt.Confirm(MenuConfirm.OVERWRITE))
                {
                    OutputToFile(maze);
                    return;
                }
                File.Delete(Default.TXT_FILE_FOLDER + fileNameLocation);
            }
            Console.WriteLine(Progress.SAVE + Environment.NewLine, 
                fileNameLocation);
            using StreamWriter file = File.CreateText(fileNameLocation);
            file.WriteLine(maze.Display());
            Console.WriteLine(Progress.SUCCESS_SAVE + Environment.NewLine,
                Default.TXT_FILE_FOLDER + inputFileName);
            file.Close();
        }
    }
}
