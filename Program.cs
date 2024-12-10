using System.Data.SqlClient;

SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jimif\\Documents\\Code\\DessarrolloSoftwareIII\\Elecciones2024\\Database1.mdf;Integrated Security=True");
connection.Open();
SqlCommand cmd = connection.CreateCommand();
SqlTransaction transaction = null;
string tipoDocumentoVotante, documentoVotante, nombresVotante, apellidosVotante,
       fechaNacimientoVotante, partidoVotante, mesa, estadoVotante,

       tipoDocumentoCandidato,
       documentoCandidato, nombresCandidato, apellidosCandidato, fechaNacimientoCandidato,
       partidoCandidato, estadoCandidato;

while (true)
{
    Console.WriteLine("ELECCIONES 2024");
    Console.WriteLine();
    Console.Write("Ingrese su tipo de documento: ");
    tipoDocumentoVotante = Console.ReadLine();

    Console.Write("Ingrese su documento: ");
    documentoVotante = Console.ReadLine();

    Console.Write("Ingrese su(s) nombres: ");
    nombresVotante = Console.ReadLine();

    Console.Write("Ingrese su(s) apellidos: ");
    apellidosVotante = Console.ReadLine();

    Console.Write("Ingrese su fecha de nacimiento: ");
    fechaNacimientoVotante = Console.ReadLine();

    Console.Write("Ingrese el partido al que pertenece: ");
    partidoVotante = Console.ReadLine();

    Console.Write("Ingrese su mesa: ");
    mesa = Console.ReadLine();

    Console.Write("Ingrese su estado: ");
    estadoVotante = Console.ReadLine();



    Console.Write("Ingrese el tipo de documento del candidato: ");
    tipoDocumentoCandidato = Console.ReadLine();

    Console.Write("Ingrese el documento del candidato: ");
    documentoCandidato = Console.ReadLine();

    Console.Write("Ingrese los nombres del candidato: ");
    nombresCandidato = Console.ReadLine();

    Console.Write("Ingrese los apellidos del candidato: ");
    apellidosCandidato = Console.ReadLine();

    Console.Write("Ingrese la fecha de nacimiento del candidato: ");
    fechaNacimientoCandidato = Console.ReadLine();

    Console.Write("Ingrese el el partido del candidato: ");
    partidoCandidato = Console.ReadLine();

    Console.Write("Ingrese el estado del candidato: ");
    estadoCandidato = Console.ReadLine();

    cmd.CommandText = "ppVotos";
    cmd.CommandType = System.Data.CommandType.StoredProcedure;

    cmd.Parameters.AddWithValue("@tipoDocumento",tipoDocumentoVotante);
    cmd.Parameters.AddWithValue("@documento", documentoVotante);
    cmd.Parameters.AddWithValue("@nombres", nombresVotante);
    cmd.Parameters.AddWithValue("@apellidos", apellidosVotante);
    cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimientoVotante);
    cmd.Parameters.AddWithValue("@partido", partidoVotante);
    cmd.Parameters.AddWithValue("@mesa", mesa);
    cmd.Parameters.AddWithValue("@estado", estadoVotante);

    try
    {
        transaction = connection.BeginTransaction();
        cmd.Transaction = transaction;
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@tipoDocumento", tipoDocumentoCandidato);
        cmd.Parameters.AddWithValue("@documento", documentoCandidato);
        cmd.Parameters.AddWithValue("@nombres", nombresCandidato);
        cmd.Parameters.AddWithValue("@apellidos", apellidosCandidato);
        cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimientoCandidato);
        cmd.Parameters.AddWithValue("@partido", partidoCandidato);
        cmd.Parameters.AddWithValue("@estado", estadoVotante);
        cmd.CommandText = "ppCandidato";
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        transaction.Commit();
    }
    catch (Exception)
    {

        throw;
    }



}