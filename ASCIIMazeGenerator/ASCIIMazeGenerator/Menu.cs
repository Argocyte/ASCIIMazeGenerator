using System;
using System.Collections.Generic;
using System.Text;
using Sharprompt;
using Newtonsoft.Json;
using System.IO;

namespace ASCIIMazeGenerator
{
    /// <summary>
    /// Dsiplays the menu and handles the menu logic
    /// </summary>
    class Menu
    {
        /// <summary>
        /// initialises the menu
        /// </summary>
        public Menu()
        {
            bool _continue = true;
            while (_continue)
            {
                switch (Prompt.Select(MenuText.SELECT_OPTION,
                    new[] {
                        MenuText.OPTION_GENERATE_DEFAULT,
                        MenuText.OPTION_GENERATE_CUSTOM,
                        MenuText.OPTION_OPEN_FROM_FILE,
                        MenuText.OPTION_EXIT_PROGRAM
                    }))
                {
                    case MenuText.OPTION_GENERATE_DEFAULT:
                        Generate(Default.MAZE_WIDTH,
                            Default.MAZE_HEIGHT);
                        break;
                    case MenuText.OPTION_GENERATE_CUSTOM:
                        Generate(Prompt.Input<int>(MenuText.INPUT_MAZE_WIDTH),
                            Prompt.Input<int>(MenuText.INPUT_MAZE_HEIGHT));
                        break;
                    case MenuText.OPTION_OPEN_FROM_FILE:
                        Open();
                        break;
                    case MenuText.OPTION_EXIT_PROGRAM:
                        _continue = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Generates the maze, then sends it to Loaded()
        /// </summary>
        /// <param name="width">width of the maze</param>
        /// <param name="height">height of the maze</param>
        private void Generate(int width, int height)
        {
            Console.WriteLine(MenuText.GENERATING, width, height);
            Loaded(new Maze(width, height));
        }

        /// <summary>
        /// opens a maze json file, then sends that maze to Loaded()
        /// </summary>
        private void Open()
        {
            try
            {
                var fileName = Prompt.Select(MenuText.SELECT_OPTION,
                    Directory.GetFiles(Default.FILE_FOLDER_MZE, Default.WILDCARD + Default.FILE_EXTENSION_MZE));
                using StreamReader file = File.OpenText(fileName);
                JsonSerializer serializer = new JsonSerializer();
                Maze maze = (Maze)serializer.Deserialize(file, typeof(Maze));
                file.Close();
                Loaded(maze);
            }
            catch (IOException)
            {
                Console.WriteLine(MenuText.IO_ERROR);
                switch (Prompt.Select(MenuText.SELECT_OPTION,
                    new[] {
                        MenuText.OPTION_TRY_AGAIN,
                        MenuText.OPTION_RETURN,
                        MenuText.OPTION_EXIT_PROGRAM
                    }))
                {
                    case MenuText.OPTION_TRY_AGAIN:
                        Open();
                        break;
                    case MenuText.OPTION_RETURN:
                        new Menu();
                        break;
                    case MenuText.OPTION_EXIT_PROGRAM:
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(MenuText.OPEN_ERROR_NO_MAZES);
                switch (Prompt.Select(MenuText.SELECT_OPTION,
                    new[] {
                        MenuText.OPTION_RETURN,
                        MenuText.OPTION_EXIT_PROGRAM
                    }))
                {
                    case MenuText.OPTION_RETURN:
                        new Menu();
                        break;
                    case MenuText.OPTION_EXIT_PROGRAM:
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
                Prompt.Select(MenuText.SELECT_OPTION,
                new[] {
                    MenuText.OPTION_SAVE_TO_FILE,
                    MenuText.OPTION_OUTPUT_TO_TXT,
                    MenuText.OPTION_GENERATE_NEW,
                    MenuText.OPTION_RETURN
                }))
            {
                case MenuText.OPTION_SAVE_TO_FILE:
                    SaveToFile(maze);
                    break;
                case MenuText.OPTION_OUTPUT_TO_TXT:
                    OutputToFile(maze);
                    break;
                case MenuText.OPTION_GENERATE_NEW:
                    Generate(maze.Width, maze.Height);
                    break;
                case MenuText.OPTION_RETURN:
                    break;
            }
        }

        /// <summary>
        /// Saves the maze to a json file
        /// </summary>
        /// <param name="maze">A ready made maze</param>
        private void SaveToFile(Maze maze)
        {
            var inputFileName = Prompt.Input<string>(MenuText.SAVE_INPUT_FILE_NAME);
            if (!inputFileName.Contains(Default.FILE_EXTENSION_MZE))//Add the .mze eztension if not present.
            {
                inputFileName += Default.FILE_EXTENSION_MZE;
            }
            if (File.Exists(Default.FILE_FOLDER_MZE + inputFileName))//Checks if file already exists.
            {
                Console.WriteLine(MenuText.SAVE_FILE_EXISTS + Environment.NewLine, inputFileName);
                if (!Prompt.Confirm(MenuText.CONFIRM_OVERWRITE))
                {
                    SaveToFile(maze);
                    return;
                }
                File.Delete(Default.FILE_FOLDER_MZE + inputFileName);
            }
            using StreamWriter file = File.CreateText(Default.FILE_FOLDER_MZE + inputFileName);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, maze);
            Console.WriteLine(MenuText.SAVE_SUCCESS + Environment.NewLine, inputFileName);
            file.Close();
        }

        private void OutputToFile(Maze maze)
        {
            var inputFileName = Prompt.Input<string>(MenuText.SAVE_INPUT_FILE_NAME);
            if (!inputFileName.Contains(Default.FILE_EXTENSION_TXT))//Add the .mze eztension if not present.
            {
                inputFileName += Default.FILE_EXTENSION_TXT;
            }
            string fileNameLocation = Default.FILE_FOLDER_TXT + inputFileName;//puts the file in the default folder
            if (File.Exists(fileNameLocation))//Checks if file already exists.
            {
                Console.WriteLine(MenuText.SAVE_FILE_EXISTS + Environment.NewLine, inputFileName);
                if (!Prompt.Confirm(MenuText.CONFIRM_OVERWRITE))
                {
                    OutputToFile(maze);
                    return;
                }
                File.Delete(Default.FILE_FOLDER_TXT + fileNameLocation);
            }
            using StreamWriter file = File.CreateText(fileNameLocation);
            file.WriteLine(maze.Display());
            Console.WriteLine(MenuText.SAVE_SUCCESS + Environment.NewLine, inputFileName);
            file.Close();
        }
    }
}
