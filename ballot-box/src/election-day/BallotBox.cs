namespace election_day
{
    public class BallotBox
    {
        public int receivedOption1;
        public int receivedOption2;
        public int receivedOption3;
        public int optionNull;

        public int GetCountVoters()
        {
            Console.WriteLine("O número de eleitores deve ser um número inteiro maior que zero.");
            Console.WriteLine("Informe o número de eleitores:");
            int countVoters = Convert.ToInt32(Console.ReadLine());
            return countVoters;
        }

        public void Start(int countVoters)
        {
            for (int i = 0; i < countVoters; i++)
            {
                Console.WriteLine("Digite o número do candidato de 1 a 3:");
                string? vote = Console.ReadLine();

                switch (vote)
                {
                    case "1":
                        receivedOption1 += 1;
                        break;
                    case "2":
                        receivedOption2 += 1;
                        break;
                    case "3":
                        receivedOption3 += 1;
                        break;
                    default:
                        optionNull += 1;
                        break;
                }
                Console.WriteLine("Voto registrado.");
            }
        }

        public void PrintResult()
        {
            Console.WriteLine("A opção 1 recebeu: " + receivedOption1 + " voto(s)");
            Console.WriteLine("A opção 2 recebeu: " + receivedOption2 + " voto(s)");
            Console.WriteLine("A opção 3 recebeu: " + receivedOption3 + " voto(s)");
            Console.WriteLine("Total de votos anulados:" + optionNull + "voto(s)");
        }
    }
}
