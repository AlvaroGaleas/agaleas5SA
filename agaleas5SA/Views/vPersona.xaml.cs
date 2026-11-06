using agaleas5SA.Models;

namespace agaleas5SA.Views;

public partial class vPersona : ContentPage
{
    public vPersona()
    {
        InitializeComponent();
    }

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.AddNewPerson(txtName.Text?.Trim() ?? "");
        lblStatus.Text = App.personRepo.StatusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> people = App.personRepo.GetAllPeople();
        ListaPersona.ItemsSource = people;
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personRepo.DeletePerson(id);
            lblStatus.Text = App.personRepo.StatusMessage;
            ListaPersona.ItemsSource = App.personRepo.GetAllPeople();
        }
        else
        {
            lblStatus.Text = "Ingrese un ID válido";
        }
    }
}