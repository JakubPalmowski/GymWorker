using TrainingAndDietApp.DAL.EntityModels;

namespace TrainingAndDietApp.Domain.Abstractions;

public interface IPupilMentorRepository
{
    Task<PupilMentor?> IsPupilCooperatingWithMentor(int idPupil, int idMentor, CancellationToken cancellationToken);
    
}