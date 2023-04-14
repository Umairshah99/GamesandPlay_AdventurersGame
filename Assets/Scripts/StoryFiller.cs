using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class StoryNode
{
    public string History;
    public string[] Answers;
    public bool IsFinal;
    public StoryNode[] NextNode;
    public Action OnNodeVisited;
}

public static class StoryFiller
{
    public static StoryNode FillStory()
    {
        // Initialization Code.
        StoryNode beginning = createNode(
            "You are at a crossroad. How did you get here again?",
            new [] {"Go left", "Go right"}
        );

        StoryNode wentRightLol = createNode(
            "You reach a dead end with a sign \"Dead End\". How convenient.",
            new [] {"Go back and go left"}
        );

        StoryNode catChoice1  = createNode(
            "Why are you here again? Oh look. A cat on the dirt-paved road. What do you say to it?",
            new [] {"Meow", "Meow?"}
        );

        StoryNode catChoice2  = createNode(
            "The cat replies: Meow",
            new [] {"Meow"}
        );

        StoryNode catChoice3  = createNode(
            "Meow Meow",
            new [] {"Meow Meow Meow"}
        );

        StoryNode catChoice4  = createNode(
            "Meowwww",
            new [] {"Meow Meow, Meow?"}
        );

        StoryNode catChoice5  = createNode(
            "Meow Meow",
            new [] {"Meeeooooow"}
        );

        StoryNode catConclusion1 = createNode(
            "The cat walks away. Did you just ... talk to a cat?",
            new [] {"Yup!"}
        );

        StoryNode catConclusion2 = createNode(
            "... What did it say?",
            new [] {"Meow"}
        );

        StoryNode catConclusion3 = createNode(
            "...",
            new [] {"It told me I was late for class actually"}
        );

        StoryNode narratorIsTired = createNode(
            "I am done actually, please end the game",
            new [] {"End Game", "No"}
        );

        StoryNode fakeEndGame = createNode(
            "The cat comes back and slaps you, and you forget what you were going to do. Great. Lets go to class.",
            new [] {"Meow?"}
        );

        StoryNode actualEnd = createNode(
            "I hate you. You then went to class. Hooray.",
            new string[] {"Hooray!"}
        );


        beginning.NextNode[0] = catChoice1;
        beginning.NextNode[1] = wentRightLol;

        wentRightLol.NextNode[0] = catChoice1;

        catChoice1.NextNode[0] = catChoice2;
        catChoice1.NextNode[1] = catChoice2;
        catChoice2.NextNode[0] = catChoice3;
        catChoice3.NextNode[0] = catChoice4;
        catChoice4.NextNode[0] = catChoice5;

        catChoice5.NextNode[0] = catConclusion1;
        catConclusion1.NextNode[0] = catConclusion2;
        catConclusion2.NextNode[0] = catConclusion3;
        catConclusion3.NextNode[0] = narratorIsTired;

        narratorIsTired.NextNode[0] = fakeEndGame;
        narratorIsTired.NextNode[1] = actualEnd;
        fakeEndGame.NextNode[0] = actualEnd;

        actualEnd.IsFinal = true;

        return beginning;
    }


    public static StoryNode createNode(string history, string[] options){
        return new StoryNode
        {
            History = history,
            Answers = options,
            NextNode = new StoryNode[options.Length]
        };
    }
}
