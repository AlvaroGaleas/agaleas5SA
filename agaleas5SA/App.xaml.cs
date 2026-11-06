using agaleas5SA.Repositories;

namespace agaleas5SA;

public partial class App : Application
{
    public static PersonRepository personRepo { get; set; } = null!;

    public App(PersonRepository personRepository)
    {
        InitializeComponent();
        personRepo = personRepository;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new Views.vPersona());
    }
}