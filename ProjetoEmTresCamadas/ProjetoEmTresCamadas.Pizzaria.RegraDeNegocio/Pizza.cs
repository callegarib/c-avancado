using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio
{
    public enum TamanhoDePizza
    {
        Pequena = 0,
        Media = 1,
        Grande = 2
    }
    public class Pizza
    {
        public string Sabor { get; set; }

        public TamanhoDePizza TamanhoDePizza { get; set; }
        public string Descricao { get; set; }

        public Pizza()
        {

        }

        public Pizza CriarPizza
            (string sabor, TamanhoDePizza tamanhoDePizza, string descricao = "")
        {
            Sabor = sabor;
            TamanhoDePizza = tamanhoDePizza;
            if (string.IsNullOrEmpty(descricao))
            {
                Descricao = descricao;
            }
            return this;
        }

        public string DefinirSabor(string sabor)
        {
            if (sabor == "C")
            {
                sabor = "Calabresa";
            }
            else if (sabor == "F")
            {
                sabor = "Frango";
            }
            return sabor;
        }

        public string DefinirTamanho(string tamanho)
        {
            switch (tamanho)
            {
                case "P":
                    {
                        TamanhoDePizza = TamanhoDePizza.Pequena;
                        break;
                    }
                case "M":
                    {
                        TamanhoDePizza = TamanhoDePizza.Media;
                        break;
                    }
                case "G":
                    {
                        TamanhoDePizza = TamanhoDePizza.Grande;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Tamanho não definido");

                    }
            }
            return Enum.GetName(TamanhoDePizza);
        }
    }
}