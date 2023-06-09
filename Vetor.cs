namespace EstruturaDeDados;

public class Vetor<T>
{
    // Campos:
    protected T[] elementos = new T[0];

    // Propriedades:
    public T[] Elementos { get => this.elementos; }
    public int Tamanho { get => this.elementos.Length; }

    // Indexador:
    public T this[int index]
    {
        get => this.elementos[index];
        set => this.elementos[index] = value;
    }

    /// <summary>Construtor</summary>
    public Vetor(params T[] elementos) => this.elementos = elementos;

    /// <summary>
    /// O método adiciona um ou mais elementos ao final do vetor
    /// </summary>
    public void Adicionar(params T[] elementos)
    {
        int tamanho1 = this.Tamanho;
        int tamanho2 = elementos.Length;
        Array.Resize(ref this.elementos, (tamanho1 + tamanho2));
        Array.Copy(elementos, 0, this.elementos, tamanho1, tamanho2);
    }

    /// <summary>
    /// O método adiciona um elemento ao final do vetor
    /// </summary>
    public void Adicionar(T elemento)
    {
        int tamanho = this.Tamanho;
        Array.Resize(ref this.elementos, (tamanho + 1));
        this.elementos[tamanho] = elemento;
    }

    /// <summary>
    /// O método limpa o vetor
    /// </summary>
    public void Limpar() => this.elementos = new T[0];

    /// <summary>
    /// O método remove o último elemento do vetor
    /// </summary>
    public T Remover()
    {
        int ultimoElemento = this.Tamanho - 1;
        T removido = this.elementos[ultimoElemento];
        T[] elementos = this.elementos.Take(ultimoElemento).ToArray();
        this.Limpar();
        this.Adicionar(elementos);
        return removido;
    }

    /// <summary>
    /// O método remove o valor do primeiro elemento que satisfaça
    /// a função de teste.
    /// </summary>
    public T Remover(int index)
    {
        try
        {
            T removido = this.elementos[index];
            Vetor<T> vetor = this.Filtrar(elemento => {
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

    public int? Encontrar(T elemento)
    {
        int? chave = null;
        for (int i = 0; i < this.Tamanho; i++)
            if (elemento != null)
                if (elemento.Equals(this[i]))
                    chave = i;   
        return chave;
    }

    /// <summary>
    /// O método ordena os elementos do próprio vetor
    /// </summary>
    public void Ordenar(bool desc = false)
    {
        if (desc) Array.Reverse(this.elementos);
        else Array.Sort(this.elementos);
    }

    /// <summary>
    /// O método executa uma dada função em cada elemento do vetor
    /// </summary>
    public void ParaCada(Action<T> callback)
    {
        foreach(T item in this.elementos)
            callback(item);
    }

    /// <summary>
    /// O método cria um novo vetor com todos os elementos que passaram no teste
    /// implementado pela função fornecida.
    /// </summary>
    public Vetor<T> Filtrar(Predicate<T> callback)
    {
        Vetor<T> vetor = new Vetor<T>();
        foreach(T item in this.elementos)
            if (callback(item))
                vetor.Adicionar(item);
        return vetor;
    }

    /// <summary>
    /// O método executa uma função passada como argumento para cada
    /// elemento do vetor e devolve um novo vetor como resultado
    /// </summary>
    public Vetor<T> Mapear(Func<T, T> callback)
    {
        Vetor<T> vetor = new Vetor<T>();
        foreach(T item in this.elementos)
            vetor.Adicionar(callback(item));
        return vetor;
    }

    /// <summary>
    /// Retorna uma string representando o Vetor
    /// </summary>
    public override string ToString() => String.Join(", ", this.elementos);
}
