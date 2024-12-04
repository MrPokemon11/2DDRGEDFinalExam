# DevonRogersGEDFinal
 Now in glorious 2D!

things i made:
 
command design pattern: ICommand has an execute function that is intended to be responsible for the movement of pieces, the rotation of pieces, and the falling of pieces
 
object pooling: the way i would implement object pooling is that i would create a pool of 5 of each tetris piece, then pull them from the pool when i needed them. if the pool was empty of a given piece, i would make a new one of that type.

DLL: my DLL is intended to make the pieces fall 15x faster. i did this by having the DLL return a float. the dll can also accept an input, making it possible to make the fall speed random.

I do not have a diagram breaking down the implementation process for the observer design pattern, as I did not manage to implement it.

