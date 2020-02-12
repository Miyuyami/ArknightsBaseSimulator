using System;
using System.Net.Http;
using System.Threading.Tasks;
using Arknights.Data;

namespace Arknights.BaseSimulator.Data
{
    public class GameService
    {
        public BaseData BaseData { get; private set; }
        public ItemTable ItemTable { get; private set; }
        private HttpClient HttpClient { get; }

        public GameService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        public async Task InitAsync(string baseDataUrl, string itemTableUrl)
        {
            string baseDataJsonString = await this.HttpClient.GetStringAsync(baseDataUrl);
            this.BaseData = BaseData.FromJson(baseDataJsonString);

            string itemTableJsonString = await this.HttpClient.GetStringAsync(itemTableUrl);
            this.ItemTable = ItemTable.FromJson(itemTableJsonString);
        }

        public Game CreateGame(string value = null)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return new Game(new SaveData(), this.BaseData, this.ItemTable);
            }

            return this.Deserialize(value);
        }

        public Game Deserialize(string value)
        {
            var json = value;

            return new Game(SaveData.FromJson(json), this.BaseData, this.ItemTable);
        }

        public string Serialize(Game game)
        {
            var json = Data.Serialize.ToJson(game.SaveData);

            return json;
        }
    }
}
