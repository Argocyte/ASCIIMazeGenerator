namespace ASCIIMazeGenerator
{
    /// <summary>
    /// chars for each of the variations of passages a cell can have.
    /// </summary>
    public static class Passage
    {
        public const char NONE = '▒';
        public const char NORTHSOUTHEASTWEST = '╬';
        public const char NORTHSOUTHEAST = '╠';
        public const char NORTHSOUTHWEST = '╣';
        public const char NORTHEASTWEST = '╩';
        public const char SOUTHEASTWEST = '╦';
        public const char NORTHSOUTH = '║';
        public const char NORTHEAST = '╚';
        public const char NORTHWEST = '╝';
        public const char SOUTHEAST = '╔';
        public const char SOUTHWEST = '╗';
        public const char EASTWEST = '═';
        public const char NORTH = NORTHSOUTH; //don't have a capped ASCII character, which is unfortunate. This works fine.
        public const char SOUTH = NORTHSOUTH;
        public const char EAST = EASTWEST;
        public const char WEST = EASTWEST;
    }

    /// <summary>
    /// constants of all the manu text that is used/can be used.
    /// </summary>
    internal static class MenuText
    {
        public const string BLANK = "";
        public const string SELECT_OPTION = "Select an option";
        public const string OPTION_GENERATE_DEFAULT = "Generate a maze of a standard size";
        public const string OPTION_GENERATE_CUSTOM = "Generate a custom sized maze";
        public const string OPTION_GENERATE_NEW = "Generate a new maze of the same size";
        public const string OPTION_SAVE_TO_FILE = "Save current maze to a file";
        public const string OPTION_OPEN_FROM_FILE = "Open a maze from a file";
        public const string OPTION_TRY_AGAIN = "Try again";
        public const string OPTION_RETURN = "Return to main menu";
        public const string OPTION_OUTPUT_TO_TXT = "Output this maze to a text file";
        public const string OPTION_EXIT_PROGRAM = "Exit the program";
        public const string INPUT_MAZE_WIDTH = "Enter the width";
        public const string INPUT_MAZE_HEIGHT = "Enter the height";
        public const string GENERATING = "Generating a maze of size {0}, {1}...";
        public const string GENERATED = "Generated a maze of size {0}, {1}...";
        public const string SAVE_INPUT_FILE_NAME = "Input the name you wish to call this maze";
        public const string SAVE_SUCCESS = "Save was succesful. File {0} created";
        public const string SAVE_FILE_EXISTS = "A file by the name of {0} already exists";
        public const string CONFIRM = "Are you sure?";
        public const string CONFIRM_OVERWRITE = "Do you want to over-write this file? Original will be lost";
        public const string IO_ERROR = "The file name you entered was not valid";
        public const string OPEN_ERROR_NO_MAZES = "There are no mazes saved";
    }

    /// <summary>
    /// default values
    /// </summary>
    public static class Default
    {
        public const int MAZE_WIDTH = 25;
        public const int MAZE_HEIGHT = 25;
        public const string FILE_EXTENSION_MZE = ".mze";
        public const string FILE_EXTENSION_TXT = ".txt";
        public const string FILE_FOLDER_MZE = "MazeFiles\\";
        public const string FILE_FOLDER_TXT = "MazeOutpt\\";
        public const char WILDCARD = '*';
    }
}
