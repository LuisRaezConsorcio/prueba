using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces;
namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application
{
    public class DocumentTypeAggregate : IDocumentTypeAggregate
    {
        private readonly IDocumentTypeRepository _repository;
        public DocumentTypeAggregate(IDocumentTypeRepository repository)
        {
            _repository = repository;
        }
       
        public DocumentTypeResponse FindResponse(int DocumentTypeId)
        {
            var row = _repository.FindResponse(DocumentTypeId);
            return row;
        }

        
        public List<DocumentTypeResponse> FindAll()
        {
            try
            {
                var users = _repository.FindAll();
                return users;
            }
            catch (Exception)
            {
                return new List<DocumentTypeResponse>();
            }
        }



    }
}