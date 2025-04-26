# EmergencySimulation Response
# 🚨 Emergency Response Simulation - C# Project

This is a simple **Emergency Response Simulation** built with **C#** using **Object-Oriented Programming (OOP)** principles.  
Players can either **automatically dispatch** units or **manually select** units to respond to randomly generated incidents.

---

## 📋 Features

- **Emergency Units**: Police, Firefighter, Ambulance, Rescue Helicopter, Bomb Squad.
- **Incident Types**: Crime, Fire, Medical Emergency, Rescue Operation, Bomb Threat.
- **Two Modes**:
  - **Auto Dispatch**: The system automatically assigns the correct unit.
  - **Manual Selection**: Player manually chooses which unit to respond.
- **Scoring System**:
  - Correct response: Earn points based on incident difficulty.
  - Wrong selection: Lose points.

---

## 🛠 How It Works

1. **Start** the simulation and **choose a mode** (Auto or Manual).
2. **Random incidents** appear at different locations with random difficulty.
3. **Units are dispatched** to handle the incidents.
4. **Points are awarded** or **deducted** based on decisions and performance.
5. After 5 incidents, the **final score** is displayed.

---

## 🧱 Main Classes

- **EmergencyUnit (abstract)**: Base class for all emergency units.
- **Police, Firefighter, Ambulance, RescueHelicopter, BombSquad**: Inherit from `EmergencyUnit` and implement specific behavior.
- **Incident**: Represents an emergency event with type, location, and difficulty.
- **Program**: Manages simulation flow, unit selection, scoring, and incident generation.

---

## 📦 Requirements

- .NET SDK (Any version supporting C# 8.0+)
- Basic C# knowledge (for manual editing or extension)

---

## 🚀 How to Run

1. **Clone** or **download** the project.
2. Open in **Visual Studio**, **Visual Studio Code**, or any C# IDE.
3. Build and **Run the program** (`Main` method).

---

## 📈 Future Improvements (Optional Ideas)

- Add more unit types (e.g., SWAT, Coast Guard).
- Introduce multiple simultaneous incidents.
- Visual representation (GUI with WinForms or WPF).
- Improve scoring with response times or penalties.

---

## 📄 License

Free to use for learning and educational purposes. ✨

