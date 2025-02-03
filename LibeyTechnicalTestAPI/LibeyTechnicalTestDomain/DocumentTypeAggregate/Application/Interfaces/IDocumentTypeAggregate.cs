using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces
{
    public interface IDocumentTypeAggregate
    {
        DocumentTypeResponse FindResponse(int DocumentTypeId);
        List<DocumentTypeResponse> FindAll();
    }
}