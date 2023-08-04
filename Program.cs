
using System.Text;

await sendMessajeAsync();


async Task sendMessajeAsync()
{
    // URL de la API de Facebook Graph
    string url = "https://graph.facebook.com/v17.0/114513071716223/messages";

    // Token de acceso
    string accessToken = "EAAESZAgL1u0IBAAyZAqJ0Pzqr0xkNpWQMfgkgrFyvXeBQnDfNlMWSpEtxwUABQnxaIrUwQwNFv3mGTtUpOTT5BUV7YeslYnpm45ZAewFSFJNzEFqPeeCfdfrqmz4C06DZCAZBMyEntsZBZCfQAAV6jlJnFLx0pdqZCTpHZB7JQboHaCc3MTWTtSQ4ZAx4lQBdbjj2Dvhml8fCJTQZDZD";

    // Crear el cliente HttpClient
    using (HttpClient client = new HttpClient())
    {
        // Configurar el encabezado de autorización
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

        // Configurar el encabezado Content-Type
        //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

        // Crear el contenido JSON para el cuerpo de la solicitud
        string jsonBody = "{\"messaging_product\": \"whatsapp\", \"to\": \"542291467079\", \"type\": \"template\", "+
        "\"template\": { \"name\": \"reserva\", "+
        // El array de components contiene las varialbes del template
        "\"components\": [ { \"type\": \"body\", \"parameters\": [ { \"type\": \"text\", \"text\": \"Nombre de usuario\" } ] } ]"+
         "} }";

        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Realizar la solicitud POST a la API de Facebook Graph
        HttpResponseMessage response = await client.PostAsync(url, content);

        // Leer la respuesta del servidor
        string responseContent = await response.Content.ReadAsStringAsync();

        // Mostrar la respuesta en la consola
        Console.WriteLine("Respuesta del servidor:");
        Console.WriteLine(responseContent);
    }
}
