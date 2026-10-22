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
#
## Main
