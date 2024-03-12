using Ardalis.Specification;
using Domain.Entities;


namespace Application.Specifications
{
    public class PageColaboradorSpecification : Specification<Colaborador>
    {
        public PageColaboradorSpecification(int pageSize, int pageNumber, string searchText)
        {

            Query.Where(x=> string.IsNullOrEmpty(searchText) || (x.PrimerNombre.Equals(searchText) || x.PrimerApellido.Equals(searchText))).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

           
        }
    }
}
