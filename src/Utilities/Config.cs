using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrisMyAss.Utilities
{
    public class Config
    {
        public static string GetVariable(string variable)
        {
            string processVal = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
            string userVal = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.User);
            string systemVal = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);

            string val = null;
            if (!string.IsNullOrWhiteSpace(processVal))
                val = processVal;

            if (val is null && !string.IsNullOrWhiteSpace(userVal))
                val = userVal;

            if (val is null && !string.IsNullOrWhiteSpace(systemVal))
                val = systemVal;

            return val;
        }

        public static string GetDiscordBotToken()
        {
            return GetVariable("discord_bot_krismyass_token");
        }

        public static string GetStorageLocation()
        {
            return GetVariable("discord_bot_krismyass_storage_path");
        }
    }
}
