using Capacitacion.Domain.Abstractions;
using Capacitacion.Domain.Categories.Events;


namespace Capacitacion.Domain.Categories;

public class Category : Entity
{
   
    public string? Name {get; private set;}
    private Category(){}
    private Category(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public static Category Create(string name)
    {
        var category = new Category(Guid.NewGuid(), name);
        var categoryDomainEvent = new CategoryCreatedDomainEvent(category.Id);
        category.RiseDomainEvent(categoryDomainEvent);
        return category;
    }
}