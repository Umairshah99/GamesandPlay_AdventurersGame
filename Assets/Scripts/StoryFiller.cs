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
        StoryNode beginning = createNode(
            "Welcome to the Cricket Trivia",
            new [] {"Bowler", "Batsman"}
        );

        StoryNode chosebatsman = createNode(
            "Babar Azam is the best Batsman! No need for any Trivia.",
            new [] {"Choose a bowler instead"}
        );

        StoryNode bowlopt1  = createNode(
            "Ohh so you want the best bowler? You know Pakistani bowlers are the best",
            new [] {"Yes, Indeed", "I do not think so"}
        );

        StoryNode bowler1 = createNode(
            "It's a known fact. Anyways, do you think Shaheen Afridi is the current best?",
            new [] {"Hmmm"}
        );

        StoryNode bowler2  = createNode(
            "What's with the hmmm!!",
            new [] {"I meannn"}
        );

        StoryNode bowler3  = createNode(
            "You mean what?!!",
            new [] {"There's also Muhammad Amir, just saying."}
        );

        StoryNode bowler4  = createNode(
            "Hmmmm, that's true, not sure ...",
            new [] {"I like Shaheen more though."}
        );

        StoryNode decision1 = createNode(
            "It's difficult to decide, help me out. Have you decided who is the best?",
            new [] {"Yesss!"}
        );

        StoryNode decision2 = createNode(
            "Who?",
            new [] {"Ummm...."}
        );

        StoryNode decision3 = createNode(
            "...?",
            new [] {"Ummmmmmmmm..."}
        );

        StoryNode finalquestion = createNode(
            "Ohh comeon, just say it.",
            new [] {"Muhammad Amir", "Shaheen Afridi"}
        );


        StoryNode finalans = createNode(
            "It was just a test, Muhammad Asif is the best.",
            new string[] {":("}
        );


        beginning.NextNode[0] = bowlopt1;
        beginning.NextNode[1] = chosebatsman;

        chosebatsman.NextNode[0] = bowlopt1;

        bowlopt1.NextNode[0] = bowler1;
        bowlopt1.NextNode[1] = bowler1;

        bowler1.NextNode[0] = bowler2;
        bowler2.NextNode[0] = bowler3;
        bowler3.NextNode[0] = bowler4;
        bowler4.NextNode[0] = decision1;

        decision1.NextNode[0] = decision2;
        decision2.NextNode[0] = decision3;
        decision3.NextNode[0] = finalquestion;

        finalquestion.NextNode[0] = finalans;
        finalquestion.NextNode[1] = finalans;
        finalans.IsFinal = true;

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
