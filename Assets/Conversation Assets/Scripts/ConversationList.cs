using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ConversationList : MonoBehaviour
{
    List<Conversation> convoList = new List<Conversation>();

    void Start()
    {
        //PopulateList();
        /*PopulateListM();
        PopulateListC();
        PopulateListS();
        PopulateListF();
        PopulateListI();*/
    }

    /*void PopulateListM()
    {
        string[] assetNames = AssetDatabase.FindAssets("Convo", new[] { "Assets/Conversation Assets/Conversations" });
        convoList.Clear();
        foreach (string Convo in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(Convo);
            var conversation = AssetDatabase.LoadAssetAtPath<Conversation>(SOpath);
            convoList.Add(conversation);
            conversation.alreadyhasitem = false;
        }
    }*/
    /*void PopulateList()
    {
        string[] assetNames = Resources.Load<Conversation>("Convo", new[] { "Assets/Conversation Assets/Conversations" });
        convoList.Clear();
        foreach (string Convo in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(Convo);
            var conversation = AssetDatabase.LoadAssetAtPath<Conversation>(SOpath);
            convoList.Add(conversation);
            conversation.alreadyhasitem = false;
        }
    }*/
    /*void PopulateListC()
    {
        string[] assetNames = AssetDatabase.FindAssets("Convo", new[] { "Assets/Conversation Assets/Conversations/Clem Conversations" });
        convoList.Clear();
        foreach (string Convo in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(Convo);
            var conversation = AssetDatabase.LoadAssetAtPath<Conversation>(SOpath);
            convoList.Add(conversation);
            conversation.alreadyhasitem = false;
        }
    }
    void PopulateListS()
    {
        string[] assetNames = AssetDatabase.FindAssets("Convo", new[] { "Assets/Conversation Assets/Conversations/Dr. ShrinkRay Conversations" });
        convoList.Clear();
        foreach (string Convo in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(Convo);
            var conversation = AssetDatabase.LoadAssetAtPath<Conversation>(SOpath);
            convoList.Add(conversation);
            conversation.alreadyhasitem = false;
        }
    }
    void PopulateListF()
    {
        string[] assetNames = AssetDatabase.FindAssets("Convo", new[] { "Assets/Conversation Assets/Conversations/Fly McMarty Conversations" });
        convoList.Clear();
        foreach (string Convo in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(Convo);
            var conversation = AssetDatabase.LoadAssetAtPath<Conversation>(SOpath);
            convoList.Add(conversation);
            conversation.alreadyhasitem = false;
        }
    }
    void PopulateListI()
    {
        string[] assetNames = AssetDatabase.FindAssets("Convo", new[] { "Assets/Conversation Assets/Conversations/Flavor Text and Item Conversations/Clem's House Convos" });
        convoList.Clear();
        foreach (string Convo in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(Convo);
            var conversation = AssetDatabase.LoadAssetAtPath<Conversation>(SOpath);
            convoList.Add(conversation);
            conversation.alreadyhasitem = false;
        }
    }*/
}
