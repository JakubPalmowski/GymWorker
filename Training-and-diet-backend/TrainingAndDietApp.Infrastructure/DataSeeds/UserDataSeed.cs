using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Infrastructure.DataSeeds;

public class UserDataSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        
        var userPassword = "Password123";
        var adminPassword = "Admin123";
        var hashedUserPassword = BCrypt.Net.BCrypt.HashPassword(userPassword);
        var hashedAdminPassword = BCrypt.Net.BCrypt.HashPassword(adminPassword);

        var user1 = new User
        {
            IdUser = 1, 
            IdRole = 3, 
            Name = "Michał", 
            LastName = "Emczyk", 
            Email = "michal@gmail.com", 
            PhoneNumber = "48777888777", 
            Sex = "Male", 
            Bio = "Pasjonat zdrowego stylu życia i fitnessu. Z ponad 5-letnim doświadczeniem jako trener personalny, pomogłem wielu osobom osiągnąć ich cele zdrowotne i kondycyjne. Specjalizuję się w treningach siłowych, kondycyjnych oraz w doradztwie żywieniowym.", 
            HashedPassword = hashedUserPassword
        };
        var user2 = new User
        {
            IdUser = 2, 
            IdRole = 3, 
            Name = "Anna", 
            LastName = "Kowalska", 
            Email = "anna@gmail.com", 
            PhoneNumber = "48666778888", 
            Sex = "Female", 
            Bio = "Zawodowa trenerka fitness z pasją do jogi i pilatesu. Uwielbiam inspirować innych do prowadzenia zdrowszego trybu życia. Moje sesje treningowe są energiczne, motywujące i dostosowane do indywidualnych potrzeb każdego klienta.", 
            HashedPassword = hashedUserPassword
        };
        var user3 = new User
        {
            IdUser = 3, 
            IdRole = 4, 
            Name = "Andrzej", 
            LastName = "Kowalski", 
            Email = "andrzej@gmail.com", 
            PhoneNumber = "48555667777", 
            Sex = "Male", 
            Bio = "Dietetyk kliniczny z zamiłowaniem do sportu. Moje podejście łączy naukowe podstawy żywienia z praktycznymi poradami, które pomagają klientom osiągnąć ich cele zdrowotne bez poświęcania przyjemności jedzenia.", 
            HashedPassword = hashedUserPassword
        };
        var user4 = new User
        {
            IdUser = 4,
            IdRole = 4,
            Name = "Marcin",
            LastName = "Michalski",
            Email = "marcin@gmail.com",
            PhoneNumber = "48554567890",
            Sex = "Male",
            Bio =
                "Ekspert od wellness i poprawy samopoczucia, z certyfikatem dietetyka. Zajmuję się holistycznym podejściem do zdrowia, łączac odżywianie i mentalność, aby wspierać klientów w osiąganiu zrównoważonego stylu życia.",
            HashedPassword = hashedUserPassword
        };
        var user5 = new User
        {
            IdUser = 5,
            IdRole = 1,
            Name = "Admin",
            LastName = "Admin",
            Email = "admin@gmail.com",
            HashedPassword = hashedAdminPassword
        };
        builder.HasData(user1, user2, user3, user4, user5);
        
    }
}