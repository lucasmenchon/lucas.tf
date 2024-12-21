using static BlazorWebProfile.Shared.ProjectsSection;
using static BlazorWebProfile.Shared.TestimonialsSection;

namespace BlazorWebProfile.Models;

public class Data
{
    public Header Header { get; set; } = new();
    public List<Education> Educations { get; set; } = new();
    public List<Experience> Experiences { get; set; } = new();
    public List<Project> Projects { get; set; } = new();
    public List<string> Skills { get; set; } = new();
    public List<Testimonial> Testimonials { get; set; } = new();
    public List<SocialLink> SocialLinks { get; set; } = new();
}
