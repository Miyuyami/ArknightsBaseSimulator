using System;
using System.Net.Http;
using System.Threading.Tasks;
using Arknights.Data;

namespace Arknights.BaseSimulator.Data
{
    public class GameService
    {
        public BaseData BaseData { get; private set; }
        private HttpClient HttpClient { get; }

        public GameService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        public async Task InitAsync(string url)
        {
            string jsonString = await this.HttpClient.GetStringAsync(url);

            this.BaseData = BaseData.FromJson(jsonString);
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
