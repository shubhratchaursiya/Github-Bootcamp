# Quick Setup Guide - Unity Endless Runner

## 🚀 Immediate Setup Steps

### 1. Unity Project Setup
1. Open Unity Hub
2. Create new **3D Project** (Unity 2022.3.0f1 or later)
3. Copy all files from this repository to your Unity project folder

### 2. Scene Configuration
1. Open **Build Settings** (File → Build Settings)
2. Add scenes in this order:
   - `Assets/Scenes/MainMenu.unity` (Index 0)
   - `Assets/Scenes/MainGame.unity` (Index 1)
   - `Assets/Scenes/GameOver.unity` (Index 2)

### 3. Tag Setup
1. Go to **Edit → Project Settings → Tags and Layers**
2. Add these tags (they should already be configured):
   - `Obstacle`
   - `Coin`
   - `Ground`
   - `Player`

### 4. Script Assignment
The scripts are already properly assigned in the scene files, but if needed:

**MainGame Scene:**
- Player GameObject → `PlayerController.cs`
- Main Camera → `CameraFollow.cs`
- GameManager → `GameManager.cs` and `GroundGenerator.cs`
- UI Canvas → Score display connected

**GameOver Scene:**
- GameOverManager → `GameOverManager.cs`
- UI buttons properly connected

**MainMenu Scene:**
- MainMenuManager → `MainMenuManager.cs`
- UI buttons properly connected

## 🎮 Testing the Game

1. Open the **MainMenu** scene
2. Click **Play** button in Unity
3. Test the following:
   - Main menu buttons work
   - Player movement (A/D or arrow keys)
   - Coin collection increases score
   - Obstacle collision ends game
   - Game over screen appears
   - Restart functionality

## 🔧 Common Issues & Fixes

### Issue: "Script Missing" errors
**Solution**: Select the GameObject and reassign the script from the Scripts folder

### Issue: UI buttons not working
**Solution**: Check that the Canvas has GraphicRaycaster component

### Issue: Player falls through ground
**Solution**: Ensure the player has a Rigidbody and ground has colliders

### Issue: No obstacles/coins spawning
**Solution**: 
1. Check that GameManager has spawn prefabs assigned
2. Create simple cube prefabs with appropriate tags
3. Assign them to the GameManager's arrays

## 📦 Creating Missing Prefabs (If Needed)

If you need to create prefabs manually:

### Obstacle Prefab:
1. Create Cube (GameObject → 3D Object → Cube)
2. Add tag "Obstacle"
3. Scale to (1, 1, 1)
4. Add red material
5. Drag to Prefabs folder

### Coin Prefab:
1. Create Sphere (GameObject → 3D Object → Sphere)
2. Add tag "Coin"
3. Add `CoinRotator.cs` script
4. Add trigger collider
5. Add yellow material
6. Drag to Prefabs folder

## 🎯 Build Instructions

1. **Build Settings**: File → Build Settings
2. **Platform**: Select target platform
3. **Scenes**: Ensure all 3 scenes are added and enabled
4. **Build**: Click "Build" or "Build and Run"

## 🎨 Customization Quick Tips

- **Player Speed**: Modify `forwardSpeed` in PlayerController
- **Spawn Rate**: Adjust `minSpawnInterval` in GameManager
- **Colors**: Change material colors in scene objects
- **UI Text**: Modify text in Canvas components

## ✅ Final Checklist

- [ ] All 3 scenes load properly
- [ ] Player movement works
- [ ] Coins increase score
- [ ] Obstacles end game
- [ ] Scene transitions work
- [ ] UI buttons function
- [ ] Game can be built successfully

---

**Ready to play!** 🎮✨

For detailed documentation, see the main README.md file.