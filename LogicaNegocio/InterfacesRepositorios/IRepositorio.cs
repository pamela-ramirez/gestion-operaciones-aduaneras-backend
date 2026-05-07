namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T>
    {
        void Add(T item);
        void Delete(int id);
        void Update(T item, int id);
        T FindById(int id);
        IEnumerable<T> FindAll();

        //IEnumerable<T> FindByName(string name);
        //lo dejo ahi porque capaz lo necesitemos.

    }
}
