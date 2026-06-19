# More Traders Mod

A BepInEx mod for **Casualties Unknown** that adds custom, fully-featured trading NPCs to the game. Complete with in-game developer console integration, autocompletion support, and built-in anti-exploit protection.

---

## 👥 Meet the Traders

This mod introduces three unique non-playable characters (NPCs) with custom trading inventories, names, and interaction behaviors:

### 🩺 Dr. Hernandez (Medic)
- **Role:** Specialized medical supplier and practitioner.
- **Service:** Automatically restores your health to full when you initiate a trade with him.
- **Inventory:** Sells vital medical supplies, first-aid kits, and medicine to help you survive.

### 🍳 Mama Cecile (Chef)
- **Role:** Culinary expert and restaurant owner.
- **Service:** Automatically satisfies your hunger and increases player satisfaction upon opening her trade menu.
- **Inventory:** Sells ingredients, canned goods, and home-cooked meals.

### 🎲 Lucky (Gambler)
- **Role:** High-roller dealer.
- **Service:** Tests your luck with mystery boxes and lottery-style items.
- **Inventory:** Sells custom mystery boxes, game tickets, and unique high-risk high-reward items.

---

## 💻 Console Commands & Autocomplete

Spawn these traders instantly anywhere using the in-game developer console. 

| Command | Action |
|:---|:---|
| `spawnmedic` | Spawns **Dr. Hernandez** (Medic) at your current crosshair position. |
| `spawnchef` | Spawns **Mama Cecile** (Chef) at your current crosshair position. |
| `spawngambler` | Spawns **Lucky** (Gambler) at your current crosshair position. |

### ⚡ Autocomplete Support
Type `spawn` in the developer console and press `Tab` to quickly browse and auto-complete these commands!

---

## 🛠️ Advanced Features

### 🛡️ Anti-Exploit State Tracker
To prevent players from repeatedly opening and closing trading menus to infinitely heal or feed themselves, the mod includes a robust state tracking system:
- **Interaction Cooldown:** A trader's special status action (healing for Dr. Hernandez, feeding for Mama Cecile) will only trigger **once** per spawn or per long interaction cycle.
- **Fair Play:** Closing and reopening the menu immediately on the same NPC will not re-trigger the benefit, keeping the game balanced.

---

## 📥 Installation

1. **Prerequisite:** Ensure you have **BepInEx** installed for *Casualties Unknown*.
2. **Download:** Grab the latest `MoreTraders.dll` from the [Releases](https://github.com/NaeNaeTart/More-Traders/releases) tab.
3. **Deploy:** Place the downloaded `MoreTraders.dll` file into your game's plugins directory:
   ```path
   [Casualties Unknown Game Directory]/BepInEx/plugins/
   ```
4. **Play:** Start the game and enjoy!

---

## 🏗️ Development & Compilation

To build this mod from source:

1. Clone this repository.
2. Ensure you have the `.NET Framework 4.7.2 SDK` installed.
3. Place game references (e.g., `Assembly-CSharp.dll`, `UnityEngine.dll`, BepInEx libraries) in your local references directory or update the reference paths in `MoreTraders.csproj`.
4. Compile the project using dotnet CLI:
   ```bash
   dotnet build -c Release
   ```
