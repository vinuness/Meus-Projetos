using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using SYNAPSE.API.Model;
using SYNAPSE.API.Utilidade;

namespace SYNAPSE.API.Docente
{
    public class DOCENTEBLL
    {
        public void InserirDocente(DocenteModel docente)
        {
            DOCENTEDAL docdal = new();
            using (OracleConnection con = Connection.GetConnection())
            {
                try
                {
                    con.Open();
                    docdal?.InserirDocentes(con, docente);
                }
                catch
                {
                    throw;
                }
            }
        }
        public List<DocenteModel> ListarDocentes()
        {
            DOCENTEDAL docdal = new();
            OracleConnection con = Connection.GetConnection();
            con.Open();
            OracleDataReader reader = docdal.ConsultarDocentes(con);

            List <DocenteModel> docentes = new List<DocenteModel>();
            while (reader.Read())
            {
                DocenteModel docente = new DocenteModel
                {
                    MATRICULA = Convert.ToInt32(reader["MATRICULA"].ToString()),
                    NOME = reader["NOME"].ToString(),
                    EMAIL = reader["EMAIL"].ToString(),
                    SENHA = reader["SENHA"].ToString(),
                    CPF = Convert.ToInt32(reader["CPF"].ToString()),
                    ENDERECO = reader["ENDERECO"].ToString(),
                    NUMERO = Convert.ToInt32(reader["NUMERO"].ToString()),
                    BAIRRO = reader["BAIRRO"].ToString(),
                    CEP = Convert.ToInt32(reader["CEP"].ToString()),
                    FLAG_FUNC = Convert.ToChar(reader["FLAG_FUNC"]),
                    TELEFONE = reader["TELEFONE"].ToString(),
                    CELULAR = reader["CELULAR"].ToString(),
                    WHATSAPP = reader["WHATSAPP"].ToString(),
                };
                docentes.Add(docente);
            }
            return docentes;
        }

        public void DeletarDoncente(int matricula)
        {
            DOCENTEDAL dal = new();
            OracleConnection con = Connection.GetConnection();
            try
            {
                con.Open();
                dal.DeletarDoncente(con, matricula);
            }
            catch
            {
                throw;
            }
        }

        public void Login(Login login)
        {
            DOCENTEDAL dal = new();
            OracleConnection con = Connection.GetConnection();

            try
            {

                con.Open();
                dal.Login(con, login);
            }
            catch
            {
                throw;
            }
        }

    }
}
