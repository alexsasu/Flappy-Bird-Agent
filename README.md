# Flappy-Bird-Agent

Group project for the Introduction to Reinforcement Learning course, taken in the 3rd year at the Faculty of Mathematics and Computer Science, University of Bucharest.

The project implements in Unity a reinforcement learning agent for a game similar to Flappy Bird. Given that for each run of the game, the environment would be procedurally generated, the agent was trained using an on-policy algorithm, namely the **PPO (Proximal Policy Optimization) algorithm**. The project makes use of multiple elements from the **ML-Agents** Unity package, including the "Ray Perception Sensor 2D" component, which, through the help of multiple rays drawn from the agent, takes in observations about the environment, such as: the space available for moving, obstacles, the space between pipes that increases the agent's score.

In order to reward the agent, 0.1 points were given to it for every second it survived, and in order to penalize it, 1 point was substracted each time it hit an obstacle.

The project combines elements from [this repo](https://github.com/zigurous/unity-flappy-bird-tutorial) (for the graphical part), as well as [this video](https://www.youtube.com/watch?v=ToMCmHQocSA&ab_channel=DapperDino) (for the RL part).

<details>
<summary><h3>Showcase 🎥:</h3></summary>

![Unity_bR5Y3z36sT](https://github.com/alexsasu/Flappy-Bird-Agent/assets/87432371/6e83cd2b-5247-4c98-b63b-7ea77f4afa86)
</details>

Contributors:
- Adania Miu (https://github.com/adania-miu/)
- Alexandru Sasu (https://github.com/alexsasu/)
- Filip Constantin (https://github.com/filipdamian/)
