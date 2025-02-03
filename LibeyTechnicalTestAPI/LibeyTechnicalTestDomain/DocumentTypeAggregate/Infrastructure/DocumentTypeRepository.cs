using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Domain;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Infrastructure
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly Context _context;
        public DocumentTypeRepository(Context context)
        {
            _context = context;
        }
        
        public DocumentTypeResponse FindResponse(int DocumentTypeId)
        {

            var q = from DocumentType in _context.DocumentTypes.Where(x => x.DocumentTypeId.Equals(DocumentTypeId))
                    select new DocumentTypeResponse()
                    {
                        DocumentTypeId = DocumentType.DocumentTypeId,
                        DocumentTypeDescription = DocumentType.DocumentTypeDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new DocumentTypeResponse();
        }

        public List<DocumentTypeResponse> FindAll()
        {
            var users = from DocumentType in _context.DocumentTypes
                        select new DocumentTypeResponse()
                        {
                            DocumentTypeId = DocumentType.DocumentTypeId,
                            DocumentTypeDescription = DocumentType.DocumentTypeDescription
                        };

            return users.ToList();
        }






    }
}