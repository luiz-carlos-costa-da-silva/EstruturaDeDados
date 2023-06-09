using static EstruturaDeDados.Util.Utilitario;

var vetor= CriarVetor<int>(2, 1, 4, 3, 6, 5, 7, 8, 10, 9);
Imprimir("Conteúdo do vetor antes de qualquer operação: " + vetor);

vetor.Adicionar(12, 11, 13);
Imprimir("Vetor com novos elementos: " + vetor);

vetor.Ordenar();
Imprimir("Vetor ordenado em orde crescente: " + vetor);

int index = vetor.Encontrar(6);
var removido = vetor.Remover(index);
Imprimir("Elemento removido do vetor: " + removido);
Imprimir("Vetor sem o elemento {" + removido + "}: " + vetor);

removido = vetor.Remover();
Imprimir("Último elemento removido do vetor: " + removido);
Imprimir("Vetor sem o elemento {" + removido + "}: " + vetor);

Imprimir("Usando os delegate:");
vetor.Mapear(elemento => elemento * 2)
    .Filtrar(elemento => elemento > 10)
    .ParaCada(elemento => Console.Write(elemento + " "));
Imprimir();

vetor.Limpar(); // Esvazia o vetor
Imprimir("Verificando o tamanho do vetor depois de ser esvaziado: " + vetor.Tamanho);
