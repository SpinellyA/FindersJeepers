using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;

public class LocationDetailViewModel
{
    private readonly HttpClient _http;

    public LocationDetail? Location { get; private set; }
    public List<BreadcrumbItem> Breadcrumbs { get; private set; } = [];
    public bool IsLoading => Location is null;

    public LocationDetailViewModel(HttpClient http)
    {
        _http = http;
    }

    public async Task LoadAsync(int id)
    {
        Location = await _http.GetFromJsonAsync<LocationDetail>($"/api/v1/locations/{id}");

        if (Location is not null)
        {
            Breadcrumbs =
            [
                new BreadcrumbItem("Locations", href: "/locations"),
                new BreadcrumbItem(Location.Name, href: null, disabled: true)
            ];
        }
    }
}