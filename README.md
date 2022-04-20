# Snowboarder

You can play it [here](https://friarhob.github.io/snowboarder).

Simple prototype developed (and changed to include rules, a game mechanic and refactoring) based on [GameDev.tv Unity2D Course on Udemy](https://www.udemy.com/course/unitycourse/).

---

## Rules

* AD/LeftRight to rotate, WS/UpDown to accelerate/break (also supports joysticks, but I didn't test this throughouly).

* You need to do as much points as possible in your performance.

* You gain points for the time you spend running, and also per loops:
  - You gain 37 points per second
  - You gain 500 points for each backward flip
  - You gain 1000 points for each forward flip

* If you crash your head while playing, the game is over.

---

## Basic Architecture Decisions

### Managers

_Note: all managers are singletons, but we do not use a_ `DontDestroyOnLoad()` _parent._

* **GameManager** hosts game states, and scoring system.

* **EventManager** is responsible for calling all internal events in the game, as stated by the following table:

| Event Name         | Function to invoke it | Notes                                                                           |
| ------------------ | --------------------- | ------------------------------------------------------------------------------- |
| onBackwardFlip     | backwardFlip()        | -                                                                               |
| onFinishRun        | finishRun()           | Event called once the player passes through the finish line                     |
| onForwardFlip      | forwardFlip()         | -                                                                               |
| onGameOver         | gameOver()            | Event called every time a game ends for any reason (either crash or finish line |
| onSnowboarderCrash | snowboarderCrash()    | -                                                                               |
| onStartNewGame     | newGame()             | Event not called in the first run                                               |

* **UIManager** controls both the visibility on the score text field and the time waited between a crash/crossing the finish line and starting a new game.

* **SoundManager** controls when to play each sound of the game. Currently we have:

| Sound File     | Description                                   |
| -------------- | --------------------------------------------- |
| Crash+SFX.ogg  | Plays when the player crashes their head      |
| Finish+SFX.ogg | Plays when the player crosses the finish line |

### Canvas

#### Text fields

* **Score Text (TMP)** shows the score while is playing
* **High Score Text (TMP)** shows the highest local score so far

#### Panels

* **InstructionsPanel** opens when the game start, showing the rules, with a button for starting a new game.

---

## To-do list

* Refactor to control Instructions Panel via events.