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
            ImageUri = "6e067ad6-14a2-43a7-94b5-d145cab0fa95.png",
            Email = "michal@gmail.com", 
            PhoneNumber = "+48 777 888 777", 
            Bio = "Pasjonat zdrowego stylu życia i fitnessu. Z ponad 5-letnim doświadczeniem jako trener personalny, pomogłem wielu osobom osiągnąć ich cele zdrowotne i kondycyjne. Specjalizuję się w treningach siłowych, kondycyjnych oraz w doradztwie żywieniowym.", 
            HashedPassword = hashedUserPassword,
            PersonalTrainingPriceFrom = 100,
            PersonalTrainingPriceTo = 150,
            TrainingPlanPriceFrom = 200,
            TrainingPlanPriceTo = 250,
            IsAccepted = true
        };
        var user2 = new User
{
    IdUser = 2,
    IdRole = 3,
    Name = "Anna",
    LastName = "Kowalska",
    ImageUri = "d0202f7d-453f-42fa-b9d9-6c91b68f5ee1.png",
    Email = "anna.kowalska@gmail.com",
    PhoneNumber = "+48 666 555 444",
    Bio = "Ekspertka od jogi i pilatesu z ponad 8-letnim doświadczeniem. Pomogłam setkom osób poprawić ich elastyczność, siłę i zdrowie psychiczne. Moje zajęcia są dostosowane do każdego poziomu zaawansowania.",
    HashedPassword = hashedUserPassword, 
    PersonalTrainingPriceFrom = 120,
    PersonalTrainingPriceTo = 170,
    TrainingPlanPriceFrom = 220,
    TrainingPlanPriceTo = 270,
    IsAccepted = true
};

var user3 = new User
{
    IdUser = 3,
    IdRole = 3,
    Name = "Jakub",
    LastName = "Nowak",
    ImageUri = "e2d2e547-8d22-4f54-972b-0a474ba02b3e.png ",
    Email = "jakub.nowak@gmail.com",
    PhoneNumber = "+48 555 444 333",
    Bio = "Specjalista od treningu siłowego i crossfitu. Z ponad 10 lat doświadczenia w branży fitness, moim celem jest pomaganie klientom w budowaniu siły, wytrzymałości i pewności siebie.",
    HashedPassword = hashedUserPassword,
    PersonalTrainingPriceFrom = 130,
    PersonalTrainingPriceTo = 180,
    TrainingPlanPriceFrom = 230,
    TrainingPlanPriceTo = 280,
    IsAccepted = true
};

var user4 = new User
{
    IdUser = 4,
    IdRole = 3,
    Name = "Ewa",
    LastName = "Wiśniewska",
    ImageUri = "64b48343-760f-40b9-b001-52e063e5aab1.png ",
    Email = "ewa.wisniewska@gmail.com",
    Sex = "Kobieta",
    Bio = "Pasjonatka zdrowego żywienia i treningów funkcjonalnych. Z certyfikatem dietetyka i trenera, pomagam moim klientom osiągać cele związane z poprawą kompozycji ciała i samopoczucia.",
    HashedPassword = hashedUserPassword,
    PersonalTrainingPriceFrom = 110,
    PersonalTrainingPriceTo = 160,
    TrainingPlanPriceFrom = 210,
    TrainingPlanPriceTo = 260,
    IsAccepted = true
};

var user5 = new User
{
    IdUser = 5,
    IdRole = 3,
    Name = "Tomasz",
    LastName = "Zieliński",
    Email = "tomasz.zielinski@gmail.com",
    PhoneNumber = "+48 888 999 000",
    Bio = "Trener boksu i samoobrony z 12-letnim stażem. Specjalizuję się w pracy z ludźmi w każdym wieku, ucząc ich nie tylko technik walki, ale również dyscypliny i szacunku do siebie i innych.",
    HashedPassword = hashedUserPassword,
    PersonalTrainingPriceFrom = 140,
    PersonalTrainingPriceTo = 190,
    TrainingPlanPriceFrom = 240,
    TrainingPlanPriceTo = 290,
    IsAccepted = true
};
var user6 = new User
{
    IdUser = 6,
    IdRole = 3,
    Name = "Marcin",
    LastName = "Dąbrowski",
    Email = "marcin.dabrowski@gmail.com",
    PhoneNumber = "+48 111 222 333",
    Bio = "Doświadczony trener personalny i fizjoterapeuta z ponad 10 lat doświadczenia. Specjalizuję się w rehabilitacji sportowej, treningach siłowych i poprawie mobilności. Moje metody pracy są oparte na najnowszych badaniach i dostosowane do indywidualnych potrzeb klientów.",
    HashedPassword = hashedUserPassword, 
    PersonalTrainingPriceFrom = 150,
    PersonalTrainingPriceTo = 200,
    TrainingPlanPriceFrom = 250,
    TrainingPlanPriceTo = 300,
    IsAccepted = true
};




