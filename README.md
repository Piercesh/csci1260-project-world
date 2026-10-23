### Sid Pierce Video Game
# In this code I went to make a maze game that has been set to have 3 rounds.
# This has multiple classes in here that were needed and it did take a while to get done
## Abstract Item
# Abstract item will be connected to the Interface Item
# There is a string name that will have get and protected set.
# Protected Item that will have name.
# The last thing will be a public abstract void Use(Player player)
## Potion
# Potion will be connected to Item
# It will have the int HealAmount so the player can gain hp.
# There will be a public potion that has string name, int HealAmount, and base(name)
# The last thing will be a public override of use (Player player) that will allow the player to gain hp
## Weapon
# Weapon will also be connected to item
# There will be a public int DamageBonus {get; } that is needed
# A public Weapon will have name, damageBonus and base(name)
# The last will be an override void Use(Player player) that will have player.EquipWeapon(Name, DamageBonus)
## IItem
# IItem has been sat as an interface
# It will be connected to the abstract Item.
# The interface will also help out show the potion and item so the player can get them.
# The interface will have a name {get; } and will also have the void Use (Player player).
## Monster
# The Monster will have some important stuff that will help it spawn and be a threat to the player.
# For X and Y, it is what will help the monster to spawn in the maze.
# The Monster is going to have some health and will also do some damage to the player when it gets into battle.
# There is a bool IsAlive to know if the monster is alive or dead.
# There is a public monster that will have x,y, damage and health.
# One thing I wanted it to do was to move around and find the player so there is the MoveTowardsPlayer
# There is the attack so it will be capable of attacking
# and there is the takedamage, so the player will be capable of defeating the monster.
## Player
# The Player class was the second class I had put in and is the second most important code.
# There is a public int X and Y to help the player spawn in
# Then there's the public int Health so there can be health for the player.
# With Health there is also maxHealth that has been set to 100.
# WeaponDamage has been set to 0 to show the player is weak for now.
# MovesRemaining is to make sure there are limited turns for the player
# EquippedWeapon will be set to you starting off with your fist.
# There is a list in players that has the interface IItem in it.
# It is to make sure that the player will be capable of using those items while they go through the maze.
# There is the public Player that has x, y, movesRemaining, and MaxHealth
# In Void Move, there is x and y which is to help the player move around.
# UseMove() is to let you know how many moves there are left, if you have 0, then you can't move
if you do have more moves then you can continue.
# ResetMoves is to keep track of the moves you made
# TakeDamage Is to make sure the player takes damage from the monster.
# EquipWeapon is for when the player gets a weapon and it will add the damage and show the name.
# Heal is for when the player gets a potion.
# AddItem is for when you get an item added to your inventory
# GetAttackDamage is for when the player picks up the weapon, they will get a bonus.
# ShowInventory is to show your inventory and what you have gained from the maze.
# And the last one is the UseItemInventory that will allow you to use the items you have
# If you don't put a right input then it will tell you thats an invalid choice.
## Main
# There is a random that should make the maze be random.
# Here is the ints for widths, heights, moveLimits to set up the maze.
# Player player = new Player is going to keep track on how many times the player can move.
# In the game there will be a total of 3 rounds the player must complete to win the game.
# If they use too many moves or lose to a monster, the game will end.
# When you see the 'E' That is where the Exit will be.
# 'W' & 'H' are where your items will be.
# 'M' is how the monster will spawn in and move around.
# 'P' is the player themselves.
# The game will make sure to keep count on how many rounds it has been,
# how many items you got and if they been used, and how much health you got left.
# Instructions shoulf show up on what each button does.
# There will be a GenerateMaze so the maze can be made.
# PlaceRandomItems() is going to make sure that the items do spawn in.
DrawMaze is what will make the maze itself.
