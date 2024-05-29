using System.Net.Http.Json;

public class ServizioConversioneValuta
{
    private readonly HttpClient _httpClient;

    public ServizioConversioneValuta(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public class RispostaApiTassiDiCambio
    {
        public Dictionary<string, decimal> Tassi { get; set; }
    }

    public async Task<decimal> ConvertiValutaAsync(string valutaDa, string valutaA, decimal importo)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<RispostaApiTassiDiCambio>($"https://api.exchangeratesapi.io/latest?base={valutaDa}&symbols={valutaA}");

            if (response != null)
            {
                decimal tassoDiCambio = response.Tassi[valutaA];
                return importo * tassoDiCambio;
            }
            else
            {
                throw new Exception("Errore durante la richiesta all'API di cambio valuta.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Errore durante la conversione della valuta.", ex);
        }
    }
}