var user7 = new User
{
    IdUser = 7,
    IdRole = 4,
    Name = "Piotr",
    LastName = "Wójcik",
    ImageUri = "344f5775-e8f2-417d-a884-d297d8f754be.png",
    Email = "piotr.wojcik@gmail.com",
    PhoneNumber = "+48 200 300 400",
    Bio = "Dietetyk kliniczny z doświadczeniem w pracy z pacjentami z chorobami metabolicznymi. Specjalizuję się w dietoterapii cukrzycowej, otyłości oraz chorób sercowo-naczyniowych. Moje plany żywieniowe są tworzone na podstawie najnowszych wytycznych naukowych.",
    HashedPassword = hashedUserPassword,
    DietPriceFrom = 150,
    DietPriceTo = 200,
    IsAccepted = true
};

var user8 = new User
{
    IdUser = 8,
    IdRole = 4,
    Name = "Tomasz",
    LastName = "Lewandowski",
    Email = "tomasz.lewandowski@gmail.com",
    PhoneNumber = "+48 210 310 410",
    Bio = "Ekspert od dietetyki sportowej z wieloletnim doświadczeniem w pracy z zawodowymi sportowcami. Moje podejście łączy najnowszą wiedzę z zakresu nauk o żywieniu z indywidualnymi potrzebami klienta, aby maksymalizować ich wyniki sportowe.",
    HashedPassword = hashedUserPassword,
    DietPriceFrom = 160,
    DietPriceTo = 210,
    IsAccepted = true
};

var user9 = new User
{
    IdUser = 9,
    IdRole = 4,
    Name = "Anna",
    LastName = "Majewska",
    ImageUri = "6215d910-8dd4-42f8-ad03-e5b900d1d2bc.png",
    Email = "anna.majewska@gmail.com",
    PhoneNumber = "+48 220 320 420",
    Bio = "Dietetyczka z pasją do pomagania ludziom w zmianie ich nawyków żywieniowych i osiąganiu celów zdrowotnych. Specjalizuję się w dietach wegetariańskich, wegańskich oraz w redukcji wagi.",
    HashedPassword = hashedUserPassword,
    DietPriceFrom = 120,
    DietPriceTo = 170,
    IsAccepted = true
};

var user10 = new User
{
    IdUser = 10,
    IdRole = 4,
    Name = "Ewa",
    LastName = "Kubiak",
    ImageUri = "ae4e5ae8-d5eb-4f33-9a37-c86ec4558eca.png",
    Email = "ewa.kubiak@gmail.com",
    PhoneNumber = "+48 230 330 430",
    Bio = "Specjalistka od żywienia klinicznego i zdrowego stylu życia. Z doświadczeniem w pracy zarówno z dziećmi, jak i dorosłymi, tworzę spersonalizowane plany żywieniowe, które wspierają zdrowie i dobre samopoczucie.",
    HashedPassword = hashedUserPassword,
    DietPriceFrom = 130,
    DietPriceTo = 180,
    IsAccepted = true
};

var user11 = new User
{
    IdUser = 11,
    IdRole = 4,
    Name = "Katarzyna",
    LastName = "Zawadzka",
    Email = "katarzyna.zawadzka@gmail.com",
    PhoneNumber = "+48 240 340 440",
    Bio = "Dietetyczka z zamiłowaniem do żywienia dzieci i młodzieży. Moja praca skupia się na edukacji żywieniowej oraz tworzeniu zbilansowanych, smacznych planów żywieniowych, które pomagają młodym ludziom rosnąć zdrowo i szczęśliwie.",
    HashedPassword = hashedUserPassword,
    DietPriceFrom = 140,
    DietPriceTo = 190,
    IsAccepted = true
};

