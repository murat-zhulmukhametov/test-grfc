using System;
using grfcTest.DataLayer.Entities;
using grfcTest.DataLayer.Entities.Works;
using grfcTest.DataLayer.Infrastructure;

namespace grfcTest.Models.Works.CreateEdit
{
    public class WorkFormHandler : IWorkFormHandler
    {
        private readonly IEntityRepository<IgrfcEntity> entityRepository;
        private readonly IWorkFactory workFactory;

        public WorkFormHandler(IEntityRepository<IgrfcEntity> entityRepository, IWorkFactory workFactory)
        {
            this.entityRepository = entityRepository;
            this.workFactory = workFactory;
        }

        public Guid HandleCreate(WorkForm form)
        {
            var work = workFactory.Create(form.Description, form.EngineType);

            entityRepository.InsertOnSave(work);
            entityRepository.SaveChanges();

            return work.Id;
        }

        public void HandleEdit(WorkForm form, WorkValidationResult valResult)
        {
            var work = valResult.Work;

            work.Description = form.Description;
            work.EngineType = form.EngineType;

            entityRepository.SaveChanges();
        }
    }
}