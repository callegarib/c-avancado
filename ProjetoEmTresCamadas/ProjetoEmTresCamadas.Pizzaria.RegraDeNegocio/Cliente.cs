using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio
{
    public class Cliente
    {
        //Propriedades: `Id`, `Nome`.
        public int Id { get; set; }
        public string Nome {  get; set; }

        public Cliente() 
        {
            Nome = string.Empty;
        }

        public override string ToString()
        {
            return $"Cliente: {Nome}, seu código é: {Id}";
        }





    }
}
