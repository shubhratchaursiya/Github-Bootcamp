# Unity Endless Runner Game

A complete Unity endless runner game built with C# scripts and 3D objects. The player controls a moving cube, collects coins, avoids obstacles, and competes for high scores.

## 🎮 Game Features

### Core Gameplay
- **Player Movement**: 3D cube player with automatic forward movement
- **Controls**: Left/Right movement using arrow keys or A/D keys
- **Obstacles**: Randomly spawned cubes and cylinders that end the game on collision
- **Coins**: Collectible spheres that increase score and rotate with bobbing effect
- **Endless Ground**: Procedurally generated colored ground segments

### UI System
- **Score Display**: Real-time score counter during gameplay
- **Main Menu**: Title screen with start/quit buttons and high score display
- **Game Over Screen**: Final score display with restart and main menu options

### Technical Features
- **Scene Management**: Three scenes (MainMenu, MainGame, GameOver)
- **Camera Follow**: Smooth camera that follows the player
- **Object Pooling**: Automatic cleanup of old obstacles and coins
- **Save System**: High score persistence using PlayerPrefs

## 🎯 Game Requirements Met

✅ **Player**: 3D cube with forward movement and side controls  
✅ **Ground/Track**: Colored 3D planes with endless generation  
✅ **Obstacles**: Collision detection with game over functionality  
✅ **Coins**: Collectible objects with score increase  
✅ **UI**: Score display and Game Over scene  
✅ **Bonus**: Main Menu scene with prefab organization  

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── PlayerController.cs      # Player movement and collision
│   ├── GameManager.cs           # Game logic and object spawning
│   ├── CameraFollow.cs          # Camera following behavior
│   ├── GroundGenerator.cs       # Endless ground generation
│   ├── CoinRotator.cs           # Coin visual effects
│   ├── GameOverManager.cs       # Game over screen logic
│   └── MainMenuManager.cs       # Main menu functionality
├── Scenes/
│   ├── MainMenu.unity           # Title screen
│   ├── MainGame.unity           # Main gameplay
│   └── GameOver.unity           # Game over screen
├── Materials/                   # (Ready for custom materials)
├── Prefabs/                     # (Ready for prefab objects)
└── Audio/                       # (Ready for sound effects)

ProjectSettings/
├── TagManager.asset             # Game tags (Obstacle, Coin, Ground)
├── EditorBuildSettings.asset    # Scene build configuration
└── ProjectVersion.txt           # Unity version info
```

## 🛠️ Scripts Overview

### PlayerController.cs
- Handles player movement (forward + side)
- Collision detection with obstacles and coins
- Movement constraints and physics

### GameManager.cs
- Singleton pattern for game state management
- Score tracking and UI updates
- Dynamic obstacle and coin spawning
- Scene transitions and game over logic

### CameraFollow.cs
- Smooth camera following with configurable offset
- Look-at functionality for dynamic camera angles

### GroundGenerator.cs
- Procedural ground segment generation
- Automatic cleanup of old segments
- Configurable ground size and color

## 🎮 Controls

- **Movement**: Arrow Keys or A/D keys for left/right movement
- **Menu Navigation**: Mouse clicks or keyboard shortcuts
- **Restart**: Spacebar or Enter in Game Over screen
- **Quit**: Escape key in menus

## 🎨 Visual Design

- **Player**: Blue cube with smooth movement
- **Ground**: Green procedural planes
- **Obstacles**: Red cubes and cylinders
- **Coins**: Yellow spheres with rotation and bobbing
- **UI**: Clean, modern interface with colored buttons

## 🏗️ Setup Instructions

### For Unity Development:
1. Open Unity Hub
2. Create new 3D project or open existing project
3. Copy all files from this repository to your project
4. Configure Build Settings:
   - Add scenes in order: MainMenu → MainGame → GameOver
   - Set MainMenu as the first scene
5. Configure Tags:
   - Add tags: "Obstacle", "Coin", "Ground", "Player"
6. Test the game in Play Mode

### For Standalone Build:
1. Open Build Settings (Ctrl+Shift+B)
2. Select target platform
3. Build the game
4. Run the executable

## 🎯 Gameplay Instructions

1. **Start**: Launch the game and click "Start Game"
2. **Movement**: Use A/D or arrow keys to move left/right
3. **Objective**: Collect yellow coins (+10 points each)
4. **Avoid**: Red obstacles (ends the game)
5. **Survival**: Try to get the highest score possible!

## 🔧 Customization Options

### Easy Modifications:
- **Player Speed**: Adjust `forwardSpeed` and `sideSpeed` in PlayerController
- **Spawn Rate**: Modify `minSpawnInterval` and `maxSpawnInterval` in GameManager
- **Coin Value**: Change score increment in GameManager.AddScore()
- **Colors**: Modify material colors in respective scripts

### Advanced Features:
- **Power-ups**: Add new collectible types
- **Multiple Lanes**: Extend lane system in GameManager
- **Difficulty Progression**: Implement speed increases over time
- **Particle Effects**: Add visual effects for coins and obstacles

## 🎵 Audio Ready

The project structure includes an Audio folder ready for:
- Background music
- Coin collection sounds
- Obstacle collision sounds
- UI button sounds

## 🐛 Known Issues & Solutions

- **Missing Prefabs**: Create prefabs for obstacles and coins in the Prefabs folder
- **No Audio**: Add audio clips to the Audio folder and attach to respective scripts
- **Performance**: Adjust spawn intervals and cleanup distances for optimization

## 📊 Score System

- **Coins**: +10 points each
- **High Score**: Automatically saved and displayed
- **Persistence**: Scores saved between game sessions

## 🚀 Future Enhancements

- **Multiplayer**: Add local multiplayer support
- **Leaderboards**: Online high score tracking
- **Achievements**: Add achievement system
- **Mobile Support**: Touch controls for mobile devices
- **Procedural Levels**: More complex track generation

## 📝 License

This project is created for educational purposes. Feel free to modify and use for learning Unity game development.

---

**Enjoy the endless running adventure!** 🏃‍♂️💨