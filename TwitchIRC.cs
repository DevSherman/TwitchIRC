using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchIRC
{
    private readonly CustomSocket socket;

    private readonly string CHANNEL_NAME;
    private readonly string OAUTH_TOKEN;

    private IRCData currentData;

    public event EventHandler<IRCData> DataAvailable;

    public TwitchIRC(string CHANNEL_NAME, string OAUTH_TOKEN)
    {
        this.CHANNEL_NAME = CHANNEL_NAME;
        this.OAUTH_TOKEN = OAUTH_TOKEN;

        socket = new CustomSocket("irc.chat.twitch.tv", 6667);
        Connect();
    }

    public void Thread_Tick()
    {
        if (socket.Available())
        {
            currentData = Read();
            if (currentData.user != null && currentData.msg != null)
            {
                DataAvailable.Invoke(this, currentData);
            }
        }
    }

    private void Connect()
    {
        socket.WriteLine("PASS " + OAUTH_TOKEN);
        socket.WriteLine("NICK " + CHANNEL_NAME); //chatbot 
        socket.WriteLine("USER " + CHANNEL_NAME + " 8 * :" + CHANNEL_NAME); //chatbot
        socket.WriteLine("JOIN #" + CHANNEL_NAME);
        SendIRC("CAP REQ :twitch.tv/tags");

        socket.FlushWriter();


        SendMessage("[Game connected]");
    }

    public IRCData Read()
    {
        var result = socket.ReadLine();
        
        if(result == "PING :tmi.twitch.tv")
        {
            SendIRC("PONG :tmi.twitch.tv");
            return new IRCData(null, null, result);
        }

        if (result.Contains("PRIVMSG"))
        {
            string[] tags = Extensions.GetValuesBetween(result, "", ";").Split(';');
            string display_name = Extensions.GetValuesContain(tags[4], "display-name=");
            string message_tag = "PRIVMSG #" + display_name.ToLower() + " :";
            string message = Extensions.SplitToEnd(result, message_tag);

            return new IRCData(tags, display_name, message);
        }
        else
        {
            return new IRCData(null, null, result);
        }
    }
    public void SendIRC(string message)
    {
        try
        {
            socket.WriteLine(message);
            socket.FlushWriter();
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
    public void SendMessage(string message)
    {
        try
        {
            SendIRC(":" + CHANNEL_NAME + "!" + CHANNEL_NAME + "@" + CHANNEL_NAME +
            ".tmi.twitch.tv PRIVMSG #" + CHANNEL_NAME + " :" + message); //chatbot
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
