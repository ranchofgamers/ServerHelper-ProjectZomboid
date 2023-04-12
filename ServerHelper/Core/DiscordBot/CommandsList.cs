using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServerHelper.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ServerHelper.Core.DiscordBot.Commands
{
    public class CommandsList
    {
        public List<ICommand> Commands { get; private set; }
        public string JsonFilePath { get; private set; }
        private string dataDirectory = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{Settings.Default.DataFolder}\\BotSettings";

        public CommandsList(string filename)
        {
            if (!Directory.Exists(dataDirectory))
                Directory.CreateDirectory(dataDirectory);

            filename = $"{dataDirectory}\\{filename}_CommandsList.json";
            JsonFilePath = filename;

            if (!File.Exists(JsonFilePath))
                File.Create(JsonFilePath).Close();

            DeserializeCommandsFromJson();
        }
        public void DeserializeCommandsFromJson()
        {
            Commands = new List<ICommand>();

            try
            {
                string json = File.ReadAllText(JsonFilePath);
                var commands = JArray.Parse(json);
                foreach (JObject command in commands)
                {
                    foreach (KeyValuePair<string, JToken> com in command)
                    {
                        try
                        {
                            var comTypeName = com.Key;
                            var prefix = (string)com.Value["Prefix"];
                            var name = (string)com.Value["Name"];
                            var description = (string)com.Value["Description"];
                            var channelIds = (com.Value["ChannelIds"] as JArray)?.ToObject<ulong[]>();
                            var roles = (com.Value["Roles"] as JArray)?.ToObject<string[]>();
                            var RunFromChat = (bool)com.Value["RunFromChat"];
                            var RunFromCode = (bool)com.Value["RunFromCode"];

                            if (channelIds?.Length == 0)
                                channelIds = null;

                            if (roles?.Length == 0)
                                roles = null;

                            var commandType = Type.GetType(comTypeName);
                            if (commandType == null)
                                continue;

                            if (!typeof(ICommand).IsAssignableFrom(commandType))
                                continue;

                            var currentCommand = Activator.CreateInstance(commandType, true) as ICommand;
                            currentCommand.Config = new CommandConfig(prefix, name, description, channelIds, roles, RunFromChat, RunFromCode);
                            Commands.Add(currentCommand);
                        }
                        catch (Exception) { continue; }
                    }
                }
            }
            catch (Exception) { }
        }
    }
}