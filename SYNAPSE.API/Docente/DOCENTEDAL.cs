using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using SYNAPSE.API.Model;

namespace SYNAPSE.API.Docente
{
    public class DOCENTEDAL
    {
        public OracleDataReader ConsultarDocentes(OracleConnection con)
        {
            OracleCommand cmd = new();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT 
                                    MATRICULA,
                                    NOME,
                                    EMAIL,
                                    SENHA,
                                    CPF,
                                    ENDERECO,
                                    NUMERO,
                                    BAIRRO,
                                    CEP,
                                    FLAG_FUNC,
                                    TELEFONE,
                                    CELULAR,
                                    WHATSAPP
                                FROM
                                    DOCENTE";
            try
            {
                return cmd.ExecuteReader();            
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public void InserirDocentes(OracleConnection con, DocenteModel docente)
        {
            OracleCommand cmd = new();
            cmd.Connection = con;

            cmd.CommandText = @"INSERT INTO DOCENTE(
                                                MATRICULA,
                                                NOME,
                                                EMAIL,
                                                SENHA,
                                                CPF,
                                                ENDERECO,
                                                NUMERO,
                                                BAIRRO,
                                                CEP,
                                                FLAG_FUNC,
                                                TELEFONE,
                                                CELULAR,
                                                WHATSAPP)
                                            VALUES(
                                                :Matricula,
                                                :Nome,
                                                :Email,
                                                :Senha,
                                                :Cpf,
                                                :Endereco,
                                                :Numero,
                                                :Bairro,
                                                :Cep,
                                                :Flag_func,
                                                :Telefone,
                                                :Celular,
                                                :Whatsapp)";

            cmd.Parameters.Add(new OracleParameter("Matricula", docente.MATRICULA));
            cmd.Parameters.Add(new OracleParameter("Nome", docente.NOME));
            cmd.Parameters.Add(new OracleParameter("Email", docente.EMAIL));
            cmd.Parameters.Add(new OracleParameter("Senha", docente.SENHA));
            cmd.Parameters.Add(new OracleParameter("Cpf", docente.CPF));  
            cmd.Parameters.Add(new OracleParameter("Endereco", docente.ENDERECO));
            cmd.Parameters.Add(new OracleParameter("Numero", docente.NUMERO));
            cmd.Parameters.Add(new OracleParameter("Bairro", docente.BAIRRO));
            cmd.Parameters.Add(new OracleParameter("Cep", docente.CEP));
            cmd.Parameters.Add(new OracleParameter("Flag_func", docente.FLAG_FUNC));  
            cmd.Parameters.Add(new OracleParameter("Telefone", docente.TELEFONE));
            cmd.Parameters.Add(new OracleParameter("Celular", docente.CELULAR));
            cmd.Parameters.Add(new OracleParameter("Whatsapp", docente.WHATSAPP));

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public void DeletarDoncente(OracleConnection con, int matricula)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = @"DELETE FROM
                                        DOCENTE
                                       WHERE
                                        MATRICULA = :matricula";

            cmd.Parameters.Add("id", matricula);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public void Login(OracleConnection con, Login login)
        {
            OracleCommand cmd = new();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT 
                                    MATRICULA,
                                    SENHA
                                FROM 
                                    DOCENTE
                                WHERE
                                    MATRICULA = :matricula
                                AND
                                    SENHA = :senha";


            cmd.Parameters.Add(new OracleParameter("matricula", login.MATRICULA));
            cmd.Parameters.Add(new OracleParameter("senha", login.SENHA));
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public OracleDataReader buscarDocente(OracleConnection con, int matricula)
        {
            OracleCommand cmd = new();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT 
                                    MATRICULA,
                                    NOME,
                                    EMAIL,
                                    SENHA,
                                    CPF,
                                    ENDERECO,
                                    NUMERO,
                                    BAIRRO,
                                    CEP,
                                    FLAG_FUNC,
                                    TELEFONE,
                                    CELULAR,
                                    WHATSAPP
                                FROM
                                    DOCENTE
                                WHERE MATRICULA = :matricula";

            cmd.Parameters.Add(new OracleParameter("matricula", matricula));
            try
            {
                return cmd.ExecuteReader();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
            }
        }
    }
}