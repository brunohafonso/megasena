using System;
using System.Collections.Generic;
using System.Linq;
using megasena.Models;

namespace megasena.Regras
{
    public class GeradorJogos
    {
        JogoDomain Jogo = new JogoDomain();

        public List<string> GerandoJogos(JogoDomain Jogo)
        {
            int JogoRepetido = 0;
                        
            //iniciando a lista de jogos do objeto
            Jogo.Jogos = new List<string>();

            //iniciando a lista de jogos gerados
            var numeros = new List<int>();

            //iniciando variavel randomica
            Random rnd = new Random();

            //loop para criar a quantidade de jogos inserida
            while(Jogo.Jogos.Count < Jogo.QuantidadeJogos)
            {
               string jogo = null;
               
               /* gerando lista de numeros aleatorios de 1 a 60, como é uma seguencia fechada de 1 a 60, 
                não há risco de ter números repetidos na mesma sequência.*/
               numeros = Enumerable.Range(1, 60).OrderBy(x => rnd.Next()).Take(Jogo.QuantidadeNumeros).ToList();

               foreach(var num in numeros)
               {
                   jogo = jogo + " " +  num;
               }

               //verificando se o jogo não repetiu, caso ja tenha sido gerado algum jogo
               if(Jogo.Jogos.Count > 0) 
               {
                  for(var i = 0; i < Jogo.Jogos.Count; i++)
                  {
                      if(Jogo.Jogos[i] == jogo)
                      {
                          JogoRepetido++;
                          break;
                      }
                  } 
               }

               if(JogoRepetido == 0) 
               {
                   jogo = jogo.TrimStart(' ');
                   Jogo.Jogos.Add(jogo);
               }  
               

               JogoRepetido = 0;
               numeros.Clear();
            }

            return Jogo.Jogos;
        }
    }
}