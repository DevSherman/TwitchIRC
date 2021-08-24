using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TAGS
{
    badge_info = 0,
    badges = 1,
    client_nonce = 2,
    color = 3,
    display_name = 4,
    emotes = 5,
    flags = 6,
    id = 7,
    mod = 8,
    room_id = 9,
    subscriber = 10,
    tmi_sent_ts = 11,
    turbo = 12,
    user_id = 13,
    user_type = 14
};
public class IRCData
{
    public IRCData(string[] tags, string user, string msg)
    {
        this.tags = tags;
        this.user = user;
        this.msg = msg;
    }
    public readonly string[] tags;
    public readonly string user;
    public readonly string msg;
    public string GetTag(TAGS tag)
    {
        return tag switch
        {
            TAGS.badge_info => Extensions.GetValuesContain(tags[0], "@badge-info="),
            TAGS.badges => Extensions.GetValuesContain(tags[1], "badges="),
            TAGS.client_nonce => Extensions.GetValuesContain(tags[2], "client-nonce="),
            TAGS.color => Extensions.GetValuesContain(tags[3], "color="),
            TAGS.display_name => Extensions.GetValuesContain(tags[4], "display-name="),
            TAGS.emotes => Extensions.GetValuesContain(tags[5], "emotes="),
            TAGS.flags => Extensions.GetValuesContain(tags[6], "flags="),
            TAGS.id => Extensions.GetValuesContain(tags[7], "id="),
            TAGS.mod => Extensions.GetValuesContain(tags[8], "mod="),
            TAGS.room_id => Extensions.GetValuesContain(tags[9], "room-id="),
            TAGS.subscriber => Extensions.GetValuesContain(tags[10], "subscriber="),
            TAGS.tmi_sent_ts => Extensions.GetValuesContain(tags[11], "tmi-sent-ts="),
            TAGS.turbo => Extensions.GetValuesContain(tags[12], "turbo="),
            TAGS.user_id => Extensions.GetValuesContain(tags[13], "user-id="),
            TAGS.user_type => Extensions.GetValuesContain(tags[14], "user-type="),
            _ => null,
        };
    }
}
