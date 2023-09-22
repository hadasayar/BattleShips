# BattleShipGame
This is a Battleship game implemented as a .NET Web API. It allows players to play the classic Battleship game over HTTP requests.

# Game Rules
The Battleship game follows the classic rules:

1. Each player has a board with a grid of cells.
2. Players take turns guessing the coordinates to locate and sink the opponent's ships.
3. Ships are placed on the grid and can be of different sizes (e.g., battleship, cruiser, destroyer).
4. The game continues until all ships of one player are sunk.

# API Endpoints
The API provides the following endpoints:

*POST /api/game/newplayer* - Register a new player in the game.

*GET /api/game/myboard* - Retrieve a player's own game board.

*GET /api/game/oppboard* - Retrieve the opponent's game board.

*GET /api/game/isgameover* - Check if the game is over.

*POST /api/game/makemove* - Make a move by specifying coordinates to attack.

*GET /api/game/whosturn* - Get the ID of the player whose turn it is.

# Models
The following models are used in this project:

1.Board - Represents a player's game board.

2.CellState (Enum) - Defines the state of a cell on the board (empty, ship, hit, miss).

3.Game - Represents a Battleship game with players and their boards.

4.Player - Represents a player in the game with a name and a board.

5.BattleShip - Represents a ship on the board.

# Service
The core game logic is implemented in the GameManagerService. This service manages game state, player turns, and move validations.

# Running the Game

Start the API as mentioned in the "Getting Started" section.

Use API client (e.g., Postman, curl) to interact with the API endpoints.

Register new players using the /api/game/newplayer endpoint.

Retrieve player boards using /api/game/myboard and /api/game/oppboard.

Make moves by sending POST requests to /api/game/makemove with the coordinates you want to attack.

Check the game status using /api/game/isgameover.

Continue playing until one player's ships are all sunk.
