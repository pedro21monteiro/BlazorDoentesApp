using Models;
using Models.CustomModels;


namespace BlazorDoentesApp.Services
{
    public class DoentesService : IDoenteService
    {
        private readonly HttpClient httpClient;

        public DoentesService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<TbDoente>> GetDoentes()
        {
            return await httpClient.GetFromJsonAsync<List<TbDoente>>("api/Doente/GetDoentes");
        }

        public async Task<ResponseModel> AddDoente(TbDoente _doente)
        {
            var response = await httpClient.PostAsJsonAsync("api/Doente/AddDoente", _doente);
            return await response.Content.ReadFromJsonAsync<ResponseModel>();
        }

        public async Task<ResponseModel> UpdateDoente(TbDoente _doente)
        {
            var response = await httpClient.PostAsJsonAsync("api/Doente/UpdateDoente", _doente);
            return await response.Content.ReadFromJsonAsync<ResponseModel>();
        }

        public async Task<ResponseModel> DeleteDoente(int doenteId)
        {
            return await httpClient.GetFromJsonAsync<ResponseModel>("api/Doente/DeleteDoente/?doenteId=" + doenteId);
        }

        public async Task<ResponseModel> GetDoente(int doenteId)
        {
            return await httpClient.GetFromJsonAsync<ResponseModel>("api/Doente/GetDoente/?doenteId=" + doenteId);
        }

    }
}
