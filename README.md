# WASD

## About
**WASD** is a simple game developed in C# with Unity and influenced by Brotato, Vampire Survivor. This project was made for our module "Software Development 3" in the third semester of BSc Medieninformatik at Hochschule der Medien. <br>

**WASD** is a Rogue-Like, Auto-Shooter, Survial game played in a Cyberpunk world and created in pixel-art. <br>

Our game stands out with simplicity in gameplay and our varierty of items and weapons combinations. You are playing an bounty hunter called "hier könnte ihr Werbung stehen". She is able to handle up to 6 weapons at the same time and she gets continuous upgrades through items, like implementable Brainsystem or Inner Eye.<br>

**BUT** watch out if you substitute to much of your human body you will go insane and turn into a Cyberpsycho. <br>
Your **goal** is to survive all enemy waves as long as you can to get the best highscore among all players. 

<br>

## Features
- autofiring weapons with the ability to aim in mouse direction
- infinte run (highscore based game)
- every run is individual because of different combinations
- survive enemy waves that longs 60 seconds
- try to kill as many enemies in a wave to maximize your currency and level

<br>

## Installation
### 1.	WSL2 (needed for Docker):
  -	Open PowerShell on Windows as administrator
  -	Use command ```wsl –update```
  <br><br> ![PowerShell with command wsl --update](https://github.com/Andrushka130/WASD/blob/main/Images/README/wsl.png)

### 2.	Docker Desktop:
  -	Download and run installer https://www.docker.com/products/docker-desktop/

### 3.	MongoDB Image:
  -	start Docker Desktop (can take some time)
  -	Use command ```docker pull mongo``` in PowerShell
  <br><br> ![PowerShell with command docker pull mongo](https://github.com/Andrushka130/WASD/blob/main/Images/README/Mongo_Image.png)
  -	After use ```docker run --name mongodb -p 27017:27017 mongo```
  <br><br> ![PowerShell with command docker run --name mongodb -p 27017:27017 mongo](https://github.com/Andrushka130/WASD/blob/main/Images/README/Mongo_starten.png)
  -	Port 27017:27017 is important!

### 4.	Visual Studio Code: 
  -	Download and run installer  https://code.visualstudio.com/
 
### 5.	REST Client:
  -	Start Visual Studio Code
  -	Go to plugins
  -	Search for REST Client in searchbar
  -	install REST Client
  <br><br> ![Screenshot VS Code plugin section](https://github.com/Andrushka130/WASD/blob/main/Images/README/REST.png)

### 6.	Node.js:
  -	Download and run installer https://nodejs.org/en/
  <br><br> ![Screenshot test.http file](https://github.com/Andrushka130/WASD/blob/main/Images/README/Node_js.png)

### 7.	Express.js:
  -	Open project in Visual Studio Code
  -	Open terminal in Visual Studio Code
  <br><br>![Screenshot VS Code terminal tab](https://github.com/Andrushka130/WASD/blob/main/Images/README/terminal.png)
  -	Navigate to Backend using ```cd .\Backend\``` in terminal
  <br><br> ![Screenshot VS Code terminal command cd .\Backend\](https://github.com/Andrushka130/WASD/blob/main/Images/README/navigation.png)
  - Install Express using ```npm i express``` in terminal
  <br><br> ![Screenshot VS Code terminal command npm i express](https://github.com/Andrushka130/WASD/blob/main/Images/README/express.png)
  
### 8. MongoDB Driver:
  - Install MongoDb Driver using ```npm i mongodb```
  <br><br> ![Screenshot VS Code terminal command npm i mongodb](https://github.com/Andrushka130/WASD/blob/main/Images/README/mongodb.png)

### 9.	Insert test data:
  -	Make sure that the Docker container is running
  <br><br> ![Screenshot Docker Desktop](https://github.com/Andrushka130/WASD/blob/main/Images/README/Docker.png)
  -	Use command ```node app.js``` to start the server
  <br><br> ![Screenshot VS Code terminal command node app.js](https://github.com/Andrushka130/WASD/blob/main/Images/README/server_start.png)
  -	Open file test.http in Backend
  <br><br> ![Screenshot VS Code Explorer](https://github.com/Andrushka130/WASD/blob/main/Images/README/test_öffnen.png)
  -	Send Post Request for url insertTestData with left mouse click on Send Request (REST Client plugin)
  <br><br> ![Screenshot test.http file](https://github.com/Andrushka130/WASD/blob/main/Images/README/test_daten.png)

<br>

## Start game

-	Start Docker Desktop
-	Start MongoDB Container
-	Start Visual Studio Code and open Projekt
-	Open terminal and navigate to Backend using ```cd .\Backend\```
-	Run command ```node app.js```
-	Start game with double click


<br>

## Controls

**Keyboard:**

W - move upward <br>
A - move left <br>
S - move down <br>
D - move right <br>
Esc - Pause/Menu <br>
Mouse - fire directions

**Shop:**

- Left click with your mouse on the **buy-button** to buy an item
- Left click on the **lock-button** to keep it for the next shop roll
- Left click on **minus and plus buttons** to increase or decrease your attributes with your attribute points that you get from leveling up
- Left click on the **reroll-button** to reroll your current shop

After every wave, you have the possibilty to buy items and weapons. <br>
Items improve your attributes and may also give you a little extra feature - for example a double shot! <br>
If you already have a **weapon Lvl 1/2**, you can receive the better version of it with a bit of luck. 
In case you aren’t pleased with the offers, you can reroll the shop. Of course, this comes with extra costs! <br>

<br>

## Dependencies
-	Docker Desktop
-	Docker MongoDB Image
-	WSL2
-	Visual Studio Code
-	REST Client for VS Code
-	Node.js
-	Express.js
- MongoDB Driver for Node.js
