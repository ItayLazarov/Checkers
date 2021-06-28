# Checkers
My final project for my practical engineering degree...

I'm working with .Net Framework

The game follows the basic rules of checkers with a twist:

There are 3 types of Pawns:

1) Pawn - can move one tile to the diagonal on the right or one tile to the diagonal on the left.

2) King - can move on every diagonal on the board (according to the color the king is on top of).

3) Last Pawn - can move to each diagonal on the board, but just one tile (like king in chess).

Each turn, the computer asks you to give him an Input - Strating point (x,y) and End point (x,y).

The options the pawn have are - move,first eat(each pawn can eat with different range on the board) and next time eat(all the pawns eats with the same movement).

If the player gives an input, which the pawn can't move to, the computer will asks again for new input (Starting and End point), and not just a new End point.

If one of the players has only one pawn left, the pawn will automatically change to Last Pawn.

The game goes on until one of the players has no pawns on the board at all.



