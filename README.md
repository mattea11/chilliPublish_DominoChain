# Domino Circular Chain

## Description of the problem
This program solves the "Circular Domino Chain" challenge. It generates a random set of dominoes and attempts to order them into a valid circular chain. 

A circular domino chain is valid if:
    1. The dots on one half of a domino match the dots on the neighboring half of the adjacent domino.
    2. The chain forms a circle, meaning the dots on the first half of the first domino match the dots on the second half of the last domino.

If a circular chain is not possible, the program indicates such.


## My implementation assumes the following
1. There is no limit to the length of the chains to be generated

##A case was implemnted for when a
1. domino may be flipped in order to create the chain
2. domino cannot be flipped


## Why I implemneted it the way I did