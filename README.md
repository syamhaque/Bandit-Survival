# Bandit Survival
### ECS 289G Fall 2020 Final Project

Bandit Survival is a tile rogue based game where you play as a bandit dropped off at a new world. It is your goal to live as long as possible while destroying any and all who are ready to fight you. Find food to keep your huger at bay and fight off zombies to get sweet goodies. How long will you survive?


## Download Instructions
1. Download the `Releases.zip` file from [Releases](https://github.com/vybhavb/Bandit-Survival/releases/latest)
    1. If you are on a Mac choose the Mac version of the game (Support maybe limited)
    2. If you are on Windows, go ahead and select the Windows release
2. Unzip the folder downloaded
    1. Mac users may need to open the `.app` through terminal
    2. Windows users may open the .exe file after extraction to run the game


## Game
### Controls
The controls rely on using either w,s,a,d to move around and left click to swing your sword. Users may also use the arrow keys along with "f" to swing your sword.

### Mechanics
- Every step decreases your food availability. The amount of food you have available is your health. Once you reach 0, it is game over. 
- You may gain food by picking up scraps as you explore or by fighting enemies. Enemies may also drop special weapons that deal extra damage. 
- The player can also destroy walls around them to build a faster path to the exit.
- The minimap shows the locations of food available as `blue` diamonds and the exit as a `green` square

### Why
Our goal was to build the game with player personalization in mind. Each level is procedurally generated by taking into account how much the player explores. The weapons are generated based on how the player interacts with them. If a player prefers to fend off enemies to find weapons, stronger weapons may spawn. However, if a player prefers to move around the enemies, the enemies may rather drop food.

The map can also change in size based on the exploration tactics of the player. The map may increase in size if a player tends to venture through the landscape but get smaller if they go straight to the next level. All in all, your playstyle builds a unique experience for the game.


Built with ❤ by:
<a href="https://github.com/vybhavb/Bandit-Survival/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=vybhavb/Bandit-Survival" />
</a>
