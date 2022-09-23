using System.Linq;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {            

            try
            {
                if (Suite.Capacidade >= hospedes.Count)
                {
                    Hospedes = hospedes;

                }
                else
                {
                    Console.WriteLine("A capacidade da Suite já foi excedida!");
                    Console.Write("Pressione Enter para fechar janela ...");
                    Console.Read();

                    Environment.Exit(0);
                }
            }
            catch (System.NullReferenceException ex)
            {

                Console.WriteLine("Hospedagem cheia" + ex); 
            }                 

        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {                     
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {            
            decimal valor = DiasReservados * Suite.ValorDiaria;
            decimal desconto = 0;
            
            if (DiasReservados >= 10)
            {
                desconto = 10;                
                valor = valor - ((desconto / 100) * valor);
                return valor;
            }
            return valor;
        }
    }
}