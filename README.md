# ASCIIMazeGenerator
A grid based ASCII maze generator in C#

Example 25 x 25 maze:
║║╔╗╔╗╔════╦═╔═══╗╔═╦╗═╦╗
║╠╝╚╝╚╝║╔╦═╚╗║║╔╗╚╩═║╚═╝║
║║╔╗╔╦╗╠╝║╔╗║║╠╝║╔══╝╔══╝
║║║╚╝║║║╔╣║╚╝║╠═║╚╗══╩═══
║║╚╗╔╝╚═╝║╚══╝║╔╣║╚═════╗
║║═╝║╔╗╔╗╚╗╔══╝║╚╩╗╔════╣
║╚══╣║╚╝║║║║╔══╝╔═╝╚╗╔═╔╝
╚╗═╗║╚═╗║╚╩╗╠╗═╗╚╦═╔╝╠╗║║
║║╔╝╚╗║║╚╗║║║║╔╣╔╝╔╝║║║╚╣
║║╚╦╗║║╚╗║║╚═╝║║╚╗╚╗╚╝╠╗║
║╚╗║╚╝║╔╝║╚═══╩╗╔╝║╚═╗║║║
╠═╝║╔╦╝╚╗║╔═╗╔╗╚╣║╠╦╗║║║║
╚╗║╚╝║╔═╝║╚╗╚╝╚╗║╚╝║║║║╔╝
║║║╔╗║║║╔╝╔╝╔╦═║╚══╣║║║╚╗
╠╝╚╝╚╣║║║═╣╔╣║╔╝═╦═║╔╝╠═║
╚═══╗║║╠╝╔╝║╚╗╚═╗║╔╝╚╗╚╗║
╔═╗║╚═╝║═╩╗╚╗╚═╗║╚╣═╗╚╗║║
║║║║╔╗╔╝╔═╝║║╔╗║╚╗╚═╩═║╚╝
║╠╝║║╚╝╔╝═╗╠╝║║╚╗╚╗╔╗╔╝╔╗
║╚═╝║╔╦╝╔═╝║╔╦╝╔╩╗║║╚╝╔╝║
╚═╦╗║║║║╠═╗║║║╔╣═╝║║╔╗║║║
╔╗║║║║║╚╝╔╝╚═╣║║╔═╝╠╝╚╩╝║
║╚═╝╚╗║╔═╝╔══╝║╔╝╔╗║╔═══╣
╠═══╗║║║╔═╝══╗╚╝╔╝╚╗╚╗╔═║
╚═══╚╩╝╚╩════╩══╝══╩═╝╚═╝

Each character has a passageway with walls, with a potential for 4 passageways (Quite rare).

Works best in fonts that are uniform (8x8 for example).

Utilises the excelent SharPrompt, and Newtonsoft.json
If you are unaware of what Sharprompt is, here is a [link](https://github.com/shibayan/Sharprompt). It is an excelent interactive command line interface.
