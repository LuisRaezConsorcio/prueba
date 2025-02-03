
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces
{
    public interface IDocumentTypeRepository
    {
        DocumentTypeResponse FindResponse(int DocumentTypeId);
        List<DocumentTypeResponse> FindAll();
    }
}