var user12 = new User
{
    IdUser = 12,
    IdRole = 4,
    Name = "Michał",
    LastName = "Sikora",
    ImageUri = "6ebe92cf-ead1-4582-9f96-271be4e69f76.png",
    Email = "michal.sikora@gmail.com",
    PhoneNumber = "+48 250 350 450",
    Bio = "Dietetyk specjalizujący się w żywieniu osób starszych i zarządzaniu chorobami przewlekłymi poprzez dietę. Moje podejście to połączenie empatii, wiedzy i dostosowania planów żywieniowych do unikalnych potrzeb każdego klienta.",
    HashedPassword = hashedUserPassword,
    DietPriceFrom = 150,
    DietPriceTo = 200,
    IsAccepted = true
};



var user13 = new User
{
    IdUser = 13,
    IdRole = 5,
    Name = "Krzysztof",
    LastName = "Borowski",
    ImageUri = "abe1a889-83bc-440d-b751-d17244558d7b.png",
    Email = "krzysztof.borowski@gmail.com",
    PhoneNumber = "+48 300 400 500",
    Bio = "Zawodowy trener i dietetyk z 12-letnim stażem. Specjalizuję się w kompleksowym podejściu do fitnessu i zdrowego odżywiania, łącząc trening siłowy z zbilansowanym planem żywieniowym.",
    HashedPassword = hashedUserPassword,
    PersonalTrainingPriceFrom = 200,
    PersonalTrainingPriceTo = 250,
    TrainingPlanPriceFrom = 300,
    TrainingPlanPriceTo = 350,
    DietPriceFrom = 150,
    DietPriceTo = 200,
    IsAccepted = true
};

var user14 = new User
{
    IdUser = 14,
    IdRole = 5,
    Name = "Adam",
    LastName = "Nowak",
    Email = "adam.nowak@gmail.com",
    PhoneNumber = "+48 310 410 510",
    Bio = "Ekspert od żywienia i treningu personalnego. Pomagam klientom osiągać ich cele związane z formą fizyczną i zdrowiem poprzez indywidualnie dostosowane plany treningowe i dietetyczne.",
    HashedPassword = hashedUserPassword,
    PersonalTrainingPriceFrom = 210,
    PersonalTrainingPriceTo = 260,
    TrainingPlanPriceFrom = 310,
    TrainingPlanPriceTo = 360,
    DietPriceFrom = 160,
    DietPriceTo = 210,
    IsAccepted = true
};

var user15 = new User
{
    IdUser = 15,
    IdRole = 5,
    Name = "Joanna",
    LastName = "Kubiak",
    ImageUri = "cb69da6a-09b6-43f3-88c9-8b77f23d06b5.png",
    Email = "joanna.kubiak@gmail.com",
    PhoneNumber = "+48 320 420 520",
    Bio = "Pasjonatka zdrowego stylu życia, certyfikowana dietetyczka i trenerka personalna. Specjalizuję się w treningach funkcjonalnych i doradztwie żywieniowym dla kobiet.",
    HashedPassword = hashedUserPassword,
    PersonalTrainingPriceFrom = 180,
    PersonalTrainingPriceTo = 230,
    TrainingPlanPriceFrom = 280,
    TrainingPlanPriceTo = 330,
    DietPriceFrom = 130,
    DietPriceTo = 180,
    IsAccepted = true
};

var user16 = new User
{
    IdUser = 16,
    IdRole = 5,
    Name = "Magdalena",
    LastName = "Sikorska",
    ImageUri = "44b42606-ca16-4ddc-b552-249cac1f6f34.png",
    Email = "magdalena.sikorska@gmail.com",
    PhoneNumber = "+48 330 430 530",
    Bio = "Dietetyk i trenerka z miłością do pomagania ludziom w transformacji ich życia. Skupiam się na zrównoważonym żywieniu i efektywnych treningach, które poprawiają kondycję i samopoczucie.",
    HashedPassword = hashedUserPassword,
    PersonalTrainingPriceFrom = 190,
    PersonalTrainingPriceTo = 240,
    TrainingPlanPriceFrom = 290,
    TrainingPlanPriceTo = 340,
    DietPriceFrom = 140,
    DietPriceTo = 190,
    IsAccepted = true
};

