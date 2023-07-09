# Gutenbatch

![Gutenbatch Logo](https://cdn.discordapp.com/attachments/1127253637001908225/1127405749241389156/logo_1_gutenbatch.png) 

Gutenbatch is an open-source text-based game engine designed to create interactive stories or adventures. Whether you're a game developer looking to bring your stories to life, or a writer eager to experiment with interactive storytelling, Gutenbatch is a tool for you.

## Features

1. **Interactive Text-Based Games**: Develop and play engaging text-based games directly in the console.
2. **Customizable Stories**: Create and load your own stories using the easy-to-understand syntax.
3. **Variable Handling**: Create dynamic storylines that respond to user input.
4. **Multiple Text Types**: Display dialogues, titles, narrative text, and options in different formats.

## Getting Started

To start using Gutenbatch, follow these simple steps:

1. Clone the repository to your local machine.
2. Navigate into the Gutenbatch directory.
3. Run the Engine.cs file.

Once you run the engine, you can choose from one of the three options: Load Story, Create Story, or Edit Story.

## File Structure

The engine consists of the following five files:

- **Engine.cs**: The main driver of the program, which presents options to load, create, or edit a story.
- **TextType.cs**: Defines the various types of text that can be used in a story.
- **Functions.cs**: Contains utility functions used throughout the engine, such as text input, display, and variable handling.
- **Gutenberg.cs**: Handles story creation and editing, with options to add titles, dialogue, text, and input.
- **StoryLoader.cs**: Loads and processes story files, replacing variables with user input and displaying the text to the user.

## How to Create a Story

Creating a story is as simple as selecting the "Create Story" option in the main menu. You will be prompted to enter a title for your story. If a story with the same title does not already exist, an empty story file will be created.

From there, you can add various elements to your story:

1. **Title**: Enter the title of your story.
2. **Dialogue**: Add characters' dialogues to make your story more interactive.
3. **Text**: Write narrative text to describe situations, settings, or actions.
4. **Input**: Define points where the user needs to make a decision or input a response.

## How to Load a Story

To load a story, select the "Load Story" option in the main menu and enter the name of your story file. Make sure your `.story` file is located in the `stories` folder of your project directory.

## Contributing

We welcome contributions from the community! Please feel free to submit a pull request or create an issue if you have any improvements or suggestions.

## License

Gutenbatch is released under the MIT License. See `LICENSE` for more details.
