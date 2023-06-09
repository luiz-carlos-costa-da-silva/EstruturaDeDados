using EstruturaDeDados;

namespace EstruturaDeDados.Util;

sealed public class Utilitario
{
    public static void Imprimir(params object[]? elementos)
    {
        if (elementos != null)
            foreach(var item in elementos)
                Console.Write(item);
        Console.WriteLine();
    }

    public static Vetor<T> CriarVetor<T>(params T[] elementos) => new Vetor<T>(elementos);
    
    public static VetorDinamico CriarVetorDinamico(params object[] elementos) => new VetorDinamico(elementos);
}
