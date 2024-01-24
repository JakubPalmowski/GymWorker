using TrainingAndDietApp.DAL.EntityModels;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions;

public interface IPupilMentorRepository
{
    Task<PupilMentor?> IsPupilCooperatingWithMentor(int idPupil, int idMentor, CancellationToken cancellationToken);
    Task DeletePupilMentorAsync(PupilMentor pupilMentor, CancellationToken cancellation);
    Task<List<PupilMentor>> GetInvitationsAsync(int idMentor, CancellationToken cancellation);
    
}