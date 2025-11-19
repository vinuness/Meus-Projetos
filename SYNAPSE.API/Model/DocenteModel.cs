using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace SYNAPSE.API.Model
{
    public class DocenteModel
    {
        public int MATRICULA { get; set; }
        public string? NOME { get; set; }
        public string? EMAIL { get; set; }  
        public string? SENHA { get; set; }  
        public long CPF { get; set; }     
        public string? ENDERECO { get; set; }
        public int NUMERO { get; set; }  
        public string? BAIRRO { get; set; } 
        public int CEP { get; set; }     
        public char FLAG_FUNC { get; set; } 
        public string? TELEFONE { get; set; } 
        public string? CELULAR { get; set; }
        public string? WHATSAPP { get; set; }
    }
}
