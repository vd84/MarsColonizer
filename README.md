# Acme.MarsColonizer
A TDD lab/exercise loosely based on Roy Osherove's TDD Kata and the Terraforming Mars boardgame by Fryxgames.

The lab is divided into 4 separate generations, which introduce new requirements and further the terraforming efforts on Mars. The idea is that each generation is only revealed upon the successful completion of the previous generation (no peeking). This simulates the concept of requirements evolving and refining over time, rather than being completely finished up-front before any development effort has begun.

## Recommended setup
If using Visual Studio, setting the Test Explorer to "Show Test Hierarchy" gives a clear separation of unit tests and acceptance tests.
Note that some files contain multiple classes and/or have unconventional namespaces. This is purely for presentational purposes to make it easier to follow what's happening on the screen when in a mobbing session. Refactoring is strongly encouraged when deemed necessary.

## Generation 1
The terraforming effort has just started. Our engineers need to be able to raise temperature by crashing asteroids into the atmosphere, introduce oxygen into the atmosphere by constructing greeneries and secure water supplies by pumping up water from beneath the planet's surface.

*Training opportunities:*
- Writing (and naming) tests
- Running tests
- Getting into the Red-Green-Refactor cycle

## Generation 2
The terraforming effort is gaining momentum, and we need to effectivise it by combining multiple terraforming directives into longer sequences. Meanwhile, our colonists are in intense training on earth.

*Training opportunities:*
- Dealing with code duplication as the number of unit tests grow, e.g. using xUnit Theories and introducing helper methods. 
- Refactoring code and tests to handle new requirements. Should the new behavior be added to the existing method or be expressed as a brand new method/class?

## Generation 3
Several separate organizations have established their presence on Mars and we need to coordinate the terraforming processes regardless of petty details like data formats and divergent standards.

*Training opportunities:*
- More code duplication hell
- Emphasizing the "Refactor" part of the TDD cycle

## Generation 4
The terraforming of Mars is now nearing completion, and the first colonists are ready to hit the ground as soon as all critical parameters are within the acceptable range.
