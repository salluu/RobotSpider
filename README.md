Technical Test: Robot Spiders

Overview

A squad of robotic spiders are to be sent to explore micro fractures on the wall of a building!

This wall, which is rectangular, must be navigated by the Spiders so that their on-board diagnostics can get a complete view of the wall from close up before sending the data back to the control deck. The spiders are highly autonomous and will follow the instructions sent to them in the start command.

A spider's position is represented by a combination of x and y coordinates and a current orientation. The wall is divided up into a grid to simplify navigation.

An example position might be “0 0 Up” which means the spider is in the bottom left corner and facing up the wall.

In order to control a spider, Control sends a simple string of letters:

* The possible letters are 'L', 'R' and 'F'.

* 'L' and 'R' makes the spider spin 90 degrees left or right respectively, without moving from its current spot.

* 'F' means move forward one grid point, and maintain the same direction.

Assume that the square directly Up from (x, y) is (x, y+1).

INPUT

The first line of input is information pertaining to the size of the wall. 0 0 (bottom left) to x y (Top right)

Next is information about the spider’s current location and orientation. Each spider has two lines of input. The first line gives the spider's position, and the second line is a series of instructions telling the spider how to explore the wall.

The position is made up of two integers and a word separated by spaces, corresponding to the x and y coordinates and the spider's orientation.

OUTPUT

The output for the spider should be its final co-ordinates and heading.

Test Input:

7 15

2 4 Left

FLFLFRFFLF

Expected Output:

3 1 Right
