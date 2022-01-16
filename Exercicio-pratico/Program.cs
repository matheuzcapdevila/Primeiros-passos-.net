using System;

namespace Exercicio{

    class Program{
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario(); // Chama esse método

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno");
                        Aluno aluno = new Aluno(); // Cria o objeto aluno
                        aluno.Nome = Console.ReadLine(); // Pegando o console e colocando direto no objeto
                        
                        Console.WriteLine("Informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)){
                             aluno.Nota = nota;

                        } // Var não precisa especificar o tipo da variavel. 
                        //Parse converte string em decimal TryParse seria eu consigo ou não converter para o caso do
                        //Usuario digitar algo diferente
                        else {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++; 
                       

                        break;
                    case "2":
                        foreach(var a in alunos){
                            if (!string.IsNullOrEmpty(a.Nome)){ //Para apenas printar o que for preenchido. Se for nulo ou vazio não vai retornar true, com ! o inverso
                            
                            Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            Console.WriteLine();
                            }
                        }
                        break;
                    case "3":
                        var nrAlunos = 0;
                        decimal notaTotal = 0; 
                        for (int i=0; i<alunos.Length;i++){
                            if (!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal = notaTotal + alunos[i].Nota; //Se não explicitar notaTotal como var vai dar erro, então tem que explicitar como decimal, porque Nota é
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal/nrAlunos;
                        
                        Conceito conceitogeral; // Vem do outro arquivo

                        if (mediaGeral < 2){
                            conceitogeral = Conceito.E;
                        }
                        else if (mediaGeral < 4){
                            conceitogeral = Conceito.D;
                        }
                        else if (mediaGeral < 6){
                            conceitogeral = Conceito.C;
                        }
                        else if (mediaGeral < 8){
                            conceitogeral = Conceito.B;
                        }
                        else {
                            conceitogeral = Conceito.A;
                        }

                        Console.WriteLine($"Media GERAL: {mediaGeral} - Conceito: {conceitogeral}");
                        break; 
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                

                opcaoUsuario = ObterOpcaoUsuario(); // Chamando o método


            }


        }

        private static string ObterOpcaoUsuario() // Reaproveitamento do código
        {
            
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine(); //Pula linha
            return opcaoUsuario;
        }
    }
}



