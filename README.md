# SimplePongYonatan

This is a very simple implementation of the 'Pong' game loop - the score is capped at 3 and there are no main menu interactions or anything like that.

## Description
At the start of the game the ball 'randomly' chooses one of four directions to go in and will change directions upon hitting paddles and walls like you would expect in the game pong,
whenever the ball reaches a scoring area it will reset it's position and choose a new random direction (out of 4). </br>
the game is currently set to end at 3 points for a player and does not have a reset method yet. </br>
players move the left paddle with W=Up and S=Down, and the right paddle with the Up and Down arrows keys. </br>
each score area trigger also implements a bool guard which is only released after a coroutine waits for 1 second - this had to be added so the trigger effect wont occur twice or more before the ball can resets it's position.

## Code Highlights
1. Score Area implements guard (false by default) which is only relesed by a coroutine after 1 second whenever a 'ball' triggers the event. </br>
![image](https://github.com/HolyTrie/SimplePongYonatan/assets/73063105/044ad618-388a-49e8-8d26-e5844c93687e)

2. Ball uses switch/match expressions and is otherwise as simple as can be - also FixedUpdate for physiscs instead of Update! </br>
![image](https://github.com/HolyTrie/SimplePongYonatan/assets/73063105/6858f6ec-9b48-4eaf-ab8c-176bff87200b)
