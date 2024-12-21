using System.Net.Http.Json;

namespace BlazorWebProfile.Services;

public class JsonDataService
{
    private readonly HttpClient _httpClient;

    public JsonDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Data> GetSiteDataAsync()
    {
        var data = new Data();

        try
        {
            // Carrega cada JSON separadamente
            data.Header = await _httpClient.GetFromJsonAsync<Header>("JsonData/header.json") ?? new Header();
            data.Educations = await _httpClient.GetFromJsonAsync<List<Education>>("JsonData/educations.json") ?? new List<Education>();
            data.Experiences = await _httpClient.GetFromJsonAsync<List<Experience>>("JsonData/experiences.json") ?? new List<Experience>();
            data.Projects = await _httpClient.GetFromJsonAsync<List<Project>>("JsonData/projects.json") ?? new List<Project>();
            data.Skills = await _httpClient.GetFromJsonAsync<List<string>>("JsonData/skills.json") ?? new List<string>();
            data.Testimonials = await _httpClient.GetFromJsonAsync<List<Testimonial>>("JsonData/testimonials.json") ?? new List<Testimonial>();
            data.SocialLinks = await _httpClient.GetFromJsonAsync<List<SocialLink>>("JsonData/socialLinks.json") ?? new List<SocialLink>();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados: {ex.Message}");
        }

        return data;
    }


}