using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedDataChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "IdCertificate", "AddedDate", "Description", "IdMentor", "IsAccepted", "PdfUri" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1432), "Certyfikat trenera personalnego.", 1, true, "febb6cb4-3805-499d-b776-ff493aa35a14.pdf" },
                    { 2, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1435), "Certyfikat trenera personalnego.", 2, true, "03f34030-4c42-4f13-935b-35b95963e167.pdf" },
                    { 3, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1436), "Certyfikat trenera personalnego.", 3, false, "f8b22ef7-24d4-4ef5-95be-47a1c83479c5.pdf" },
                    { 4, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1437), "Certyfikat trenera personalnego.", 4, true, "ab05466b-6a0d-4353-8fd3-03beb4ff53c0.pdf" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "IdExercise", "Details", "ExerciseSteps", "IdTrainer", "Name" },
                values: new object[,]
                {
                    { 1, "Ćwiczenie na nogi i pośladki", "Stań prosto z nogami rozstawionymi na szerokość barków. Powoli zginaj kolana, zachowując prosty kręgosłup. Schodź do momentu, aż uda będą równolegle do podłogi. Wróć do pozycji wyjściowej.", null, "Przysiady" },
                    { 2, "Ćwiczenie na klatkę piersiową, ramiona i tricepsy", "Połóż dłonie na podłodze na szerokość barków. Utrzymaj ciało w prostej linii i opuszczaj się, zginając łokcie, aż klatka piersiowa prawie dotknie podłogi. Wróć do pozycji wyjściowej.", null, "Pompki" },
                    { 3, "Ćwiczenie na mięśnie brzucha", "Połóż się na plecach, zegnij kolana i postaw stopy na podłodze. Połóż dłonie za głową. Powoli podnosz tułów do kolan, a następnie powoli opuszczaj się z powrotem.", null, "Brzuszki" },
                    { 4, "Ćwiczenie na dolną część pleców, nogi i pośladki", "Stań prosto trzymając sztangę przed sobą. Zginaj biodra i kolana, opuszczając sztangę w dół, aż do momentu, gdy znajdzie się na wysokości goleni. Wróć do pozycji wyjściowej, prostując nogi i biodra.", null, "Martwy ciąg" },
                    { 5, "Ćwiczenie na górne partie pleców", "Stań z sztangą trzymaną w obu dłoniach. Pochyl się w biodrach, utrzymując lekki zgięcie w kolanach. Ciągnij sztangę do dolnej części klatki piersiowej, ściągając łopatki. Powoli opuść sztangę z powrotem.", null, "Wiosłowanie sztangą" }
                });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 1,
                column: "IsAccepted",
                value: true);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 2,
                column: "IsAccepted",
                value: true);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 3,
                column: "IsAccepted",
                value: true);

            migrationBuilder.InsertData(
                table: "Trainer_Gyms",
                columns: new[] { "IdGym", "IdTrainer" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                columns: new[] { "HashedPassword", "ImageUri", "IsAccepted", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", "6e067ad6-14a2-43a7-94b5-d145cab0fa95.png", true, 100m, 150m, "+48 777 888 777", null, 200m, 250m });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                columns: new[] { "Bio", "Email", "HashedPassword", "ImageUri", "IsAccepted", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { "Ekspertka od jogi i pilatesu z ponad 8-letnim doświadczeniem. Pomogłam setkom osób poprawić ich elastyczność, siłę i zdrowie psychiczne. Moje zajęcia są dostosowane do każdego poziomu zaawansowania.", "anna.kowalska@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", "d0202f7d-453f-42fa-b9d9-6c91b68f5ee1.png", true, 120m, 170m, "+48 666 555 444", null, 220m, 270m });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3,
                columns: new[] { "Bio", "Email", "HashedPassword", "IdRole", "ImageUri", "IsAccepted", "LastName", "Name", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { "Specjalista od treningu siłowego i crossfitu. Z ponad 10 lat doświadczenia w branży fitness, moim celem jest pomaganie klientom w budowaniu siły, wytrzymałości i pewności siebie.", "jakub.nowak@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", 3, "e2d2e547-8d22-4f54-972b-0a474ba02b3e.png ", true, "Nowak", "Jakub", 130m, 180m, "+48 555 444 333", null, 230m, 280m });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4,
                columns: new[] { "Bio", "Email", "HashedPassword", "IdRole", "ImageUri", "IsAccepted", "LastName", "Name", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { "Pasjonatka zdrowego żywienia i treningów funkcjonalnych. Z certyfikatem dietetyka i trenera, pomagam moim klientom osiągać cele związane z poprawą kompozycji ciała i samopoczucia.", "ewa.wisniewska@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", 3, "64b48343-760f-40b9-b001-52e063e5aab1.png ", true, "Wiśniewska", "Ewa", 110m, 160m, null, "Kobieta", 210m, 260m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "Bio", "DateOfBirth", "DietPriceFrom", "DietPriceTo", "Email", "HashedPassword", "Height", "IdRole", "ImageUri", "IsAccepted", "LastName", "Name", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "RefreshToken", "RefreshTokenExpirationDate", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo", "Weight" },
                values: new object[,]
                {
                    { 5, "Trener boksu i samoobrony z 12-letnim stażem. Specjalizuję się w pracy z ludźmi w każdym wieku, ucząc ich nie tylko technik walki, ale również dyscypliny i szacunku do siebie i innych.", null, null, null, "tomasz.zielinski@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 3, null, true, "Zieliński", "Tomasz", 140m, 190m, "+48 888 999 000", null, null, null, 240m, 290m, null },
                    { 6, "Doświadczony trener personalny i fizjoterapeuta z ponad 10 lat doświadczenia. Specjalizuję się w rehabilitacji sportowej, treningach siłowych i poprawie mobilności. Moje metody pracy są oparte na najnowszych badaniach i dostosowane do indywidualnych potrzeb klientów.", null, null, null, "marcin.dabrowski@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 3, null, true, "Dąbrowski", "Marcin", 150m, 200m, "+48 111 222 333", null, null, null, 250m, 300m, null },
                    { 7, "Dietetyk kliniczny z doświadczeniem w pracy z pacjentami z chorobami metabolicznymi. Specjalizuję się w dietoterapii cukrzycowej, otyłości oraz chorób sercowo-naczyniowych. Moje plany żywieniowe są tworzone na podstawie najnowszych wytycznych naukowych.", null, 150m, 200m, "piotr.wojcik@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 4, "344f5775-e8f2-417d-a884-d297d8f754be.png", true, "Wójcik", "Piotr", null, null, "+48 200 300 400", null, null, null, null, null, null },
                    { 8, "Ekspert od dietetyki sportowej z wieloletnim doświadczeniem w pracy z zawodowymi sportowcami. Moje podejście łączy najnowszą wiedzę z zakresu nauk o żywieniu z indywidualnymi potrzebami klienta, aby maksymalizować ich wyniki sportowe.", null, 160m, 210m, "tomasz.lewandowski@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 4, null, true, "Lewandowski", "Tomasz", null, null, "+48 210 310 410", null, null, null, null, null, null },
                    { 9, "Dietetyczka z pasją do pomagania ludziom w zmianie ich nawyków żywieniowych i osiąganiu celów zdrowotnych. Specjalizuję się w dietach wegetariańskich, wegańskich oraz w redukcji wagi.", null, 120m, 170m, "anna.majewska@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 4, "6215d910-8dd4-42f8-ad03-e5b900d1d2bc.png", true, "Majewska", "Anna", null, null, "+48 220 320 420", null, null, null, null, null, null },
                    { 10, "Specjalistka od żywienia klinicznego i zdrowego stylu życia. Z doświadczeniem w pracy zarówno z dziećmi, jak i dorosłymi, tworzę spersonalizowane plany żywieniowe, które wspierają zdrowie i dobre samopoczucie.", null, 130m, 180m, "ewa.kubiak@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 4, "ae4e5ae8-d5eb-4f33-9a37-c86ec4558eca.png", true, "Kubiak", "Ewa", null, null, "+48 230 330 430", null, null, null, null, null, null },
                    { 11, "Dietetyczka z zamiłowaniem do żywienia dzieci i młodzieży. Moja praca skupia się na edukacji żywieniowej oraz tworzeniu zbilansowanych, smacznych planów żywieniowych, które pomagają młodym ludziom rosnąć zdrowo i szczęśliwie.", null, 140m, 190m, "katarzyna.zawadzka@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 4, null, true, "Zawadzka", "Katarzyna", null, null, "+48 240 340 440", null, null, null, null, null, null },
                    { 12, "Dietetyk specjalizujący się w żywieniu osób starszych i zarządzaniu chorobami przewlekłymi poprzez dietę. Moje podejście to połączenie empatii, wiedzy i dostosowania planów żywieniowych do unikalnych potrzeb każdego klienta.", null, 150m, 200m, "michal.sikora@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 4, "6ebe92cf-ead1-4582-9f96-271be4e69f76.png", true, "Sikora", "Michał", null, null, "+48 250 350 450", null, null, null, null, null, null },
                    { 13, "Zawodowy trener i dietetyk z 12-letnim stażem. Specjalizuję się w kompleksowym podejściu do fitnessu i zdrowego odżywiania, łącząc trening siłowy z zbilansowanym planem żywieniowym.", null, 150m, 200m, "krzysztof.borowski@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 5, "abe1a889-83bc-440d-b751-d17244558d7b.png", true, "Borowski", "Krzysztof", 200m, 250m, "+48 300 400 500", null, null, null, 300m, 350m, null },
                    { 14, "Ekspert od żywienia i treningu personalnego. Pomagam klientom osiągać ich cele związane z formą fizyczną i zdrowiem poprzez indywidualnie dostosowane plany treningowe i dietetyczne.", null, 160m, 210m, "adam.nowak@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 5, null, true, "Nowak", "Adam", 210m, 260m, "+48 310 410 510", null, null, null, 310m, 360m, null },
                    { 15, "Pasjonatka zdrowego stylu życia, certyfikowana dietetyczka i trenerka personalna. Specjalizuję się w treningach funkcjonalnych i doradztwie żywieniowym dla kobiet.", null, 130m, 180m, "joanna.kubiak@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 5, "cb69da6a-09b6-43f3-88c9-8b77f23d06b5.png", true, "Kubiak", "Joanna", 180m, 230m, "+48 320 420 520", null, null, null, 280m, 330m, null },
                    { 16, "Dietetyk i trenerka z miłością do pomagania ludziom w transformacji ich życia. Skupiam się na zrównoważonym żywieniu i efektywnych treningach, które poprawiają kondycję i samopoczucie.", null, 140m, 190m, "magdalena.sikorska@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 5, "44b42606-ca16-4ddc-b552-249cac1f6f34.png", true, "Sikorska", "Magdalena", 190m, 240m, "+48 330 430 530", null, null, null, 290m, 340m, null },
                    { 17, "Ekspertka w dziedzinie dietetyki i fitnessu. Oferuję holistyczne podejście do zdrowia, łączące naukowe podejście do odżywiania z indywidualnie dostosowanymi treningami.", null, 145m, 195m, "katarzyna.zawadzka@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 5, "82cbe9a9-6748-4774-a231-895c245e49c0.png", true, "Zawadzka", "Katarzyna", 195m, 245m, "+48 340 440 540", null, null, null, 295m, 345m, null },
                    { 18, "Profesjonalny dietetyk-trener, specjalizujący się w przygotowaniach do zawodów sportowych i optymalizacji zdrowia metabolicznego. Moje programy łączą dietetykę sportową z treningiem siłowym i wytrzymałościowym.", null, 170m, 220m, "robert.lewandowski@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", null, 5, null, true, "Lewandowski", "Robert", 220m, 270m, "+48 350 450 550", null, null, null, 320m, 370m, null },
                    { 19, "Amator biegania i triatlonu szukający profesjonalnej pomocy w poprawie wyników i optymalizacji diety.", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "michal.kowalski@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", 180m, 2, "436006ea-a754-4ad2-b7fb-b7db6a8ecb77.png", false, "Kowalski", "Michał", null, null, null, null, null, "Mężczyzna", null, null, 75m },
                    { 20, "Zaangażowana w zdrowy styl życia, poszukuje wsparcia w zakresie żywienia i planowania treningów, aby osiągnąć lepszą formę i samopoczucie.", new DateTime(1990, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "anna.nowak@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", 165m, 2, null, false, "Nowak", "Anna", null, null, null, null, null, "Kobieta", null, null, 60m },
                    { 21, "Pasjonatka jogi i pilatesu, chcąca zwiększyć swoją wiedzę o zdrowym odżywianiu i zintegrować ją z aktywnością fizyczną, by poprawić jakość życia.", new DateTime(1995, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "magdalena.wisniewska@gmail.com", "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e", 170m, 2, "089e2d9d-51a4-4b7f-a245-99a1a5e4e729.png", false, "Wiśniewska", "Magdalena", null, null, null, null, null, "Kobieta", null, null, 65m },
                    { 22, null, null, null, null, "admin@gmail.com", "$2a$11$7aINjux8LPZ6sHPSIHnYme/Xp11oanULdNMUyrUcgGwdAAKHCDIFW", null, 1, null, false, "Admin", "Admin", null, null, null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "IdCertificate", "AddedDate", "Description", "IdMentor", "IsAccepted", "PdfUri" },
                values: new object[,]
                {
                    { 5, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1438), "Certyfikat trenera personalnego.", 5, true, "a811d65d-ea91-4981-ac23-dfd020f888f0.pdf" },
                    { 6, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1440), "Certyfikat trenera personalnego.", 6, true, "5ce15f47-5af6-48e1-a995-8163e365f989.pdf" },
                    { 7, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1441), "Certyfikat zaawansowanego instruktora fitness.", 7, false, "b8516244-c04b-408f-8825-ceed297744a2.pdf" },
                    { 8, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1441), "Certyfikat ukończenia specjalistycznego kursu Pilates.", 8, true, "5a986774-64a5-48ff-93a9-908eedeebb65.pdf" },
                    { 9, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1442), "Certyfikat ukończenia kursu trenera personalnego.", 9, true, "03a23944-7156-46ac-8a74-2e918e511d12.pdf" },
                    { 10, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1444), "Certyfikat dietetyka klinicznego z akredytacją.", 10, true, "1fa0350a-3d69-4eb5-807c-096983c9f35d.pdf" },
                    { 11, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1445), "Certyfikat zaawansowanego instruktora fitness.", 11, false, "fb6e1e39-8404-4095-a2ce-4f47a870e723.pdf" },
                    { 12, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1446), "Certyfikat ukończenia specjalistycznego kursu Pilates.", 12, true, "6eb77e22-90ae-46d0-a5be-378a5da63c74.pdf" },
                    { 13, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1446), "Certyfikat ukończenia kursu trenera personalnego.", 13, true, "594982e8-d080-4098-9ff4-f857997ac4d6.pdf" },
                    { 14, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1447), "Certyfikat dietetyka klinicznego z akredytacją.", 14, true, "0243ab80-01d3-4407-98ee-9019cbd621cd.pdf" },
                    { 15, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1448), "Certyfikat zaawansowanego instruktora fitness.", 15, false, "b32cfec6-95c3-4d62-a9a5-3e8eeac16b01.pdf" },
                    { 16, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1449), "Certyfikat ukończenia specjalistycznego kursu Pilates.", 16, true, "98a5f8aa-2371-46b7-944f-36962f8470ac.pdf" },
                    { 17, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1450), "Certyfikat ukończenia kursu trenera personalnego.", 17, true, "3da44fad-5888-44c9-a716-a5dff7875ff7.pdf" },
                    { 18, new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1451), "Certyfikat dietetyka klinicznego z akredytacją.", 18, true, "715b3582-14eb-45e8-a33d-6cf8ff679364.pdf" }
                });

            migrationBuilder.InsertData(
                table: "Opinion",
                columns: new[] { "IdMentor", "IdPupil", "Content", "OpinionDate", "Rate" },
                values: new object[,]
                {
                    { 1, 19, "Bardzo profesjonalne podejście do treningu. Czułem się zmotywowany i wspierany przez cały czas. Zdecydowanie polecam tego mentora!", new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1682), 4.5m },
                    { 10, 19, "Zmiana diety zalecona przez dietetyka znacząco poprawiła moje samopoczucie i wyniki w sporcie. Profesjonalizm i indywidualne podejście do moich potrzeb żywieniowych zrobiły na mnie ogromne wrażenie.", new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1691), 5.0m },
                    { 1, 20, "Podejście mentora do diety i treningu przekroczyło moje oczekiwania. Indywidualnie dopasowany plan i ciągła motywacja dały świetne wyniki.", new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1689), 5.0m },
                    { 8, 20, "Dzięki wskazówkom dietetyka udało mi się nie tylko schudnąć, ale też nauczyłem się, jak zdrowo się odżywiać na co dzień. Bardzo doceniam dostosowanie planu diety do mojego intensywnego trybu życia.", new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1692), 5.0m },
                    { 1, 21, "Trener jest bardzo zaangażowany i posiada ogromną wiedzę. Udało mi się osiągnąć cele, o których wcześniej mogłem tylko marzyć. Polecam z całego serca!", new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1690), 4.8m },
                    { 9, 21, "Dietetyk pomógł mi zrozumieć, jak ważna jest dieta w moim treningu. Jego/jej wsparcie i motywacja były nieocenione w drodze do osiągnięcia moich celów zdrowotnych. Absolutnie polecam!", new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1694), 4.0m }
                });

            migrationBuilder.InsertData(
                table: "Trainer_Gyms",
                columns: new[] { "IdGym", "IdTrainer" },
                values: new object[,]
                {
                    { 1, 15 },
                    { 1, 18 },
                    { 3, 16 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 10, 19 });

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 8, 20 });

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 9, 21 });

            migrationBuilder.DeleteData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.DeleteData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 3, 16 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 21);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 1,
                column: "IsAccepted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 2,
                column: "IsAccepted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 3,
                column: "IsAccepted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                columns: new[] { "HashedPassword", "ImageUri", "IsAccepted", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { "$2a$11$WLvEJW0cgBdb0f81E9tt/uB41IskjQuuNsVFT7eJFpYl.aqSdhlSu", null, false, null, null, "48777888777", "Male", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                columns: new[] { "Bio", "Email", "HashedPassword", "ImageUri", "IsAccepted", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { "Zawodowa trenerka fitness z pasją do jogi i pilatesu. Uwielbiam inspirować innych do prowadzenia zdrowszego trybu życia. Moje sesje treningowe są energiczne, motywujące i dostosowane do indywidualnych potrzeb każdego klienta.", "anna@gmail.com", "$2a$11$WLvEJW0cgBdb0f81E9tt/uB41IskjQuuNsVFT7eJFpYl.aqSdhlSu", null, false, null, null, "48666778888", "Female", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3,
                columns: new[] { "Bio", "Email", "HashedPassword", "IdRole", "ImageUri", "IsAccepted", "LastName", "Name", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { "Dietetyk kliniczny z zamiłowaniem do sportu. Moje podejście łączy naukowe podstawy żywienia z praktycznymi poradami, które pomagają klientom osiągnąć ich cele zdrowotne bez poświęcania przyjemności jedzenia.", "andrzej@gmail.com", "$2a$11$WLvEJW0cgBdb0f81E9tt/uB41IskjQuuNsVFT7eJFpYl.aqSdhlSu", 4, null, false, "Kowalski", "Andrzej", null, null, "48555667777", "Male", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4,
                columns: new[] { "Bio", "Email", "HashedPassword", "IdRole", "ImageUri", "IsAccepted", "LastName", "Name", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { "Ekspert od wellness i poprawy samopoczucia, z certyfikatem dietetyka. Zajmuję się holistycznym podejściem do zdrowia, łączac odżywianie i mentalność, aby wspierać klientów w osiąganiu zrównoważonego stylu życia.", "marcin@gmail.com", "$2a$11$WLvEJW0cgBdb0f81E9tt/uB41IskjQuuNsVFT7eJFpYl.aqSdhlSu", 4, null, false, "Michalski", "Marcin", null, null, "48554567890", "Male", null, null });
        }
    }
}
