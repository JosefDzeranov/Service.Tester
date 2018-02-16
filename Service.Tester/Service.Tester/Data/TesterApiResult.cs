using Newtonsoft.Json;

namespace Service.Tester.Data
{
    /// <summary>
    /// Обертка для результатов вызова метода tester api
    /// </summary>
    public class TesterApiResult<TResult>
    {
        [JsonProperty("data", Required = Required.AllowNull)]
        public TResult Data { get; set; }

        public TesterApiResult()
        {
        }

        public TesterApiResult(TResult data)
        {
            Data = data;
        }
    }
}