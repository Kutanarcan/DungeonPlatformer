# DungeonPlatformer
This project is a demo. I build this project to understand more complex systems and combine them together.

*-*Currently Active Systems*-*
-Player(Connector(Controller),Movement,Input,AnimationController,Attack,Skills,SaveController,Key Holder etc.)
-Player Special Attack System(Needs Some Work)
-Player Skill System(Need Visual System)
-Enemy(Movement,SpecialMovement,StateMachineHolder,AnimationController)
-Boss(Connected to Enemy System,StateMachineHolder)(Not Finished)
-NPC(Interactible,DialogueHolder,Speaker,HasConversations,Has special dialogue edition, add conversation certain point of the game)
-Dialogue System
-Input Manager
-Intractables
-Universal Damage System
-Key-Door System(Lock System)
-Key Holder System(Connected with Key-Door System)
-Level System(Not Finished,In Progress)
-Popup Manager(Needs some animations)
-UI Control System
-Flexible Grid Layout System
-Tilemap System(Basics)
-Custom Event Rapper System
-Object Pooling System
-Save-Load Manager
-Extensions
-State Machine
-Time Manager
-2D Light System(Basics)
-Inventory System
-Input Control System
-Option Menu-Settings Manager(Resolution, Music, SFX,Quality Settings)

*-*Will Add*-*
-Choice Manager : Boss fight is going to give the Player an option, player will choose one of them and the result will effect the end of the game.
-Character Selection System
-Game Currency
-Shop System
-Equip Item System
-Item Drop system
-Collectible Items will Add to the game(Ready)

*-*System Fixes Need*-*
-Level System need work. 
-Special Attack Manager has so many dependencies.
-Fade Manager is not Flexible
-UI Control System need work: Canvas transitions will be rearrange because when Player playing the game, Canvas opens and bug out. 
2 solution for this: Don't turn off the Canvas enable, deactivate all canvas object or handle with a Custom Canvas Group.(Maybe disable Canvas and Raycast target.)
-Flexible Grid Layout cannot orginize the grid objects.
