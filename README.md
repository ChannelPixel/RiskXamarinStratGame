# danielCherrin_StratGame
 ##Xamarin 4.0 - Swipable strategy game based on Risk
 - 5x5 grid game loosely based on the popular board game, Risk.
 - Implements INotifyChanged to allow most of the UI logic and battle logic be handled by the cell's binded objects, StratCell.
 - Meant to be played by two players. No AI.
 ###Rules:
 - Swipe units to move units a neutral cell, your own cell or an opponent cell.
 - First swipe moves half the units to the designated cell.
 - Second swipe moves the rest of the units -1 to the designated cell.
 - To take a cell, you must have either the same amount or more units attacking.
 - If the attacking amount of units is the same as the defending cell, the winner is decided randomly.
 
