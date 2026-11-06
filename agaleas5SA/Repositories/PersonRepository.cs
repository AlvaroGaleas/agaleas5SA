using agaleas5SA.Models;
using SQLite;

namespace agaleas5SA.Repositories;

public class PersonRepository
{
    private string _dbPath;
    private SQLiteConnection? _conn;

    public string StatusMessage { get; set; } = string.Empty;

    private void Init()
    {
        if (_conn is not null)
            return;

        _conn = new SQLiteConnection(_dbPath);
        _conn.CreateTable<Persona>();
    }

    public PersonRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void AddNewPerson(string name)
    {
        int result = 0;
        try
        {
            Init();

            if (string.IsNullOrEmpty(name))
                throw new Exception("El nombre es requerido");

            Persona person = new() { Name = name };
            result = _conn!.Insert(person);

            StatusMessage = string.Format("Filas agregadas: {0} (Nombre: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Error no se inserto " + ex.Message);
        }
    }

    public List<Persona> GetAllPeople()
    {
        try
        {
            Init();
            return _conn!.Table<Persona>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Error " + ex.Message);
        }
        return new List<Persona>();
    }

    //DELETE
    // Actividad en clase: CREACION DEL REPOSITORIO
    public void DeletePerson(int id)
    {
        int result = 0;
        try
        {
            Init();
            result = _conn!.Delete<Persona>(id);
            StatusMessage = string.Format("Filas eliminadas: {0} (ID: {1})", result, id);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Error al eliminar: " + ex.Message);
        }
    }

    //UPDATE
    // tarea semala: COMMIT: UPDATE
}