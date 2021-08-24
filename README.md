# TwitchIRC
Library to connect to twitch chat, ready to use with unity (other implementations can be done easily)

USE in Unity:
```
public string channel_name;
public string oauth; //https://twitchapps.com/tmi/
private TwitchIRC IRC;
private void Start()
{
    IRC = new TwitchIRC(channel_name, oauth);
    IRC.DataAvailable += IRC_DataAvailable;
}
private void IRC_DataAvailable(object sender, IRCData e)
{
    //e.user
    //e.msg
    //e.GetTag(TAGS.color)
}
private void Update()
{
    IRC.Thread_Tick();
}
```
