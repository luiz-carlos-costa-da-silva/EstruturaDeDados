namespace EstruturaDeDados;

public class VetorDinamico
{
    private object[] elementos = new object[0];

    public object[] Elementos { get => this.elementos; }
    public int Tamanho { get => this.elementos.Length; }

    public object this[int index]
    {
        get => this.elementos[index];
        set => this.elementos[index] = value;
    }

    public VetorDinamico(params object[] elementos) => this.elementos = elementos;

    public void Adicionar(params object[] elementos)
    {
        int tamanho1 = this.Tamanho;
        int tamanho2 = elementos.Length;
        Array.Resize(ref this.elementos, (tamanho1 + tamanho2));
        Array.Copy(elementos, 0, this.elementos, tamanho1, tamanho2);
    }

    public void Limpar() => this.elementos = new object[0];

    public object Remover()
    {
        int ultimoElemento = this.Tamanho - 1;
        object removido = this[ultimoElemento];
        object[] elementos = this.elementos.Take(ultimoElemento).ToArray();
        this.Limpar();
        this.Adicionar(elementos);
        return removido;
    }

    public object Remover(int index)
    {
        try
        {
            object removido = this[index];
            VetorDinamico vetor = this.Filtrar(elemento => {
                bool resultado = false;
                if (elemento != null)
                    if (!elemento.Equals(removido))
                        resultado = true;
                return resultado;
            });
            this.Limpar();
            this.elementos = vetor.Elementos;
            return removido;   
        }
        catch (IndexOutOfRangeException e)
        {
            throw new IndexOutOfRangeException(e.Message);
        }
    }

    public int Encontrar(object elemento)
    {
        int chave = -1;
        for (int i = 0; i < this.Tamanho; i++)
            if (elemento != null)
                if (elemento.Equals(this[i]))
                    chave = i;   
        return chave;
    }

    public void ParaCada(Action<object> callback)
    {
        foreach(var item in this.elementos)
            callback(item);
    }

    public VetorDinamico Filtrar(Predicate<object> callback)
    {
        VetorDinamico vetor = new VetorDinamico();
        foreach(var item in this.elementos)
            if (callback(item))
                vetor.Adicionar(item);
        return vetor;
    }

    public VetorDinamico Mapear(Func<object, object> callback)
    {
        VetorDinamico vetor = new VetorDinamico();
        foreach(var item in this.elementos)
            vetor.Adicionar(callback(item));
        return vetor;
    }

    public override string ToString() => String.Join(", ", this.elementos);
}
