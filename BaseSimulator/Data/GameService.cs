using System;
using System.Text;
using Arknights.Data;

namespace Arknights.BaseSimulator.Data
{
    public class GameService
    {
        public BaseData BaseData { get; }

        public GameService(BaseData baseData)
        {
            this.BaseData = baseData;
        }

        public Game CreateGame(string value = null)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return new Game(new SaveData(), this.BaseData);
            }

            return this.Deserialize(value);
        }

        public Game Deserialize(string value)
        {
            //var json = Encoding.UTF8.GetString(Convert.FromBase64String(value));
            var json = value;

            return new Game(SaveData.FromJson(json), this.BaseData);
        }

        public string Serialize(Game game)
        {
            var json = Data.Serialize.ToJson(game.SaveData);

            return json;
            //return Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
        }
    }
}
