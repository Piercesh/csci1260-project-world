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
# 
## Monster
#
## Player
#
## Main
