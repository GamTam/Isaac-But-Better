Mabel DaCambra | 100864938

Game title: Hog Gaming 2026 Simulator
The core gameplay loop of the game is that enemies will spawn in all around the player, and they are tasked with destroying as many as they can until either their score reaches 5,000 or they fail.

![alt text](https://github.com/GamTam/Isaac-But-Better/blob/main/UML%20Chart.png "UML Chart")

- What element of your game adopts this chosen pattern?
The part of the game that I added to include the singleton pattern is a sound effect manager that loads and plays sounds as the rest of the game objects call for it.

- Why is this pattern a good choice for the associated functionality?
Managers in general are a good fit for the singleton pattern, but for the case of my sound manager specifically, it's useful to make sure that there's only one instance so sound effects don't get loaded more than once.

Sound Effects/Music from Sonic Mania (2017)
