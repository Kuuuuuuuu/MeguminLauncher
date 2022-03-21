using System;
using DiscordRPC;

namespace Megumin
{
    public class RichPresence
    {
        // all code in here from onix launcher but some have been edited some of it
        private readonly string _discordTime = "";
        public DiscordRpcClient Client;

        public RichPresence()
        {
            Client = new DiscordRpcClient("912006573503688804");
            var TimestampStart = 0;
            var TimestampEnd = 0;
            dynamic dateTimestampEnd = null;

            if (_discordTime != "" && int.TryParse(_discordTime, out TimestampEnd))
                dateTimestampEnd = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(TimestampEnd);

            Client.Initialize();
            Client.SetPresence(new DiscordRPC.RichPresence
            {
                Details = "In Launcher",

                Assets = new Assets
                {
                    LargeImageKey = "megumin",
                    LargeImageText = "Megumin"
                },
                Buttons = new[]
                {
                    new Button {Label = "Discord", Url = "https://discord.gg/pPUEYm9N9P"},
                    new Button {Label = "Github", Url = "https://github.com/KohakuChanX"}
                },

                Timestamps = new Timestamps
                {
                    Start = _discordTime != "" && int.TryParse(_discordTime, out TimestampStart)
                        ? new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                            .AddSeconds(TimestampStart)
                        : DateTime.UtcNow,
                    End = dateTimestampEnd
                }
            });
        }

        public void ChangePresence(string server, string gamertag, bool privatemode)
        {
            var TimestampStart = 0;
            var TimestampEnd = 0;
            dynamic dateTimestampEnd = null;

            if (_discordTime != "" && int.TryParse(_discordTime, out TimestampEnd))
                dateTimestampEnd = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(TimestampEnd);

            if (privatemode)
            {
                server = "Private Mode";
                gamertag = "Private Mode";
            }

            Client.SetPresence(new DiscordRPC.RichPresence
            {
                Details = server ?? "IDK SERVER",

                State = "as " + gamertag,

                Assets = new Assets
                {
                    LargeImageKey = "megumin",
                    LargeImageText = "Megumin"
                },

                Buttons = new[]
                {
                    new Button {Label = "Discord", Url = "https://discord.gg/pPUEYm9N9P"},
                    new Button {Label = "Github", Url = "https://github.com/KohakuChanX"}
                },


                Timestamps = new Timestamps
                {
                    Start = _discordTime != "" && int.TryParse(_discordTime, out TimestampStart)
                        ? new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                            .AddSeconds(TimestampStart)
                        : DateTime.UtcNow,
                    End = dateTimestampEnd
                }
            });
        }

        public void ResetPresence()
        {
            var TimestampStart = 0;
            var TimestampEnd = 0;
            dynamic dateTimestampEnd = null;

            if (_discordTime != "" && int.TryParse(_discordTime, out TimestampEnd))
                dateTimestampEnd = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(TimestampEnd);

            Client.SetPresence(new DiscordRPC.RichPresence
            {
                Details = "In Launcher",

                Assets = new Assets
                {
                    LargeImageKey = "megumin",
                    LargeImageText = "Megumin"
                },

                Buttons = new[]
                {
                    new Button {Label = "Discord", Url = "https://discord.gg/pPUEYm9N9P"},
                    new Button {Label = "Github", Url = "https://github.com/KohakuChanX"}
                },

                Timestamps = new Timestamps
                {
                    Start = _discordTime != "" && int.TryParse(_discordTime, out TimestampStart)
                        ? new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                            .AddSeconds(TimestampStart)
                        : DateTime.UtcNow,
                    End = dateTimestampEnd
                }
            });
        }
    }
}