var user17 = new User
{
    IdUser = 17,
    IdRole = 5,
    Name = "Katarzyna",
    LastName = "Zawadzka",
    Email = "katarzyna.zawadzka@gmail.com",
    PhoneNumber = "+48 340 440 540",
    Bio = "Ekspertka w dziedzinie dietetyki i fitnessu. Oferuję holistyczne podejście do zdrowia, łączące naukowe podejście do odżywiania z indywidualnie dostosowanymi treningami.",
    HashedPassword = hashedUserPassword,
    PersonalTrainingPriceFrom = 195,
    PersonalTrainingPriceTo = 245,
    TrainingPlanPriceFrom = 295,
    TrainingPlanPriceTo = 345,
    DietPriceFrom = 145,
    DietPriceTo = 195,
    IsAccepted = true
};

var user18 = new User
{
    IdUser = 18,
    IdRole = 5,
    Name = "Robert",
    LastName = "Lewandowski",
    Email = "robert.lewandowski@gmail.com",
    ImageUri = "82cbe9a9-6748-4774-a231-895c245e49c0.png",
    PhoneNumber = "+48 350 450 550",
    Bio = "Profesjonalny dietetyk-trener, specjalizujący się w przygotowaniach do zawodów sportowych i optymalizacji zdrowia metabolicznego. Moje programy łączą dietetykę sportową z treningiem siłowym i wytrzymałościowym.",
    HashedPassword = hashedUserPassword,
    PersonalTrainingPriceFrom = 220,
    PersonalTrainingPriceTo = 270,
    TrainingPlanPriceFrom = 320,
    TrainingPlanPriceTo = 370,
    DietPriceFrom = 170,
    DietPriceTo = 220,
    IsAccepted = true
};

var user19 = new User
{
    IdUser = 19,
    IdRole = 2,
    Name = "Michał",
    LastName = "Kowalski",
    ImageUri = "436006ea-a754-4ad2-b7fb-b7db6a8ecb77.png",
    Email = "michal.kowalski@gmail.com",
    Bio = "Amator biegania i triatlonu szukający profesjonalnej pomocy w poprawie wyników i optymalizacji diety.",
    HashedPassword = hashedUserPassword,
    Sex = "Mężczyzna",
    Height = 180,
    Weight = 75,
    DateOfBirth = new DateTime(1985, 05, 15)
};

var user20 = new User
{
    IdUser = 20,
    IdRole = 2,
    Name = "Anna",
    LastName = "Nowak",
    Email = "anna.nowak@gmail.com",
    Bio = "Zaangażowana w zdrowy styl życia, poszukuje wsparcia w zakresie żywienia i planowania treningów, aby osiągnąć lepszą formę i samopoczucie.",
    HashedPassword = hashedUserPassword,
    Sex = "Kobieta",
    Height = 165,
    Weight = 60,
    DateOfBirth = new DateTime(1990, 08, 20)
};

var user21 = new User
{
    IdUser = 21,
    IdRole = 2,
    Name = "Magdalena",
    LastName = "Wiśniewska",
    ImageUri = "089e2d9d-51a4-4b7f-a245-99a1a5e4e729.png",
    Email = "magdalena.wisniewska@gmail.com",
    Bio = "Pasjonatka jogi i pilatesu, chcąca zwiększyć swoją wiedzę o zdrowym odżywianiu i zintegrować ją z aktywnością fizyczną, by poprawić jakość życia.",
    HashedPassword = hashedUserPassword,
    Sex = "Kobieta",
    Height = 170,
    Weight = 65,
    DateOfBirth = new DateTime(1995, 03, 30)
};






        var userAdmin = new User
        {
            IdUser = 22,
            IdRole = 1,
            Name = "Admin",
            LastName = "Admin",
            Email = "admin@gmail.com",
            HashedPassword = hashedAdminPassword
        };
        builder.HasData(user1, user2, user3, user4, user5, user6, user7, user8, user9, user10, user11, user12, user13, user14, user15, user16, user17, user18, user19, user20, user21, userAdmin);
        
    }
}